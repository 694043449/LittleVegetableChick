namespace BOFService.Domain.Shared.Constants
{
    /// <summary>
    /// 错误代码常量
    /// </summary>
    public static class ErrorCodes
    {
        /// <summary>
        /// 通用错误
        /// </summary>
        public static class Common
        {
            /// <summary>
            /// 实体已存在
            /// </summary>
            public const string EntityAlreadyExists = "Common:EntityAlreadyExists";
        }

        /// <summary>
        /// 用户相关错误
        /// </summary>
        public static class User
        {
            /// <summary>
            /// 用户名或密码不正确
            /// </summary>
            public const string InvalidCredentials = "User:InvalidCredentials";

            /// <summary>
            /// 用户不存在
            /// </summary>
            public const string UserNotFound = "User:UserNotFound";

            /// <summary>
            /// 用户已被禁用
            /// </summary>
            public const string UserDisabled = "User:UserDisabled";

            /// <summary>
            /// 用户已锁定
            /// </summary>
            public const string UserLocked = "User:UserLocked";
        }

        /// <summary>
        /// 权限相关错误
        /// </summary>
        public static class Permission
        {
            /// <summary>
            /// 无访问权限
            /// </summary>
            public const string AccessDenied = "Permission:AccessDenied";
        }

        /// <summary>
        /// 系统相关错误
        /// </summary>
        public static class System
        {
            /// <summary>
            /// 内部服务器错误
            /// </summary>
            public const string InternalServerError = "System:InternalServerError";
        }

        /// <summary>
        /// 系统配置相关错误
        /// </summary>
        public static class SysInfo
        {
            /// <summary>
            /// 系统配置不存在
            /// </summary>
            public const string NotFound = "SysInfo:NotFound";
        }

        /// <summary>
        /// 计划信息相关错误
        /// </summary>
        public static class PlanInfo
        {
        }
    }
} 