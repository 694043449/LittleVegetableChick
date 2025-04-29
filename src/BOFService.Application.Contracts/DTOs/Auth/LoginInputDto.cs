using System.ComponentModel.DataAnnotations;

namespace BOFService.Application.Contracts.DTOs.Auth
{
    /// <summary>
    /// 用户登录请求DTO
    /// </summary>
    public class LoginInputDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
} 