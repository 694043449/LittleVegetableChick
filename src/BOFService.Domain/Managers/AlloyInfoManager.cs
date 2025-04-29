using BOFService.Domain.Entities;
using BOFService.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BOFService.Domain.Managers
{
    /// <summary>
    /// 合金信息管理器 - 处理合金信息相关的核心业务逻辑
    /// </summary>
    public class AlloyInfoManager : DomainService
    {
        private readonly IAlloyInfoRepository _alloyInfoRepository;

        public AlloyInfoManager(IAlloyInfoRepository alloyInfoRepository)
        {
            _alloyInfoRepository = alloyInfoRepository;
        }

        /// <summary>
        /// 获取所有正常合金信息，按创建日期升序排列
        /// </summary>
        /// <returns>合金信息列表</returns>
        public async Task<List<AlloyInfo>> GetAlloyInfoListAsync()
        {
            return await _alloyInfoRepository.GetNormalAlloyInfoListAsync();
        }
    }
} 