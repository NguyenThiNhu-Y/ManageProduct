using ManageProduct.MongoDB;
using Volo.Abp.Modularity;

namespace ManageProduct
{

    [DependsOn(
        typeof(ManageProductMongoDbTestModule)
        )]
    public class ManageProductDomainTestModule : AbpModule
    {

    }
}