using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageProduct.ProductImages;
using ManageProduct.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManageProduct.Web.Pages.Products
{
    public class DetailModalModel : ManageProductPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public ProductDto Product { get; set; }

        public List<ProductImageDto> ProductImages { get; set; }

        public readonly IProductAppService _productAppService;
        public readonly IProductImageAppService _imageAppService;

        public DetailModalModel(IProductAppService productAppService, IProductImageAppService imageAppService)
        {
            _productAppService = productAppService;
            _imageAppService = imageAppService;
        }
        public async Task OnGetAsync()
        {
            Product = await _productAppService.GetAsync(Id);
            ProductImages = new List<ProductImageDto>();
            ProductImages = await _imageAppService.GetListAsync(Id);

        }
    }
}
