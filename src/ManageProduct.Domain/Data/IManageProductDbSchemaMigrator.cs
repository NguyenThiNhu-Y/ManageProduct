using System.Threading.Tasks;

namespace ManageProduct.Data
{

    public interface IManageProductDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}