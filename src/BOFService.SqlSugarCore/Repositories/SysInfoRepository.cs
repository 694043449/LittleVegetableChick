using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BOFService.Domain.Entities;
using BOFService.Domain.Repositories;
using SqlSugar;
using Volo.Abp.DependencyInjection;
using Yi.Framework.SqlSugarCore.Abstractions;
using Yi.Framework.SqlSugarCore.Repositories;

namespace BOFService.SqlSugarCore.Repositories
{
    /// <summary>
    /// 系统配置仓储实现
    /// </summary>
    public class SysInfoRepository : SqlSugarRepository<SysInfo, Guid>, ISysInfoRepository, ITransientDependency
    {
        public SysInfoRepository(ISugarDbContextProvider<ISqlSugarDbContext> sugarDbContextProvider)
            : base(sugarDbContextProvider)
        {
        }

        /// <summary>
        /// 获取所有系统配置的KeyName和KeyValue
        /// </summary>
        /// <returns>系统配置KeyName和KeyValue列表</returns>
        public async Task<List<SysInfo>> GetKeyAndValueListAsync()
        {
            // 先获取完整的实体列表，然后只返回需要的字段
            var sysInfoList = await _DbQueryable
                .Where(s => s.IsDeleted == false)
                .ToListAsync();
            return sysInfoList;
        }

        /// <summary>
        /// 根据KeyName查询系统配置
        /// </summary>
        /// <param name="keyName">配置键名</param>
        /// <returns>系统配置实体，如果不存在则返回null</returns>
        public async Task<SysInfo> GetByKeyNameAsync(string keyName)
        {
            // 使用First方法，如果结果为空会返回null而不是抛出异常
            var result = await _DbQueryable
                .Where(s => s.KeyName == keyName && s.IsDeleted == false)
                .ToListAsync();
                
            return result.FirstOrDefault();
        }
    }
}