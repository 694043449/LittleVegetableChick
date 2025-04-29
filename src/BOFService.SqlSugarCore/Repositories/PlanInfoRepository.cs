using BOFService.Domain.Entities;
using BOFService.Domain.Repositories;
using Volo.Abp.DependencyInjection;
using Yi.Framework.SqlSugarCore.Abstractions;
using Yi.Framework.SqlSugarCore.Repositories;

namespace BOFService.SqlSugarCore.Repositories
{
    /// <summary>
    /// 钢铁生产计划仓储实现
    /// </summary>
    public class PlanInfoRepository : SqlSugarRepository<PlanInfo, Guid>, IPlanInfoRepository, ITransientDependency
    {
        public PlanInfoRepository(ISugarDbContextProvider<ISqlSugarDbContext> sugarDbContextProvider) : base(
            sugarDbContextProvider)
        {
        }

        /// <summary>
        /// 根据计划号获取生产计划
        /// </summary>
        public async Task<PlanInfo> FindByPlanNoAsync(string planNo)
        {
            return await _DbQueryable
                .Where(p => p.PlanNo == planNo)
                .FirstAsync();
        }

        /// <summary>
        /// 根据炉次号获取生产计划
        /// </summary>
        public async Task<PlanInfo> FindByCvtTimeNoAsync(string cvtTimeNo)
        {
            return await _DbQueryable
                .Where(p => p.CvtTimeNo == cvtTimeNo)
                .FirstAsync();
        }

        /// <summary>
        /// 获取正常状态的生产计划列表
        /// </summary>
        public async Task<List<PlanInfo>> GetActivePlansAsync()
        {
            return await _DbQueryable
                .Where(p => p.IsDeleted == false && p.ItemTag == "n")
                .ToListAsync();
        }

        /// <summary>
        /// 条件查询生产计划分页列表
        /// </summary>
        public async Task<(List<PlanInfo> Items, long TotalCount)> GetPlanInfoPagedListAsync(
            int skipCount,
            int maxResultCount,
            string keyword = null,
            DateTime? startTime = null,
            DateTime? endTime = null,
            bool? isCompleted = null,
            string itemTag = null)
        {
            // 构建查询条件
            var query = _DbQueryable.Where(p => !p.IsDeleted);

            // 根据标签筛选
            if (!string.IsNullOrWhiteSpace(itemTag))
            {
                query = query.Where(p => p.ItemTag == itemTag);
            }

            // 根据是否完成筛选
            if (isCompleted.HasValue)
            {
                query = query.Where(p => p.IsComplete == isCompleted.Value);
            }

            // 时间范围筛选
            if (startTime.HasValue)
            {
                query = query.Where(p => p.CreationTime >= startTime.Value);
            }

            if (endTime.HasValue)
            {
                query = query.Where(p => p.CreationTime <= endTime.Value);
            }

            // 关键词搜索 (搜索多个字段)
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(p =>
                    p.PlanNo.Contains(keyword) ||
                    p.CvtTimeNo.Contains(keyword) ||
                    p.StlCode.Contains(keyword) ||
                    p.StlTypeDescription.Contains(keyword));
            }

            // 获取总记录数
            var totalCount = await query.CountAsync();

            // 获取分页数据
            var items = await query
                .OrderByDescending(p => p.CreateTime)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}