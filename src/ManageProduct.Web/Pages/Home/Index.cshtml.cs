using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageProduct.Banners;
using ManageProduct.Carts;
using ManageProduct.Categories;
using ManageProduct.Products;
using ManageProduct.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManageProduct.Web.Pages.Home
{
    public class IndexModel : ManageProductPageModel
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IBannerAppService _bannerAppService;
        private readonly IProductAppService _productAppService;
        private readonly ICartAppService _cartAppService;
        public List<LookupDto<Guid?>> Categories { get; set; }
        public BannerDto banner { get; set; }
        public List<ProductDto> Products { get; set; }
        public ProductDto[] ArrayProduct { get; set; }

        public List<ProductDto> FeaturedProduct { get; set; }
        public IndexModel(
            ICategoryAppService categoryAppService, 
            IBannerAppService bannerAppService, 
            IProductAppService productAppService,
            ICartAppService cartAppService )
        {
            _categoryAppService = categoryAppService;
            _bannerAppService = bannerAppService;
            _productAppService = productAppService;
            _cartAppService = cartAppService;
        }
        public async Task OnGet(string search)
        {
            Categories = await _categoryAppService.GetListCategoryLookupAsync();
            banner = await _bannerAppService.GetBanner();
            Products = await _productAppService.GetAllProduct();
            ArrayProduct = Products.ToArray();

            FeaturedProduct = new List<ProductDto>();
            //get Featured Product
            foreach(var cate in Categories)
            {
                var ProductInCategory = await _productAppService.GetAllProduct("", cate.Id);
                if (ProductInCategory.Count != 0)
                {
                    ProductDto[] ArrayProductInCategory = ProductInCategory.ToArray();
                    for (int i = 0; i < 4; i++)
                    {
                        var item = ArrayProductInCategory[i];
                        FeaturedProduct.Add(item);
                    }
                }
                
            }
            if (search != null)
            {
                RedirectToAction("shopGrid", "Home", search);
            }
        }
        public async Task<IActionResult> OnPostAsync(Guid idProduct)
        {
            CreateCartDto cartDto = new CreateCartDto
            { 
                IdProduct = idProduct,
                Name = "",
                Price = 0,
                Quantity = 0
            };

            await _cartAppService.AddCartCreateAsync(cartDto);
            return NoContent();
        }
    }
}
