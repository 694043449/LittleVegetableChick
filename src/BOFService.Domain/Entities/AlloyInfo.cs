using SqlSugar;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace BOFService.Domain.Entities
{
    /// <summary>
    /// 合金信息表
    /// </summary>
    [SugarTable("t_alloy_info")]
    public class AlloyInfo : Entity<Guid>, ISoftDelete, IAuditedObject
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public override Guid Id { get; protected set; }

        /// <summary>
        /// 合金编号
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string AlyNo { get; set; }

        /// <summary>
        /// 合金名称
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string AlyName { get; set; }

        /// <summary>
        /// 合金工厂
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string AlyFactory { get; set; }

        /// <summary>
        /// 合金价格
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? AlyPrice { get; set; }

        /// <summary>
        /// 合金类型
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string AlyType { get; set; }

        /// <summary>
        /// 预加率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? AlyPreAddRate { get; set; }

        /// <summary>
        /// 固定量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? AlyFixWgt { get; set; }

        /// <summary>
        /// C含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? CContent { get; set; }

        /// <summary>
        /// C收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? CGetRate { get; set; }

        /// <summary>
        /// Si含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? SiContent { get; set; }

        /// <summary>
        /// Si收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? SiGetRate { get; set; }

        /// <summary>
        /// Mn含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? MnContent { get; set; }

        /// <summary>
        /// Mn收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? MnGetRate { get; set; }

        /// <summary>
        /// P含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? PContent { get; set; }

        /// <summary>
        /// P收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? PGetRate { get; set; }

        /// <summary>
        /// S含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? SContent { get; set; }

        /// <summary>
        /// S收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? SGetRate { get; set; }

        /// <summary>
        /// Cr含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? CrContent { get; set; }

        /// <summary>
        /// Cr收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? CrGetRate { get; set; }

        /// <summary>
        /// Mo含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? MoContent { get; set; }

        /// <summary>
        /// Mo收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? MoGetRate { get; set; }

        /// <summary>
        /// V含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? VContent { get; set; }

        /// <summary>
        /// V收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? VGetRate { get; set; }

        /// <summary>
        /// Nb含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? NbContent { get; set; }

        /// <summary>
        /// Nb收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? NbGetRate { get; set; }

        /// <summary>
        /// Ti含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? TiContent { get; set; }

        /// <summary>
        /// Ti收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? TiGetRate { get; set; }

        /// <summary>
        /// Ni含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? NiContent { get; set; }

        /// <summary>
        /// Ni收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? NiGetRate { get; set; }

        /// <summary>
        /// Ba含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? BaContent { get; set; }

        /// <summary>
        /// Ba收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? BaGetRate { get; set; }

        /// <summary>
        /// B含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? BContent { get; set; }

        /// <summary>
        /// B收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? BGetRate { get; set; }

        /// <summary>
        /// Al含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? AlContent { get; set; }

        /// <summary>
        /// Al收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? AlGetRate { get; set; }

        /// <summary>
        /// W含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? WContent { get; set; }

        /// <summary>
        /// W收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? WGetRate { get; set; }

        /// <summary>
        /// Cu含量
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? CuContent { get; set; }

        /// <summary>
        /// Cu收得率
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public decimal? CuGetRate { get; set; }

        /// <summary>
        /// 数据标记(n正常；d删除；r未启用)
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