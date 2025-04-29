using System;
using System.Threading.Tasks;
using BOFService.Domain.Entities;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace BOFService.Domain.Repositories
{
    /// <summary>
    /// 用户仓储接口
    /// </summary>
    public interface IUserRepository : ISqlSugarRepository<UserInfo>
    {
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户信息</returns>
        Task<UserInfo> FindByUserNameAsync(string userName);

        /// <summary>
        /// 根据用户名获取未被删除的用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户信息</returns>
        Task<UserInfo> FindActiveByUserNameAsync(string userName);
    }
} 