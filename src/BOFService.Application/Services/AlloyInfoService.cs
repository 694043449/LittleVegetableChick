using BOFService.Application.Contracts.DTOs.AlloyInfo;
using BOFService.Application.Contracts.IServices;
using BOFService.Domain.Entities;
using BOFService.Domain.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Yi.Framework.Ddd.Application;

namespace BOFService.Application.Services
{
    /// <summary>
    /// 合金信息服务实现
    /// </summary>
    [Authorize]
    public class AlloyInfoService : 
        YiCrudAppService<
            AlloyInfo, 
            GetAlloyInfoOutputDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateAlloyInfoDto,
            CreateUpdateAlloyInfoDto>, 
        IAlloyInfoService
    {
        private readonly AlloyInfoManager _alloyInfoManager;

        public AlloyInfoService(
            IRepository<AlloyInfo, Guid> repository,
            AlloyInfoManager alloyInfoManager)
            : base(repository)
        {
            _alloyInfoManager = alloyInfoManager;
        }

        /// <summary>
        /// 获取所有正常合金信息，按创建日期升序排列
        /// </summary>
        /// <returns>合金信息列表</returns>
        [HttpGet("alloyinfo/getList")]
        public async Task<List<GetAlloyInfoOutputDto>> GetAlloyInfoListAsync()
        {
            // 查询合金信息
            var alloyInfos = await _alloyInfoManager.GetAlloyInfoListAsync();
            
            // 映射到输出DTO
            return await MapToGetListOutputDtosAsync(alloyInfos);
        }
    }
} 