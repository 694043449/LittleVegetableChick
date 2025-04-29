using SqlSugar;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace BOFService.Domain.Entities
{
    /// <summary>
    /// 钢种信息表
    /// </summary>
    [SugarTable("t_steel_info")]
    public class SteelInfo : Entity<Guid>, ISoftDelete, IAuditedObject
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public override Guid Id { get; protected set; }

        /// <summary>
        /// 材质代码
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = false)]
        public string StlTypeCode { get; set; }

        /// <summary>
        /// 钢种描述
        /// </summary>
        [SugarColumn(Length = 500, IsNullable = true)]
        public string StlTypeDcp { get; set; }

        /// <summary>
        /// 合金方案1
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public Guid? AlyProjectId1 { get; set; }

        /// <summary>
        /// 合金方案2
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public Guid? AlyProjectId2 { get; set; }

        /// <summary>
        /// 合金方案3
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public Guid? AlyProjectId3 { get; set; }

        /// <summary>
        /// 执行标准
        /// </summary>
        [SugarColumn(Length = 200, IsNullable = true)]
        public string StlTypeOptStd { get; set; }

        /// <summary>
        /// 工艺路径代码
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string StlTypeTchCode { get; set; }

        /// <summary>
        /// 标准收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? StdGetRate { get; set; }

        /// <summary>
        /// 标准铁水比
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? StdIronRate { get; set; }

        /// <summary>
        /// 标准出钢量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? StdStlOutWgt { get; set; }

        /// <summary>
        /// 标准冷却剂消耗量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? StdColdUseWgt { get; set; }

        /// <summary>
        /// 标准发热剂消耗量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? StdHotUseWgt { get; set; }

        /// <summary>
        /// 吹炼终点
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string BlowEnd { get; set; }

        /// <summary>
        /// 进站脱硫
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string StationOutS { get; set; }

        /// <summary>
        /// 废钢标准编号
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public Guid? ScrapId { get; set; }

        /// <summary>
        /// 温度标准编号
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public Guid? TmpId { get; set; }

        /// <summary>
        /// 吹炼模式编号
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public Guid? BlowModeId { get; set; }

        /// <summary>
        /// 钢渣标准编号
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public Guid? SlagId { get; set; }

        /// <summary>
        /// 数据标识（n正常；d删除；r未启用）
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