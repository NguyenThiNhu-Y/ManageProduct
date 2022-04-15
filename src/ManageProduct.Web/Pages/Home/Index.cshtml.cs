using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageProduct.Banners;
using ManageProduct.Categories;
using ManageProduct.Products;
using ManageProduct.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManageProduct.Web.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IBannerAppService _bannerAppService;
        private readonly IProductAppService _productAppService;
        public List<LookupDto<Guid?>> Categories { get; set; }
        public BannerDto banner { get; set; }
        public List<ProductDto> Products { get; set; }
        public IndexModel(ICategoryAppService categoryAppService, IBannerAppService bannerAppService, IProductAppService productAppService)
        {
            _categoryAppService = categoryAppService;
            _bannerAppService = bannerAppService;
            _productAppService = productAppService;
        }
        public async Task OnGet()
        {
            Categories = await _categoryAppService.GetListCategoryLookupAsync();
            banner = await _bannerAppService.GetBanner();
            Products = await _productAppService.GetAllProduct();
        }
    }
}
