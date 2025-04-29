using SqlSugar;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace BOFService.Domain.Entities
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [SugarTable("t_user_info")]
    public class UserInfo : Entity<Guid>, ISoftDelete, IAuditedObject
    {
        /// <summary>
        /// 主键ID（雪花ID格式）
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public override Guid Id { get; protected set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = false)]
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false)]
        public string UserPassword { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public long RoleId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string PartName { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string WorkerName { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int UserCondition { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? EditTime { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? CreatorId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public Guid? LastModifierId { get; set; }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
} 