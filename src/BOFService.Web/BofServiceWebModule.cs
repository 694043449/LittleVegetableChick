using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.RateLimiting;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.Redis.StackExchange;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using Volo.Abp.AspNetCore.Auditing;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Caching;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Swashbuckle;
using BOFService.Application;
using BOFService.Domain.Shared.Consts;
using BOFService.Domain.Shared.Options;
using BOFService.SqlsugarCore;
using Yi.Framework.AspNetCore;
using Yi.Framework.AspNetCore.Authentication.OAuth;
using Yi.Framework.AspNetCore.Authentication.OAuth.Gitee;
using Yi.Framework.AspNetCore.Authentication.OAuth.QQ;
using Yi.Framework.AspNetCore.Microsoft.AspNetCore.Builder;
using Yi.Framework.AspNetCore.Microsoft.Extensions.DependencyInjection;
using Yi.Framework.BackgroundWorkers.Hangfire;
using Yi.Framework.Core.Json;

namespace BOFService.Web
{
    [DependsOn(
        typeof(BofServiceSqlSugarCoreModule),
        typeof(BofServiceApplicationModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(AbpAspNetCoreMvcModule),

        typeof(AbpSwashbuckleModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpAuditingModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(YiFrameworkAspNetCoreModule),
        typeof(YiFrameworkAspNetCoreAuthenticationOAuthModule),
        
        typeof(YiFrameworkBackgroundWorkersHangfireModule),
        typeof(AbpAutofacModule)
    )]
    public class BofServiceWebModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //动态Api-改进在pre中配置，启动更快
            PreConfigure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(BofServiceApplicationModule).Assembly,
                    options => options.RemoteServiceName = "default");
                
                //统一前缀
                options.ConventionalControllers.ConventionalControllerSettings.ForEach(x => x.RootPath = "api");
            });
        }

        public override Task ConfigureServicesAsync(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var host = context.Services.GetHostingEnvironment();
            var service = context.Services;

            //本地开发环境，禁用作业执行
            if (host.IsDevelopment())
            {
                Configure<AbpBackgroundWorkerOptions> (options =>
                {
                    options.IsEnabled = false; 
                });
            }
            
            //请求日志
            Configure<AbpAuditingOptions>(options =>
            {
                //默认关闭，开启会有大量的审计日志
                options.IsEnabled = false;
            });
            //忽略审计日志路径
            Configure<AbpAspNetCoreAuditingOptions>(options =>
            {
                options.IgnoredUrls.Add("/api/app/file/");
                options.IgnoredUrls.Add("/hangfire");
            });

            //采用furion格式的规范化api，默认不开启，使用abp优雅的方式
            //你没看错。。。
            //service.AddFurionUnifyResultApi();

            //配置错误处理显示详情
            Configure<AbpExceptionHandlingOptions>(options => { options.SendExceptionsDetailsToClients = true; });

            //【NewtonsoftJson严重问题！！！！！逆天】设置api格式，留给后人铭记
            // service.AddControllers().AddNewtonsoftJson(options =>
            // {
            //     options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            //     options.SerializerSettings.Converters.Add(new StringEnumConverter());
            // });

            //请使用微软的，注意abp date又包了一层，采用DefaultJsonTypeInfoResolver统一覆盖
            Configure<JsonOptions>(options =>
            {
                options.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver();
                options.JsonSerializerOptions.Converters.Add(new DatetimeJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            //设置缓存不要过期，默认滑动20分钟
            Configure<AbpDistributedCacheOptions>(cacheOptions =>
            {
                cacheOptions.GlobalCacheEntryOptions.SlidingExpiration = null;
                //缓存key前缀
                cacheOptions.KeyPrefix = "BOFService:";
            });


            Configure<AbpAntiForgeryOptions>(options => { options.AutoValidate = false; });

            //Swagger
            context.Services.AddYiSwaggerGen<BofServiceWebModule>(options =>
            {
                options.SwaggerDoc("default",
                    new OpenApiInfo { Title = "BOFService.Abp", Version = "v1", Description = "DDD" });
            });

            //跨域
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]!
                                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            //配置多租户
            Configure<AbpTenantResolveOptions>(options =>
            {
                //基于cookie jwt不好用，有坑
                options.TenantResolvers.Clear();
                options.TenantResolvers.Add(new HeaderTenantResolveContributor());
                //options.TenantResolvers.Add(new HeaderTenantResolveContributor());
                //options.TenantResolvers.Add(new CookieTenantResolveContributor());
                //options.TenantResolvers.RemoveAll(x => x.Name == CookieTenantResolveContributor.ContributorName);
            });

            //配置Hangfire定时任务存储，开启redis后，优先使用redis
            var redisConfiguration = configuration["Redis:Configuration"];
            context.Services.AddHangfire(config=>
            {
                var redisEnabled=configuration.GetSection("Redis").GetValue<bool>("IsEnabled");
                if (redisEnabled)
                {
                    var jobDb=configuration.GetSection("Redis").GetValue<int>("JobDb");
                    config.UseRedisStorage(
                        ConnectionMultiplexer.Connect(redisConfiguration),
                        new RedisStorageOptions()
                        {
                            Db =jobDb,
                            InvisibilityTimeout = TimeSpan.FromHours(1), //JOB允许执行1小时
                            Prefix = "Yi:HangfireJob:"
                        }).WithJobExpirationTimeout(TimeSpan.FromHours(1));
                }
                else
                {
                    config.UseMemoryStorage();
                }
            });

            //速率限制
            //每60秒限制100个请求，滑块添加，分6段
            service.AddRateLimiter(_ =>
            {
                _.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
                _.OnRejected = (context, _) =>
                {
                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                    {
                        context.HttpContext.Response.Headers.RetryAfter =
                            ((int)retryAfter.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo);
                    }

                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    context.HttpContext.Response.WriteAsync("Too many requests. Please try again later.");

                    return new ValueTask();
                };

                //全局使用，链式表达式
                _.GlobalLimiter = PartitionedRateLimiter.CreateChained(
                    PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    {
                        var userAgent = httpContext.Request.Headers.UserAgent.ToString();

                        return RateLimitPartition.GetSlidingWindowLimiter
                        (userAgent, _ =>
                            new SlidingWindowRateLimiterOptions
                            {
                                PermitLimit = 1000,
                                Window = TimeSpan.FromSeconds(60),
                                SegmentsPerWindow = 6,
                                QueueProcessingOrder = QueueProcessingOrder.OldestFirst
                            });
                    }));
            });

            //jwt鉴权    
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            var refreshJwtOptions = configuration.GetSection(nameof(RefreshJwtOptions)).Get<RefreshJwtOptions>();

            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            //优先Query中获取，再去cookies中获取
                            var accessToken = context.Request.Query["access_token"];
                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                context.Token = accessToken;
                            }
                            else
                            {
                                if (context.Request.Cookies.TryGetValue("Token", out var cookiesToken))
                                {
                                    context.Token = cookiesToken;
                                }
                            }

                            return Task.CompletedTask;
                        }
                    };
                })
                .AddJwtBearer(TokenTypeConst.Refresh, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = refreshJwtOptions.Issuer,
                        ValidAudience = refreshJwtOptions.Audience,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(refreshJwtOptions.SecurityKey))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var refresh_token = context.Request.Headers["refresh_token"];
                            if (!string.IsNullOrEmpty(refresh_token))
                            {
                                context.Token = refresh_token;
                                return Task.CompletedTask;
                            }

                            var refreshToken = context.Request.Query["refresh_token"];
                            if (!string.IsNullOrEmpty(refreshToken))
                            {
                                context.Token = refreshToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            //授权
            context.Services.AddAuthorization();


            return Task.CompletedTask;
        }


        public override async Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
        {
            var service = context.ServiceProvider;
            var env = context.GetEnvironment();
            var app = context.GetApplicationBuilder();

            app.UseRouting();

            //跨域
            app.UseCors(DefaultCorsPolicyName);

            if (!env.IsDevelopment())
            {
                //速率限制
                app.UseRateLimiter();
            }


            //无感token，先刷新再鉴权
            // app.UseRefreshToken();

            //鉴权
            app.UseAuthentication();

            //多租户
            app.UseMultiTenancy();

            //swagger
            app.UseYiSwagger();

            //流量访问统计,需redis支持，否则不生效
            // app.UseAccessLog();

            //请求处理
            app.UseApiInfoHandling();

            //静态资源
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/api/app/wwwroot",
                // 可以在这里添加或修改MIME类型映射  
                ContentTypeProvider = new FileExtensionContentTypeProvider
                {
                    Mappings =
                    {
                        [".wxss"] = "text/css"
                    }
                }
            });
            app.UseDefaultFiles();
            app.UseDirectoryBrowser("/api/app/wwwroot");


            // app.Properties.Add("_AbpExceptionHandlingMiddleware_Added",false);
            //工作单元
            app.UseUnitOfWork();

            //授权
            app.UseAuthorization();

            //审计日志
            app.UseAuditing();

            //日志记录
            app.UseAbpSerilogEnrichers();

            //Hangfire定时任务面板，可配置授权，意框架支持jwt
            app.UseAbpHangfireDashboard("/hangfire",
                options =>
                {
                    options.AsyncAuthorization = new[] { new YiTokenAuthorizationFilter(app.ApplicationServices) };
                });

            //终节点
            app.UseConfiguredEndpoints();
        }
    }
}