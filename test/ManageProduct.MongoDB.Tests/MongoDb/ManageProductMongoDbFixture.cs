using System;
using Mongo2Go;

namespace ManageProduct.MongoDB
{

    public class ManageProductMongoDbFixture : IDisposable
    {
        private static readonly MongoDbRunner MongoDbRunner;
        public static readonly string ConnectionString;

        static ManageProductMongoDbFixture()
        {
            MongoDbRunner = MongoDbRunner.Start(singleNodeReplSet: true, singleNodeReplSetWaitTimeout: 20);
            ConnectionString = MongoDbRunner.ConnectionString;
        }

        public void Dispose()
        {
            MongoDbRunner?.Dispose();
        }
    }
}