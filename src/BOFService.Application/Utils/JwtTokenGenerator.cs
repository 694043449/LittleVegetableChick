using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BOFService.Domain.Entities;
using BOFService.Domain.Shared.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp.DependencyInjection;

namespace BOFService.Application.Utils
{
    /// <summary>
    /// JWT令牌生成器
    /// </summary>
    /// <remarks>
    /// 使用Options模式管理配置，使代码更加易于测试和维护
    /// </remarks>
    public class JwtTokenGenerator : ITransientDependency
    {
        private readonly JwtOptions _jwtOptions;

        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        /// <summary>
        /// 生成JWT令牌
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <returns>JWT令牌</returns>
        public string GenerateToken(UserInfo userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Id.ToString()),
                new Claim(ClaimTypes.Name, userInfo.UserName),
                new Claim("RoleId", userInfo.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtOptions.ExpiresMinuteTime),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
} 