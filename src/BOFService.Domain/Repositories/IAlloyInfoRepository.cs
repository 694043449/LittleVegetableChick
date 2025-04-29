using BOFService.Domain.Entities;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace BOFService.Domain.Repositories
{
    /// <summary>
    /// 合金信息仓储接口
    /// </summary>
    public interface IAlloyInfoRepository : ISqlSugarRepository<AlloyInfo, Guid>
    {
        /// <summary>
        /// 获取所有正常合金信息，按创建日期升序排列
        /// </summary>
        /// <returns>合金信息列表</returns>
        Task<List<AlloyInfo>> GetNormalAlloyInfoListAsync();
    }
} 