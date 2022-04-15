using ManageProduct.MongoDB;
using Xunit;

namespace ManageProduct
{

    [CollectionDefinition(ManageProductTestConsts.CollectionDefinitionName)]
    public class ManageProductDomainCollection : ManageProductMongoDbCollectionFixtureBase
    {

    }
}