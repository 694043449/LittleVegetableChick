using SqlSugar;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace BOFService.Domain.Entities
{
    /// <summary>
    /// 钢种元素表
    /// </summary>
    [SugarTable("t_steel_element")]
    public class SteelElement : Entity<Guid>, ISoftDelete, IAuditedObject
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public override Guid Id { get; protected set; }

        /// <summary>
        /// 钢种编号
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public Guid? SteelId { get; set; }

        /// <summary>
        /// 元素名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string ElementName { get; set; }

        /// <summary>
        /// 元素编号
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? ElementOrder { get; set; }

        /// <summary>
        /// 元素最大值
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? ElementMax { get; set; }

        /// <summary>
        /// 元素标准值
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? ElementStd { get; set; }

        /// <summary>
        /// 元素最小值
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? ElementMin { get; set; }

        /// <summary>
        /// 元素终点残余值
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? ElementRdl { get; set; }

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