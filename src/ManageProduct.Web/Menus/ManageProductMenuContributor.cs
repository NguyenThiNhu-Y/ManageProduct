using System.Threading.Tasks;
using ManageProduct.Localization;
using ManageProduct.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace ManageProduct.Web.Menus
{

    public class ManageProductMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<ManageProductResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    ManageProductMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );

            var ManageProduct = new ApplicationMenuItem(
                "ManageProduct",
                l["Menu:ManageProduct"]
            );
            var Banner = new ApplicationMenuItem(
                "Banner",
                l["Menu:Banner"],
                url:"/Banners"
            );
            context.Menu.AddItem(ManageProduct);
            context.Menu.AddItem(Banner);

            ManageProduct
                    .AddItem(
                    new ApplicationMenuItem(
                            "ManageProduct.Categories",
                            l["Menu:Category"],
                            url: "/Categories")
                        )
                    .AddItem(
                        new ApplicationMenuItem(
                            "ManageProduct.Products",
                            l["Menu:Product"],
                            url: "/Products"
                        )
                    );

            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        }
    }
}