using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public readonly IProductAppService _productAppService;

        public DetailModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public async Task OnGetAsync()
        {
            Product = await _productAppService.GetAsync(Id);


        }
    }
}
