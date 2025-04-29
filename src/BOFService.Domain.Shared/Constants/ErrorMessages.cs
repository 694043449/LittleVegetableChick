namespace BOFService.Domain.Shared.Constants
{
    /// <summary>
    /// 错误消息常量
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// 通用错误消息
        /// </summary>
        public static class Common
        {
            /// <summary>
            /// 实体已存在
            /// </summary>
            public const string EntityAlreadyExists = "{0}已存在";
        }

        /// <summary>
        /// 用户相关错误消息
        /// </summary>
        public static class User
        {
            /// <summary>
            /// 用户名或密码不正确
            /// </summary>
            public const string InvalidCredentials = "用户名或密码错误";

            /// <summary>
            /// 用户不存在
            /// </summary>
            public const string UserNotFound = "用户不存在";

            /// <summary>
            /// 用户已被禁用
            /// </summary>
            public const string UserDisabled = "用户已被禁用";

            /// <summary>
            /// 用户已锁定
            /// </summary>
            public const string UserLocked = "账户已锁定，请稍后再试";
        }

        /// <summary>
        /// 权限相关错误消息
        /// </summary>
        public static class Permission
        {
            /// <summary>
            /// 无访问权限
            /// </summary>
            public const string AccessDenied = "您没有权限执行此操作";
        }

        /// <summary>
        /// 系统相关错误消息
        /// </summary>
        public static class System
        {
            /// <summary>
            /// 内部服务器错误
            /// </summary>
            public const string InternalServerError = "系统内部错误，请稍后再试";
        }

        /// <summary>
        /// 系统配置相关错误消息
        /// </summary>
        public static class SysInfo
        {
            /// <summary>
            /// 系统配置不存在
            /// </summary>
            public const string NotFound = "系统配置不存在";
        }

        /// <summary>
        /// 计划信息相关错误消息
        /// </summary>
        public static class PlanInfo
        {
            /// <summary>
            /// 计划号已存在
            /// </summary>
            public const string PlanNoAlreadyExists = "计划号已存在";

            /// <summary>
            /// 炉次号已存在
            /// </summary>
            public const string CvtTimeNoAlreadyExists = "炉次号已存在";
        }
    }
} 