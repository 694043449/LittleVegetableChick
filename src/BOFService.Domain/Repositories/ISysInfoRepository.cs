using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BOFService.Domain.Entities;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace BOFService.Domain.Repositories
{
    /// <summary>
    /// 系统配置仓储接口
    /// </summary>
    public interface ISysInfoRepository : ISqlSugarRepository<SysInfo,Guid>
    {
        /// <summary>
        /// 获取所有系统配置的KeyName和KeyValue
        /// </summary>
        /// <returns>系统配置KeyName和KeyValue列表</returns>
        Task<List<SysInfo>> GetKeyAndValueListAsync();

        /// <summary>
        /// 根据KeyName查询系统配置
        /// </summary>
        /// <param name="keyName">配置键名</param>
        /// <returns>系统配置实体，如果不存在则返回null</returns>
        Task<SysInfo> GetByKeyNameAsync(string keyName);
    }
} 