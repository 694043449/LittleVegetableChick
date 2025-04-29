using BOFService.Domain.Entities;
using BOFService.Domain.Repositories;
using Volo.Abp.DependencyInjection;
using Yi.Framework.SqlSugarCore.Abstractions;
using Yi.Framework.SqlSugarCore.Repositories;

namespace BOFService.SqlSugarCore.Repositories
{
    /// <summary>
    /// 合金信息仓储实现
    /// </summary>
    public class AlloyInfoRepository : SqlSugarRepository<AlloyInfo, Guid>, IAlloyInfoRepository, ITransientDependency
    {
        public AlloyInfoRepository(ISugarDbContextProvider<ISqlSugarDbContext> sugarDbContextProvider)
            : base(sugarDbContextProvider)
        {
        }

        /// <summary>
        /// 获取所有正常合金信息，按创建日期升序排列
        /// </summary>
        /// <returns>合金信息列表</returns>
        public async Task<List<AlloyInfo>> GetNormalAlloyInfoListAsync()
        {
            return await _DbQueryable
                .Where(a => a.ItemTag == "n" && a.IsDeleted == false)
                .OrderBy(a => a.CreateTime)
                .ToListAsync();
        }
    }
} 