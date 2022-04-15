using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ManageProduct.Web
{

    [Dependency(ReplaceServices = true)]
    public class ManageProductBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ManageProduct";
    }
}