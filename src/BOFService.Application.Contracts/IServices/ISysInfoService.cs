using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BOFService.Application.Contracts.DTOs.SysInfo;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;

namespace BOFService.Application.Contracts.IServices
{
    /// <summary>
    /// 系统配置服务接口
    /// </summary>
    public interface ISysInfoService : IApplicationService
    {
        /// <summary>
        /// 获取所有系统配置（仅返回KeyName和KeyValue字段）
        /// </summary>
        /// <returns>系统配置列表</returns>
        Task<List<GetKeyValueSysInfoOutputDto>> GetSysInfoListAsync();

        /// <summary>
        /// 批量更新系统配置
        /// </summary>
        /// <param name="input">系统配置更新输入列表</param>
        Task UpdateByKeyNameAsync(List<UpdateSysInfoInputDto> input);
    }
}