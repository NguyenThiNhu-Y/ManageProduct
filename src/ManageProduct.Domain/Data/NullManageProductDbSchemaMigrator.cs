using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ManageProduct.Data
{

    /* This is used if database provider does't define
     * IManageProductDbSchemaMigrator implementation.
     */
    public class NullManageProductDbSchemaMigrator : IManageProductDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}