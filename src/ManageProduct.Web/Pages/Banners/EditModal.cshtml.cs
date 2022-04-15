using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ManageProduct.Banners;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManageProduct.Web.Pages.Banners
{
    public class EditModalModel : ManageProductPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet =true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateOrUpdateBannerDto Banner { get; set; }

        private readonly IBannerAppService _bannerAppService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EditModalModel(IBannerAppService bannerAppService,IWebHostEnvironment hostEnvironment)
        {
            _bannerAppService = bannerAppService;
            _hostEnvironment = hostEnvironment;
        }
        public async Task OnGet()
        {
            var bannerDto = await _bannerAppService.GetAsync(Id);
            Banner = ObjectMapper.Map<BannerDto, CreateOrUpdateBannerDto>(bannerDto);
        }
        public async Task OnPost(IFormFile file)
        {
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                var wwwRootPath = _hostEnvironment.WebRootPath;
                var filename = "Banner" + DateTime.Now.ToString("yymmssfff") + extension;
                var image = DefaultUploadImage.UploadImageBanner + filename;
                var path = Path.Combine(wwwRootPath + image);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Banner.Image = filename;

            }
            await _bannerAppService.UpdateAsync(Id, Banner);
        }
    }
}
