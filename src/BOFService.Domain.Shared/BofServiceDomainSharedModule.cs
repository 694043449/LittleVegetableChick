using Volo.Abp.Domain;
using Volo.Abp.SettingManagement;

namespace BOFService.Domain.Shared
{
    [DependsOn(
        typeof(AbpSettingManagementDomainSharedModule),
        typeof(AbpDddDomainSharedModule))]
    public class BofServiceDomainSharedModule : AbpModule
    {

    }
}