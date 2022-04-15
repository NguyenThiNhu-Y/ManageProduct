using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ManageProduct.Pages
{

    [Collection(ManageProductTestConsts.CollectionDefinitionName)]
    public class Index_Tests : ManageProductWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}