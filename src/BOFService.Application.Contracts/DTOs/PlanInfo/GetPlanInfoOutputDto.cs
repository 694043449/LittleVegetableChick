using Volo.Abp.Application.Dtos;

namespace BOFService.Application.Contracts.DTOs.PlanInfo
{
    /// <summary>
    /// 钢铁生产计划DTO
    /// </summary>
    public class GetPlanInfoOutputDto : EntityDto<Guid>
    {
        /// <summary>
        /// 计划号
        /// </summary>
        public string PlanNo { get; set; }

        /// <summary>
        /// 炉次号
        /// </summary>
        public string CvtTimeNo { get; set; }

        /// <summary>
        /// 班别
        /// </summary>
        public string TeamType { get; set; }

        /// <summary>
        /// 班次
        /// </summary>
        public string TeamNo { get; set; }

        /// <summary>
        /// 钢种ID
        /// </summary>
        public string StlCode { get; set; }

        /// <summary>
        /// 钢种描述
        /// </summary>
        public string StlTypeDescription { get; set; }

        /// <summary>
        /// 行程代码
        /// </summary>
        public string TravelCode { get; set; }

        /// <summary>
        /// 目标钢水量
        /// </summary>
        public decimal? TgtLqdStlWgt { get; set; }

        /// <summary>
        /// 铸机号
        /// </summary>
        public string ChamberNo { get; set; }

        /// <summary>
        /// 浇次号
        /// </summary>
        public string CastNo { get; set; }

        /// <summary>
        /// 浇次顺序
        /// </summary>
        public int? CastOrder { get; set; }

        /// <summary>
        /// 炉龄
        /// </summary>
        public int? CvtAge { get; set; }

        /// <summary>
        /// BOF预计开始时间
        /// </summary>
        public DateTime? BofPdtBgnTime { get; set; }

        /// <summary>
        /// BOF预计结束时间
        /// </summary>
        public DateTime? BofPdtEndTime { get; set; }

        /// <summary>
        /// CC预计开始时间
        /// </summary>
        public DateTime? CcPdtBgnTime { get; set; }

        /// <summary>
        /// CC预计结束时间
        /// </summary>
        public DateTime? CcPdtEndTime { get; set; }

        /// <summary>
        /// RF预计开始时间
        /// </summary>
        public DateTime? RfPdtBgnTime { get; set; }

        /// <summary>
        /// RF预计结束时间
        /// </summary>
        public DateTime? RfPdtEndTime { get; set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool? IsComplete { get; set; }

        /// <summary>
        /// 数据来源：2二级；3三级
        /// </summary>
        public int? DataFrom { get; set; }

        /// <summary>
        /// 项目标签：n正常；d删除；r未启用
        /// </summary>
        public string ItemTag { get; set; }
    }
} 