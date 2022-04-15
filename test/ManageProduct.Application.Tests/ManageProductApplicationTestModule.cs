using Volo.Abp.Modularity;

namespace ManageProduct
{

    [DependsOn(
        typeof(ManageProductApplicationModule),
        typeof(ManageProductDomainTestModule)
        )]
    public class ManageProductApplicationTestModule : AbpModule
    {

    }
}