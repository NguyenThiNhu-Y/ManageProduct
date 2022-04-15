using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ManageProduct.Banners
{
    public interface IBannerAppService: IApplicationService
    {
        Task<PagedResultDto<BannerDto>> GetListAsync(GetBannerInput input);
        Task<BannerDto> CreateAsync(CreateOrUpdateBannerDto input);

        Task<BannerDto> UpdateAsync(Guid id, CreateOrUpdateBannerDto input);

        Task<BannerDto> GetAsync(Guid id);

        Task DeleteAsync(Guid Id);

        Task ChangAllSetBanner(Guid Id);

        Task<BannerDto> GetBanner();
    }
}
