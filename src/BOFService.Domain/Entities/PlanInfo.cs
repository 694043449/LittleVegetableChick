using SqlSugar;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace BOFService.Domain.Entities
{
    /// <summary>
    /// 钢铁生产计划表
    /// </summary>
    [SugarTable("t_plan_info")]
    public class PlanInfo : Entity<Guid>, ISoftDelete, IAuditedObject
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public override Guid Id { get; protected set; }

        /// <summary>
        /// 计划号
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = false)]
        public string PlanNo { get; set; }

        /// <summary>
        /// 炉次号
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = false)]
        public string CvtTimeNo { get; set; }

        /// <summary>
        /// 班别
        /// </summary>
        [SugarColumn(Length = 20, IsNullable = true)]
        public string TeamType { get; set; }

        /// <summary>
        /// 班次
        /// </summary>
        [SugarColumn(Length = 20, IsNullable = true)]
        public string TeamNo { get; set; }

        /// <summary>
        /// 钢种ID
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string StlCode { get; set; }

        /// <summary>
        /// 钢种描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string StlTypeDescription { get; set; }

        /// <summary>
        /// 行程代码
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string TravelCode { get; set; }

        /// <summary>
        /// 目标钢水量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? TgtLqdStlWgt { get; set; }

        /// <summary>
        /// 铸机号
        /// </summary>
        [SugarColumn(Length = 20, IsNullable = true)]
        public string ChamberNo { get; set; }

        /// <summary>
        /// 浇次号
        /// </summary>
        [SugarColumn(Length = 20, IsNullable = true)]
        public string CastNo { get; set; }

        /// <summary>
        /// 浇次顺序
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? CastOrder { get; set; }

        /// <summary>
        /// 炉龄
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? CvtAge { get; set; }

        /// <summary>
        /// BOF预计开始时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? BofPdtBgnTime { get; set; }

        /// <summary>
        /// BOF预计结束时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? BofPdtEndTime { get; set; }

        /// <summary>
        /// CC预计开始时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? CcPdtBgnTime { get; set; }

        /// <summary>
        /// CC预计结束时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? CcPdtEndTime { get; set; }

        /// <summary>
        /// RF预计开始时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? RfPdtBgnTime { get; set; }

        /// <summary>
        /// RF预计结束时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? RfPdtEndTime { get; set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsComplete { get; set; }

        /// <summary>
        /// 数据来源：2二级；3三级
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? DataFrom { get; set; }

        /// <summary>
        /// 项目标签：n正常；d删除；r未启用
        /// </summary>
        [SugarColumn(Length = 10, IsNullable = true)]
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

        /// <summary>
        /// 创建时间（审计字段）
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 创建者ID（审计字段）
        /// </summary>
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// 最后修改时间（审计字段）
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 最后修改者ID（审计字段）
        /// </summary>
        public Guid? LastModifierId { get; set; }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
} 