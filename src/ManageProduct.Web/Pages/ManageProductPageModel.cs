using ManageProduct.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ManageProduct.Web.Pages
{

    /* Inherit your PageModel classes from this class.
     */
    public abstract class ManageProductPageModel : AbpPageModel
    {
        protected ManageProductPageModel()
        {
            LocalizationResourceType = typeof(ManageProductResource);
        }
    }
}