using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ManageProduct.Banners
{
    public class BannerAppService : ApplicationService, IBannerAppService
    {
        private readonly IBannerRepository _bannerRepository;
        public BannerAppService(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task ChangAllSetBanner(Guid Id)
        {
            var banners = await _bannerRepository.GetListAsync();
            var banner = await _bannerRepository.FindAsync(Id);
            if (!banner.SetBanner)
            {
                banner.SetBanner = true;
                await _bannerRepository.UpdateAsync(banner);
                foreach (var item in banners)
                {
                    if (item.Id != Id)
                    {
                        item.SetBanner = false;
                        await _bannerRepository.UpdateAsync(item);
                    }
                }
            }
            else
            {
                banner.SetBanner = false;
                await _bannerRepository.UpdateAsync(banner);
            }
            
        }

        public async Task<BannerDto> CreateAsync(CreateOrUpdateBannerDto input)
        {
            var banner = ObjectMapper.Map<CreateOrUpdateBannerDto, Banner>(input);
            banner.SetBanner = false;
            await _bannerRepository.InsertAsync(banner);
            //change setBanner 
            await ChangAllSetBanner(banner.Id);
            
            return ObjectMapper.Map<Banner, BannerDto>(banner);
        }

        public async Task DeleteAsync(Guid Id)
        {
            var banner = await _bannerRepository.FindAsync(Id);
            await _bannerRepository.DeleteAsync(banner);
        }

        public async Task<BannerDto> GetAsync(Guid id)
        {
            var banner = await _bannerRepository.FindAsync(id);
            return ObjectMapper.Map<Banner,BannerDto>(banner);
        }

        public async Task<BannerDto> GetBanner()
        {
            var banners = await _bannerRepository.GetListAsync();
            Banner itemLast = new Banner();
            foreach(var item in banners)
            {
                itemLast = item;
                if (item.SetBanner)
                    return ObjectMapper.Map<Banner,BannerDto>(item);
            }
            return ObjectMapper.Map<Banner, BannerDto>(itemLast);
        }

        public async Task<PagedResultDto<BannerDto>> GetListAsync(GetBannerInput input)
        {
            var count = await _bannerRepository.GetCountAsync(input.Filter, input.Name);
            var items = await _bannerRepository.GetListAsync(input.Filter, input.Name, input.Sorting, input.MaxResultCount, input.SkipCount);
            var itemsDto = ObjectMapper.Map<List<Banner>, List<BannerDto>>(items);
            int index = 1;
            foreach(var item in itemsDto)
            {
                item.STT = index++;
            }
            return new PagedResultDto<BannerDto>()
            {
                TotalCount = count,
                Items = itemsDto
            };
        }

        public async Task<BannerDto> UpdateAsync(Guid id, CreateOrUpdateBannerDto input)
        {
            var banner = await _bannerRepository.FindAsync(id);
            banner.Name = input.Name;
            banner.Image = input.Image;
            await _bannerRepository.UpdateAsync(banner);
            return ObjectMapper.Map<Banner, BannerDto>(banner);
        }
    }
}
