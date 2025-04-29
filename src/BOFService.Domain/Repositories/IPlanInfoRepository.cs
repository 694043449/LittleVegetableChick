using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BOFService.Domain.Entities;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace BOFService.Domain.Repositories
{
    /// <summary>
    /// 钢铁生产计划仓储接口
    /// </summary>
    public interface IPlanInfoRepository : ISqlSugarRepository<PlanInfo,Guid>
    {
        /// <summary>
        /// 根据计划号获取生产计划
        /// </summary>
        /// <param name="planNo">计划号</param>
        /// <returns>生产计划信息</returns>
        Task<PlanInfo> FindByPlanNoAsync(string planNo);

        /// <summary>
        /// 根据炉次号获取生产计划
        /// </summary>
        /// <param name="cvtTimeNo">炉次号</param>
        /// <returns>生产计划信息</returns>
        Task<PlanInfo> FindByCvtTimeNoAsync(string cvtTimeNo);

        /// <summary>
        /// 获取正常状态的生产计划列表
        /// </summary>
        /// <returns>生产计划列表</returns>
        Task<List<PlanInfo>> GetActivePlansAsync();
        
        /// <summary>
        /// 条件查询生产计划分页列表
        /// </summary>
        /// <param name="skipCount">跳过数量</param>
        /// <param name="maxResultCount">最大返回数量</param>
        /// <param name="keyword">关键词</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="isCompleted">是否完成</param>
        /// <param name="itemTag">项目标签</param>
        /// <returns>分页结果</returns>
        Task<(List<PlanInfo> Items, long TotalCount)> GetPlanInfoPagedListAsync(
            int skipCount,
            int maxResultCount,
            string? keyword = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            bool? isCompleted = null,
            string? itemTag = null);
    }
}