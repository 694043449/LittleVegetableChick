using SqlSugar;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace BOFService.Domain.Entities
{
    /// <summary>
    /// 系统配置表
    /// </summary>
    [SugarTable("t_sys_info")]
    public class SysInfo : Entity<Guid>, ISoftDelete, IAuditedObject
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public override Guid Id { get; protected set; }

        /// <summary>
        /// 数据标识
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false)]
        public string KeyName { get; set; }

        /// <summary>
        /// 数据值
        /// </summary>
        [SugarColumn(Length = 500, IsNullable = true)]
        public string KeyValue { get; set; }

        /// <summary>
        /// 数据组
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string KeyGroup { get; set; }

        /// <summary>
        /// 数据描述
        /// </summary>
        [SugarColumn(Length = 500, IsNullable = true)]
        public string KeyMemo { get; set; }

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