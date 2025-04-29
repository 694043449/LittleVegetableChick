using BOFService.Application.Contracts.DTOs.Auth;
using Volo.Abp.Application.Services;

namespace BOFService.Application.Contracts.Services
{
    /// <summary>
    /// 认证服务接口
    /// </summary>
    public interface IAuthService : IApplicationService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="input">登录请求</param>
        /// <returns>登录结果</returns>
        Task<LoginOutputDto> LoginAsync(LoginInputDto input);
    }
} 