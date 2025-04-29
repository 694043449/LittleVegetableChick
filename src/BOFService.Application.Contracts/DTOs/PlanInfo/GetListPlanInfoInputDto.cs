using System;
using Volo.Abp.Application.Dtos;

namespace BOFService.Application.Contracts.DTOs.PlanInfo
{
    /// <summary>
    /// 钢铁生产计划查询输入DTO
    /// </summary>
    public class GetListPlanInfoInputDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 搜索关键词（计划号，炉次号，材质代码，钢种描述）
        /// </summary>
        public string? Keyword { get; set; }

        /// <summary>
        /// 时间范围-开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 时间范围-结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 时间查询类型
        ///  1 = 今天, 2 = 近三天, 3 = 近一周, 4 = 近一个月, 5 = 全部
        /// </summary>
        public int? TimeRangeType { get; set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool? IsCompleted { get; set; }

        /// <summary>
        /// 查询标签 n=正常 d=删除 r=未启用
        /// </summary>
        public string ItemTag { get; set; } = "n";
    }
} 