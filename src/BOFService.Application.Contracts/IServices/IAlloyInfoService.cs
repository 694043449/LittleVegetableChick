using BOFService.Application.Contracts.DTOs.AlloyInfo;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BOFService.Application.Contracts.IServices
{
    /// <summary>
    /// 合金信息服务接口
    /// </summary>
    public interface IAlloyInfoService : 
        ICrudAppService<
            GetAlloyInfoOutputDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAlloyInfoDto,
            CreateUpdateAlloyInfoDto>
    {
        /// <summary>
        /// 获取所有正常合金信息，按创建日期升序排列
        /// </summary>
        /// <returns>合金信息列表</returns>
        Task<List<GetAlloyInfoOutputDto>> GetAlloyInfoListAsync();
    }
} 