using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BOFService.Domain.Entities;
using BOFService.Domain.Repositories;
using BOFService.Domain.Shared.Constants;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace BOFService.Domain.Managers
{
    /// <summary>
    /// 钢铁生产计划管理器
    /// </summary>
    public class PlanInfoManager : DomainService
    {
        private readonly IPlanInfoRepository _planInfoRepository;

        public PlanInfoManager(IPlanInfoRepository planInfoRepository)
        {
            _planInfoRepository = planInfoRepository;
        }

        /// <summary>
        /// 计算时间范围
        /// </summary>
        /// <param name="timeRangeType">时间范围类型</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>计算后的时间范围</returns>
        public (DateTime? startTime, DateTime? endTime) CalculateTimeRange(int? timeRangeType, DateTime? startTime, DateTime? endTime)
        {
            if (!timeRangeType.HasValue)
            {
                return (startTime, endTime);
            }

            switch (timeRangeType.Value)
            {
                case 1: // 今天
                    return (DateTime.Today, DateTime.Today.AddDays(1).AddSeconds(-1));
                case 2: // 近三天
                    return (DateTime.Today.AddDays(-2), DateTime.Today.AddDays(1).AddSeconds(-1));
                case 3: // 近一周
                    return (DateTime.Today.AddDays(-6), DateTime.Today.AddDays(1).AddSeconds(-1));
                case 4: // 近一个月
                    return (DateTime.Today.AddMonths(-1), DateTime.Today.AddDays(1).AddSeconds(-1));
                case 5: // 全部
                    return (null, null);
                default:
                    return (startTime, endTime);
            }
        }

        /// <summary>
        /// 获取生产计划分页列表
        /// </summary>
        /// <param name="skipCount">跳过数量</param>
        /// <param name="maxResultCount">最大返回数量</param>
        /// <param name="keyword">关键词</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isCompleted">是否完成</param>
        /// <param name="itemTag">项目标签</param>
        /// <param name="timeRangeType">时间范围类型</param>
        /// <returns>分页结果</returns>
        public async Task<(List<PlanInfo> Items, long TotalCount)> GetPlanInfoPagedListAsync(
            int skipCount,
            int maxResultCount,
            string keyword = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            bool? isCompleted = null,
            string itemTag = null,
            int? timeRangeType = null)
        {
            // 处理时间范围
            (startTime, endTime) = CalculateTimeRange(timeRangeType, startTime, endTime);

            // 调用Repository获取数据
            return await _planInfoRepository.GetPlanInfoPagedListAsync(
                skipCount,
                maxResultCount,
                keyword,
                startTime,
                endTime,
                isCompleted,
                itemTag);
        }
    }
} 