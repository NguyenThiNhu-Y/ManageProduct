using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageProduct.Carts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManageProduct.Web.Pages.Home
{
    public class shopCartModel : ManageProductPageModel
    {
        private readonly ICartAppService _cartAppService;
        public shopCartModel(ICartAppService cartAppService)
        {
            _cartAppService = cartAppService;
        }

        public List<CartDto> ListCart { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        public async Task OnGetAsync()
        {
            GetCartInput input = new GetCartInput()
            {
                filterText = "",
                name = ""
            };
            ListCart = await _cartAppService.GetListCart();
        }

        public async Task<ActionResult> OnPost()
        {
            await _cartAppService.DeleteAsync(Id);
            return RedirectToAction("shopCart","Home");
        }
    }
}
