using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using BOFService.Domain.Shared;
using Yi.Framework.Mapster;

namespace BOFService.Domain
{
    [DependsOn(
        typeof(BofServiceDomainSharedModule),
        typeof(YiFrameworkMapsterModule),
        typeof(AbpDddDomainModule),
        typeof(AbpCachingModule)
        )]
    public class BofServiceDomainModule : AbpModule
    {

    }
}