using BOFService.Application.Contracts;
using BOFService.Domain;
using BOFService.Domain.Shared.Options;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Yi.Framework.Ddd.Application;
using Yi.Framework.Mapster;

namespace BOFService.Application
{
    [DependsOn(
        typeof(BofServiceApplicationContractsModule),
        typeof(BofServiceDomainModule),
        typeof(YiFrameworkDddApplicationModule),
        typeof(YiFrameworkMapsterModule)
        )]
    public class BofServiceApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            
            // 配置 JwtOptions
            context.Services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

            // 注册 Mapster 相关服务
            var config = TypeAdapterConfig.GlobalSettings;
            context.Services.AddSingleton(config);
            context.Services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}
