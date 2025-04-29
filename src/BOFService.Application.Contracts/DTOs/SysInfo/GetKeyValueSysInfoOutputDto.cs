using System;
using Volo.Abp.Application.Dtos;

namespace BOFService.Application.Contracts.DTOs.SysInfo
{
    /// <summary>
    /// 系统配置数据传输对象
    /// </summary>
    public class GetKeyValueSysInfoOutputDto : EntityDto<Guid>
    {
        /// <summary>
        /// 数据标识
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// 数据值
        /// </summary>
        public string KeyValue { get; set; }
    }
} 