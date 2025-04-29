using BOFService.Domain.Entities;
using BOFService.Domain.Repositories;
using Volo.Abp.DependencyInjection;
using Yi.Framework.SqlSugarCore.Abstractions;
using Yi.Framework.SqlSugarCore.Repositories;

namespace BOFService.SqlSugarCore.Repositories
{
    /// <summary>
    /// 用户仓储实现
    /// </summary>
    public class UserRepository : SqlSugarRepository<UserInfo>, IUserRepository, ITransientDependency
    {
        public UserRepository(ISugarDbContextProvider<ISqlSugarDbContext> sugarDbContextProvider) : base(sugarDbContextProvider)
        {
        }
        
        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        public async Task<UserInfo> FindByUserNameAsync(string userName)
        {
            return await _DbQueryable
                .Where(u => u.UserName == userName)
                .FirstAsync();
        }

        /// <summary>
        /// 根据用户名获取未被删除的用户信息
        /// </summary>
        public async Task<UserInfo> FindActiveByUserNameAsync(string userName)
        {
            return await _DbQueryable
                .Where(u => u.UserName == userName && u.IsDeleted == false)
                .FirstAsync();
        }
    }
} 