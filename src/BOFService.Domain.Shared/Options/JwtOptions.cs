namespace BOFService.Domain.Shared.Options
{
    /// <summary>
    /// JWT配置选项
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// 颁发者
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 受众
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 安全密钥
        /// </summary>
        public string SecurityKey { get; set; }

        /// <summary>
        /// 过期时间（分钟）
        /// </summary>
        public int ExpiresMinuteTime { get; set; }
    }
} 