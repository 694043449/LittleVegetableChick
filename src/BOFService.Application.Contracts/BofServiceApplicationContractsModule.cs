using Volo.Abp.SettingManagement;
using BOFService.Domain.Shared;
using Yi.Framework.Ddd.Application.Contracts;

namespace BOFService.Application.Contracts
{
    [DependsOn(
        typeof(BofServiceDomainSharedModule),
        typeof(AbpSettingManagementApplicationContractsModule),
        typeof(YiFrameworkDddApplicationContractsModule))]
    public class BofServiceApplicationContractsModule:AbpModule
    {

    }
}