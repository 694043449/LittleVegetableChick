using BOFService.Application.Contracts.DTOs.PlanInfo;
using BOFService.Application.Contracts.IServices;
using BOFService.Domain.Entities;
using BOFService.Domain.Managers;
using BOFService.Domain.Repositories;
using BOFService.Domain.Shared.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Yi.Framework.Ddd.Application;

namespace BOFService.Application.Services
{
    /// <summary>
    /// 钢铁生产计划服务实现
    /// </summary>
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class PlanInfoService : YiCrudAppService<PlanInfo, GetPlanInfoOutputDto, Guid, GetListPlanInfoInputDto, CreateUpdatePlanInfoDto, CreateUpdatePlanInfoDto>, IPlanInfoService
    {
        private readonly PlanInfoManager _planInfoManager;
        private readonly IPlanInfoRepository _planInfoRepository;

        public PlanInfoService(
            IPlanInfoRepository planInfoRepository,
            PlanInfoManager planInfoManager)
            : base(planInfoRepository)
        {
            _planInfoRepository = planInfoRepository;
            _planInfoManager = planInfoManager;
        }

        /// <summary>
        /// 获取生产计划分页列表(条件查询)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [RemoteService(IsEnabled = true)]
        [HttpPost("planInfo/getPagedList")]
        public override async Task<PagedResultDto<GetPlanInfoOutputDto>> GetListAsync(GetListPlanInfoInputDto input)
        {
            // 处理分页条件查询
            var (items, totalCount) = await _planInfoManager.GetPlanInfoPagedListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Keyword,
                input.StartTime,
                input.EndTime,
                input.IsCompleted,
                input.ItemTag,
                input.TimeRangeType);

            return new PagedResultDto<GetPlanInfoOutputDto>
            {
                TotalCount = totalCount,
                Items = await MapToGetListOutputDtosAsync(items)
            };
        }

        /// <summary>
        /// 添加或修改生产计划
        /// </summary>
        /// <param name="input">生产计划信息</param>
        /// <returns>添加后的生产计划信息</returns>
        [HttpPost("planInfo/createOrUpdate")]
        public async Task<GetPlanInfoOutputDto> CreateOrUpdateAsync(CreateUpdatePlanInfoDto input)
        {
            // 检查是否为更新操作
            bool isUpdate = input.Id != Guid.Empty;
            
            // 检查计划号是否已存在（排除当前实体）
            var existingPlan = await _planInfoRepository.FindByPlanNoAsync(input.PlanNo);
            if (existingPlan != null && (!isUpdate || existingPlan.Id != input.Id))
            {
                throw new BusinessException(
                    ErrorCodes.Common.EntityAlreadyExists,
                    string.Format(ErrorMessages.Common.EntityAlreadyExists, "计划号"))
                    .WithData("PlanNo", input.PlanNo);
            }
            
            // 检查炉次号是否已存在（排除当前实体）
            var existingCvtTime = await _planInfoRepository.FindByCvtTimeNoAsync(input.CvtTimeNo);
            if (existingCvtTime != null && (!isUpdate || existingCvtTime.Id != input.Id))
            {
                throw new BusinessException(
                    ErrorCodes.Common.EntityAlreadyExists,
                    string.Format(ErrorMessages.Common.EntityAlreadyExists, "炉次号"))
                    .WithData("CvtTimeNo", input.CvtTimeNo);
            }

            if (isUpdate)
            {
                return await base.UpdateAsync(input.Id, input);
            }
            // 新增时项目标签默认赋n表示正常
            input.ItemTag = "n";
            
            return await base.CreateAsync(input);
        }

        /// <summary>
        /// 删除单个
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [RemoteService(IsEnabled = true)]
        [HttpDelete("planInfo/delete")]
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
} 