namespace BOFService.Application.Contracts.DTOs.Auth
{
    /// <summary>
    /// 用户登录响应DTO
    /// </summary>
    public class LoginOutputDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string WorkerName { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string PartName { get; set; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public string Token { get; set; }
    }
} 