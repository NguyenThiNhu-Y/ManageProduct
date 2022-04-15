using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ManageProduct.Categories;
using ManageProduct.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManageProduct.Web.Pages.Products
{
    public class EditModalModel : ManageProductPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateProductDto product { get; set; }

        public List<SelectListItem> CategoryIdFilterItems { get; set; }

        public readonly IProductAppService _productAppService;
        public readonly ICategoryAppService _categoryAppService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EditModalModel(IProductAppService productAppService, ICategoryAppService categoryAppService, IWebHostEnvironment hostEnvironment)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
            _hostEnvironment = hostEnvironment;
        }
        public async Task OnGetAsync()
        {
            var productDto = await _productAppService.GetAsync(Id);
            product = ObjectMapper.Map<ProductDto, CreateUpdateProductDto>(productDto);
            CategoryIdFilterItems = new List<SelectListItem>
            {
                new SelectListItem("Choose","")
            };
            var getListCategory = await _categoryAppService.GetListCategoryEditLookupAsync(Id);
            foreach (var item in getListCategory)
            {
                CategoryIdFilterItems.Add(new SelectListItem(item.DisplayName, item.Id.ToString()));
            }

        }
        public async Task<IActionResult> OnPostAsync(IFormFile []files)
        {
            if (ModelState.IsValid)
            {
                foreach(var file in files)
                {
                    if (file != null)
                    {
                        var extension = Path.GetExtension(file.FileName).ToLower();
                        var wwwRootPath = _hostEnvironment.WebRootPath;
                        var filename = "Poduct" + DateTime.Now.ToString("yymmssfff") + extension;
                        var image = Constant.UploadImageProduct + filename;
                        var path = Path.Combine(wwwRootPath + image);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        product.Image = filename;

                    }
                }
                
                await _productAppService.UpdateAsync(Id, product);
                return RedirectToAction("Index", "Products");
            }
            return NoContent();
        }
    }
}

