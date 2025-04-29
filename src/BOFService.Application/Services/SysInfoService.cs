using BOFService.Application.Contracts.DTOs.SysInfo;
using BOFService.Application.Contracts.IServices;
using BOFService.Domain.Entities;
using BOFService.Domain.Managers;
using BOFService.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yi.Framework.Ddd.Application;

namespace BOFService.Application.Services
{
    /// <summary>
    /// 系统配置服务实现
    /// </summary>
    [Authorize]
    public class SysInfoService : YiCrudAppService<SysInfo, GetKeyValueSysInfoOutputDto, Guid>, ISysInfoService
    {
        private readonly SysInfoManager _sysInfoManager;
        private readonly ISysInfoRepository _sysInfoRepository;

        public SysInfoService(
            ISysInfoRepository sysInfoRepository,
            SysInfoManager sysInfoManager)
            : base(sysInfoRepository)
        {
            _sysInfoRepository = sysInfoRepository;
            _sysInfoManager = sysInfoManager;
        }

        /// <summary>
        /// 获取所有系统配置（仅返回KeyName和KeyValue字段）
        /// </summary>
        /// <returns>系统配置列表</returns>
        [HttpGet("sysinfo/getList")]
        public async Task<List<GetKeyValueSysInfoOutputDto>> GetSysInfoListAsync()
        {
            var sysInfoList = await _sysInfoRepository.GetKeyAndValueListAsync();
            
            return await MapToGetListOutputDtosAsync(sysInfoList);
        }

        /// <summary>
        /// 根据KeyName批量更新系统配置的KeyValue
        /// </summary>
        /// <param name="input">系统配置更新输入列表</param>
        [RemoteService(IsEnabled = true)]
        [HttpPost("sysinfo/update")]
        public async Task UpdateByKeyNameAsync(List<UpdateSysInfoInputDto> input)
        {
            var keyValuePairs = input
                .Select(item => new KeyValuePair<string, string>(item.KeyName, item.KeyValue))
                .ToList();

            // 批量更新
            await _sysInfoManager.BatchUpdateSysInfoAsync(keyValuePairs);
        }
    }
} 