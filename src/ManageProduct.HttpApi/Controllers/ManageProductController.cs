using ManageProduct.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ManageProduct.Controllers
{

    /* Inherit your controllers from this class.
     */
    public abstract class ManageProductController : AbpControllerBase
    {
        protected ManageProductController()
        {
            LocalizationResource = typeof(ManageProductResource);
        }
    }
}