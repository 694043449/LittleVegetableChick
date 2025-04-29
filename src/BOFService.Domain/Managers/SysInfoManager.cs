using BOFService.Domain.Entities;
using BOFService.Domain.Repositories;
using BOFService.Domain.Shared.Constants;
using Volo.Abp.Domain.Services;

namespace BOFService.Domain.Managers
{
    /// <summary>
    /// 系统配置管理器 - 处理系统配置相关的核心业务逻辑
    /// </summary>
    public class SysInfoManager : DomainService
    {
        private readonly ISysInfoRepository _sysInfoRepository;

        public SysInfoManager(ISysInfoRepository sysInfoRepository)
        {
            _sysInfoRepository = sysInfoRepository;
        }

        /// <summary>
        /// 批量更新系统配置
        /// </summary>
        /// <param name="keyValuePairs">系统配置键值对列表</param>
        public async Task BatchUpdateSysInfoAsync(List<KeyValuePair<string, string>> keyValuePairs)
        {
            // 检查输入列表是否为空
            if (keyValuePairs.Count == 0)
            {
                return;
            }

            // 循环处理每个更新项
            foreach (var item in keyValuePairs)
            {
                await UpdateSysInfoByKeyNameAsync(item.Key, item.Value);
            }
        }

        /// <summary>
        /// 根据KeyName更新系统配置
        /// </summary>
        /// <param name="keyName">配置键名</param>
        /// <param name="keyValue">配置值</param>
        /// <returns>更新后的系统配置实体</returns>
        public async Task<SysInfo> UpdateSysInfoByKeyNameAsync(string keyName, string keyValue)
        {
            // 根据KeyName查询系统配置
            var sysInfo = await _sysInfoRepository.GetByKeyNameAsync(keyName);

            // 验证系统配置是否存在
            if (sysInfo == null)
            {
                throw new BusinessException(
                    ErrorCodes.SysInfo.NotFound,
                    $"{ErrorMessages.SysInfo.NotFound}：{keyName}");
            }

            // 更新配置值
            sysInfo.KeyValue = keyValue;
            sysInfo.EditTime = DateTime.Now;

            // 保存更新
            await _sysInfoRepository.UpdateAsync(sysInfo);

            return sysInfo;
        }
    }
} 