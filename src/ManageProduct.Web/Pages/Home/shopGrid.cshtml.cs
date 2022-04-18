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
using Volo.Abp.Application.Dtos;

namespace ManageProduct.Web.Pages.Home
{
    public class shopGridModel : PageModel
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IBannerAppService _bannerAppService;
        private readonly IProductAppService _productAppService;
        public List<LookupDto<Guid?>> Categories { get; set; }
        public BannerDto banner { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<ProductDto> AllProducts { get; set; }
        public ProductDto[] ArrayProduct { get; set; }
        public CategoryDto Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public shopGridModel(ICategoryAppService categoryAppService, IBannerAppService bannerAppService, IProductAppService productAppService)
        {
            _categoryAppService = categoryAppService;
            _bannerAppService = bannerAppService;
            _productAppService = productAppService;
        }
        public async Task OnGetAsync( string search, Guid? category = null , int PageIndex = 1, string sort = null)
        {
            Categories = await _categoryAppService.GetListCategoryLookupAsync();
            banner = await _bannerAppService.GetBanner();
            //var skipCount = 0;
            //if(page != 0)
            //{
            //    skipCount = (page - 1) * 12;
            //}
            var skipCount = (PageIndex - 1) * 12;
            Products = await _productAppService.GetAllProduct(search, category, 12, skipCount, sort);

            AllProducts = await _productAppService.GetAllProduct();
            ArrayProduct = AllProducts.ToArray();

            if(category != null)
            {
                Category = await _categoryAppService.GetAsync((Guid)category);
            }
        }
    }
}
