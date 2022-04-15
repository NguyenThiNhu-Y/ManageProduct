using System;
using System.Collections.Generic;
using System.Text;
using ManageProduct.Localization;
using Volo.Abp.Application.Services;

namespace ManageProduct
{

    /* Inherit your application services from this class.
     */
    public abstract class ManageProductAppService : ApplicationService
    {
        protected ManageProductAppService()
        {
            LocalizationResource = typeof(ManageProductResource);
        }
    }
}