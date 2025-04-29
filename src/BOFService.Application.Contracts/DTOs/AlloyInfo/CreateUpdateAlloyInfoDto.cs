using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace BOFService.Application.Contracts.DTOs.AlloyInfo
{
    /// <summary>
    /// 创建或更新合金信息DTO
    /// </summary>
    public class CreateUpdateAlloyInfoDto : IEntityDto
    {
        /// <summary>
        /// 合金编号
        /// </summary>
        [StringLength(100)]
        public string AlyNo { get; set; }

        /// <summary>
        /// 合金名称
        /// </summary>
        [StringLength(100)]
        public string AlyName { get; set; }

        /// <summary>
        /// 合金工厂
        /// </summary>
        [StringLength(100)]
        public string AlyFactory { get; set; }

        /// <summary>
        /// 合金价格
        /// </summary>
        public decimal? AlyPrice { get; set; }

        /// <summary>
        /// 合金类型
        /// </summary>
        [StringLength(50)]
        public string AlyType { get; set; }

        /// <summary>
        /// 预加率
        /// </summary>
        public decimal? AlyPreAddRate { get; set; }

        /// <summary>
        /// 固定量
        /// </summary>
        public decimal? AlyFixWgt { get; set; }

        /// <summary>
        /// C含量
        /// </summary>
        public decimal? CContent { get; set; }

        /// <summary>
        /// C收得率
        /// </summary>
        public decimal? CGetRate { get; set; }

        /// <summary>
        /// Si含量
        /// </summary>
        public decimal? SiContent { get; set; }

        /// <summary>
        /// Si收得率
        /// </summary>
        public decimal? SiGetRate { get; set; }

        /// <summary>
        /// Mn含量
        /// </summary>
        public decimal? MnContent { get; set; }

        /// <summary>
        /// Mn收得率
        /// </summary>
        public decimal? MnGetRate { get; set; }

        /// <summary>
        /// P含量
        /// </summary>
        public decimal? PContent { get; set; }

        /// <summary>
        /// P收得率
        /// </summary>
        public decimal? PGetRate { get; set; }

        /// <summary>
        /// S含量
        /// </summary>
        public decimal? SContent { get; set; }

        /// <summary>
        /// S收得率
        /// </summary>
        public decimal? SGetRate { get; set; }

        /// <summary>
        /// Cr含量
        /// </summary>
        public decimal? CrContent { get; set; }

        /// <summary>
        /// Cr收得率
        /// </summary>
        public decimal? CrGetRate { get; set; }

        /// <summary>
        /// Mo含量
        /// </summary>
        public decimal? MoContent { get; set; }

        /// <summary>
        /// Mo收得率
        /// </summary>
        public decimal? MoGetRate { get; set; }

        /// <summary>
        /// V含量
        /// </summary>
        public decimal? VContent { get; set; }

        /// <summary>
        /// V收得率
        /// </summary>
        public decimal? VGetRate { get; set; }

        /// <summary>
        /// Nb含量
        /// </summary>
        public decimal? NbContent { get; set; }

        /// <summary>
        /// Nb收得率
        /// </summary>
        public decimal? NbGetRate { get; set; }

        /// <summary>
        /// Ti含量
        /// </summary>
        public decimal? TiContent { get; set; }

        /// <summary>
        /// Ti收得率
        /// </summary>
        public decimal? TiGetRate { get; set; }

        /// <summary>
        /// Ni含量
        /// </summary>
        public decimal? NiContent { get; set; }

        /// <summary>
        /// Ni收得率
        /// </summary>
        public decimal? NiGetRate { get; set; }

        /// <summary>
        /// Ba含量
        /// </summary>
        public decimal? BaContent { get; set; }

        /// <summary>
        /// Ba收得率
        /// </summary>
        public decimal? BaGetRate { get; set; }

        /// <summary>
        /// B含量
        /// </summary>
        public decimal? BContent { get; set; }

        /// <summary>
        /// B收得率
        /// </summary>
        public decimal? BGetRate { get; set; }

        /// <summary>
        /// Al含量
        /// </summary>
        public decimal? AlContent { get; set; }

        /// <summary>
        /// Al收得率
        /// </summary>
        public decimal? AlGetRate { get; set; }

        /// <summary>
        /// W含量
        /// </summary>
        public decimal? WContent { get; set; }

        /// <summary>
        /// W收得率
        /// </summary>
        public decimal? WGetRate { get; set; }

        /// <summary>
        /// Cu含量
        /// </summary>
        public decimal? CuContent { get; set; }

        /// <summary>
        /// Cu收得率
        /// </summary>
        public decimal? CuGetRate { get; set; }

        /// <summary>
        /// 数据标记(n正常；d删除；r未启用)
        /// </summary>
        [StringLength(10)]
        public string ItemTag { get; set; } = "n";
    }
} 