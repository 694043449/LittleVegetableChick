using SqlSugar;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace BOFService.Domain.Entities
{
    /// <summary>
    /// 合金方案表
    /// </summary>
    [SugarTable("t_project_info")]
    public class ProjectInfo : Entity<Guid>, ISoftDelete, IAuditedObject
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public override Guid Id { get; protected set; }

        /// <summary>
        /// 方案名称
        /// </summary>
        [SugarColumn(Length = 200, IsNullable = true)]
        public string ProjectName { get; set; }

        /// <summary>
        /// 方案类型
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true, ColumnDescription = "a合金；f熔剂")]
        public string ProjectType { get; set; }

        /// <summary>
        /// 数据标识
        /// </summary>
        [SugarColumn(Length = 10, IsNullable = true, ColumnDescription = "n正常；d删除；r未启用")]
        public string ItemTag { get; set; }

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