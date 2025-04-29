using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using BOFService.Domain;
using BOFService.SqlSugarCore;
using Yi.Framework.Mapster;
using Yi.Framework.SqlSugarCore;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace BOFService.SqlsugarCore
{
    [DependsOn(
        typeof(BofServiceDomainModule),
        typeof(YiFrameworkMapsterModule),
        typeof(YiFrameworkSqlSugarCoreModule)
    )]
    public class BofServiceSqlSugarCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddYiDbContext<BofServiceDbContext>();
            //默认不开放，可根据项目需要是否Db直接对外开放
            //context.Services.AddTransient(x => x.GetRequiredService<ISqlSugarDbContext>().SqlSugarClient);
        }
    }
}