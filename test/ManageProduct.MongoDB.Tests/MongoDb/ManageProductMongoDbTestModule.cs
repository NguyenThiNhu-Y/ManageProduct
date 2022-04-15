﻿using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace ManageProduct.MongoDB
{

    [DependsOn(
        typeof(ManageProductTestBaseModule),
        typeof(ManageProductMongoDbModule)
        )]
    public class ManageProductMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var stringArray = ManageProductMongoDbFixture.ConnectionString.Split('?');
            var connectionString = stringArray[0].EnsureEndsWith('/') +
                                       "Db_" +
                                   Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}