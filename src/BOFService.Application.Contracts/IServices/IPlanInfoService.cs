using BOFService.Application.Contracts.DTOs.PlanInfo;
using Yi.Framework.Ddd.Application.Contracts;

namespace BOFService.Application.Contracts.IServices
{
    /// <summary>
    /// 钢铁生产计划服务接口
    /// </summary>
    public interface IPlanInfoService : IYiCrudAppService<GetPlanInfoOutputDto, Guid, GetListPlanInfoInputDto, CreateUpdatePlanInfoDto, CreateUpdatePlanInfoDto>
    {
        /// <summary>
        /// 添加生产计划
        /// </summary>
        /// <param name="input">生产计划信息</param>
        /// <returns>添加后的生产计划信息</returns>
        Task<GetPlanInfoOutputDto> CreateOrUpdateAsync(CreateUpdatePlanInfoDto input);
    }
} 