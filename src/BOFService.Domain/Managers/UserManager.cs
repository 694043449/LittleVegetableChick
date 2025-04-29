using BOFService.Domain.Entities;
using BOFService.Domain.Repositories;
using BOFService.Domain.Shared.Constants;
using Volo.Abp.Domain.Services;
using Yi.Framework.Core.Helper;

namespace BOFService.Domain.Managers
{
    /// <summary>
    /// 用户管理器 - 处理用户相关的核心业务逻辑
    /// </summary>
    public class UserManager : DomainService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 验证用户凭证
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码（明文）</param>
        /// <returns>验证通过的用户信息</returns>
        /// <exception cref="UserFriendlyException">验证失败时抛出异常</exception>
        public async Task<UserInfo> ValidateUserCredentialsAsync(string userName, string password)
        {
            // 查询用户信息
            var user = await _userRepository.FindActiveByUserNameAsync(userName);

            // 验证用户是否存在
            if (user == null)
            {
                throw new BusinessException(
                    ErrorCodes.User.InvalidCredentials,
                    ErrorMessages.User.InvalidCredentials);
            }

            // 验证密码（使用MD5加密后比较）
            if (user.UserPassword != MD5Helper.MD5Encrypt32(password))
            {
                throw new BusinessException(
                    ErrorCodes.User.InvalidCredentials,
                    ErrorMessages.User.InvalidCredentials);
            }

            // 验证用户状态
            if (user.UserCondition != 1)
            {
                throw new BusinessException(
                    ErrorCodes.User.UserDisabled,
                    ErrorMessages.User.UserDisabled);
            }

            return user;
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户信息</returns>
        public async Task<UserInfo> GetUserByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new BusinessException(
                    ErrorCodes.User.UserNotFound,
                    ErrorMessages.User.UserNotFound);
            }
            return user;
        }

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户信息</returns>
        public async Task<UserInfo> GetUserByNameAsync(string userName)
        {
            var user = await _userRepository.FindActiveByUserNameAsync(userName);
            if (user == null)
            {
                throw new BusinessException(
                    ErrorCodes.User.UserNotFound,
                    ErrorMessages.User.UserNotFound);
            }
            return user;
        }
    }
} 