using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageProduct.ProductImages;
using ManageProduct.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManageProduct.Web.Pages.Home
{
    public class DetailModel : PageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet =true)]
        public Guid Id { get; set; }
        public ProductDto Product { get; set; }
        public List<ProductImageDto> ProductImages { get; set; }

        private readonly IProductAppService _productAppService;
        private readonly IProductImageAppService _imageAppService;
        public List<ProductDto> ListProductRelated { get; set; }
        public DetailModel(IProductAppService productAppService, IProductImageAppService imageAppService)
        {
            _productAppService = productAppService;
            _imageAppService = imageAppService;
        }
        public async Task OnGet()
        {
            Product = await _productAppService.GetAsync(Id);
            ListProductRelated = await _productAppService.GetListRelatedProduct((Guid)Product.IdCategory);
            ProductImages = await _imageAppService.GetListAsync(Id);
        }
    }
}
