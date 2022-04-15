using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IProductAppService _productAppService;
        public List<ProductDto> ListProductRelated { get; set; }
        public DetailModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public async Task OnGet()
        {
            Product = await _productAppService.GetAsync(Id);
            ListProductRelated = await _productAppService.GetListRelatedProduct((Guid)Product.IdCategory);
        }
    }
}
