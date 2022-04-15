using ManageProduct.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ManageProduct.DbMigrator
{

    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ManageProductMongoDbModule),
        typeof(ManageProductApplicationContractsModule)
        )]
    public class ManageProductDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}