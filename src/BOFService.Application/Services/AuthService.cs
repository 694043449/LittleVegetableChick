using BOFService.Application.Contracts.DTOs.Auth;
using BOFService.Application.Contracts.Services;
using BOFService.Application.Utils;
using BOFService.Domain.Managers;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace BOFService.Application.Services
{
    /// <summary>
    /// 认证服务实现
    /// </summary>
    public class AuthService : ApplicationService, IAuthService
    {
        private readonly JwtTokenGenerator _tokenGenerator;
        private readonly UserManager _userManager;

        public AuthService(UserManager userManager, JwtTokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="input">登录请求</param>
        /// <returns>登录结果</returns>
        [AllowAnonymous]
        public async Task<LoginOutputDto> LoginAsync(LoginInputDto input)
        {
            // 使用UserManager验证用户凭证
            var user = await _userManager.ValidateUserCredentialsAsync(input.UserName, input.Password);

            // 生成Token
            var token = _tokenGenerator.GenerateToken(user);

            // 返回登录结果
            return new LoginOutputDto
            {
                Id = user.Id,
                UserName = user.UserName,
                WorkerName = user.WorkerName,
                RoleId = user.RoleId,
                PartName = user.PartName,
                Token = token
            };
        }
    }
} 