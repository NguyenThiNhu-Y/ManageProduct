using Microsoft.AspNetCore.Mvc;
using System;

namespace ManageProduct.Web.Pages
{

    public class IndexModel : ManageProductPageModel
    {
        [BindProperty(SupportsGet =true)]
        public Guid Id { get; set; }
        public void OnGet()
        {
            var i = Id;
        }
    }
}