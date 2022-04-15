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
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace ManageProduct.Web.Pages.Products
{
    public class CreateModalModel : ManageProductPageModel
    {
        [BindProperty]
        public CreateUpdateProductDto Product { get; set; }
        private readonly IProductAppService _productAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IWebHostEnvironment _hostEnvironment;

        [SelectItems(nameof(CategoryIdFilterItems))]
        public Guid? CategoryIdFilter { get; set; }

        public List<SelectListItem> CategoryIdFilterItems { get; set; }

        public CreateModalModel(IProductAppService productAppService, ICategoryAppService categoryAppService, IWebHostEnvironment hostEnvironment)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
            _hostEnvironment = hostEnvironment;
        }
        public async Task OnGetAsync()
        {
            Product = new CreateUpdateProductDto();
            CategoryIdFilterItems = new List<SelectListItem>
            {
                new SelectListItem("Choose","")
            };
            var getlistCategory = await _categoryAppService.GetListCategoryLookupAsync();
            foreach (var item in getlistCategory)
            {
                CategoryIdFilterItems.AddLast(new SelectListItem(item.DisplayName, item.Id.ToString()));
            }

            await Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                var wwwRootPath = _hostEnvironment.WebRootPath;
                var filename = "Product" + DateTime.Now.ToString("yymmssfff") + extension;
                var image = Constant.UploadImageProduct + filename;
                var path = Path.Combine(wwwRootPath + image);
                //if (extension == Extension.Jpg || extension == Extension.Png || extension == Extension.Svg)
                //{

                //}
                //else
                //{
                //    throw new UserFriendlyException(L["ImageIsNotCorrectFormatJpgPngSgv"]);
                //}
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Product.Image = filename;

            }
            await _productAppService.CreateAsync(Product);
            return NoContent();
        }
    }
}
