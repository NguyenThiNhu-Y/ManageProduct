using ManageProduct.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace ManageProduct.Products
{
    public class MongoProductRepository : MongoDbRepository<ManageProductMongoDbContext, Product, Guid>, IProductRepository
    {
        public MongoProductRepository(IMongoDbContextProvider<ManageProductMongoDbContext> dbContext) : base(dbContext)
        {

        }
        public async Task<long> GetCountAsync(string filterText = null, string name = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name);
            return await query.As<IMongoQueryable<Product>>().LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Product>> GetListAsync(string filterText = null, string name = null, string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name);
            return await query.As<IMongoQueryable<Product>>()
                .OrderByDescending(x => x.CreationTime)
                .PageBy<Product, IMongoQueryable<Product>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Product>> GetListProductRelatedAsync(Guid IdCategory, string filterText = null, string name = null, string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name);
            return await query.As<IMongoQueryable<Product>>()
                .Where(x=>x.IdCategory == IdCategory)
                .OrderByDescending(x => x.CreationTime)
                .PageBy<Product, IMongoQueryable<Product>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Product> ApplyFilter(
            IQueryable<Product> query,
            string filterText, string name = null)
        {
            var dbContext = GetDbContextAsync();
            var getDashboards = query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.ToLower().Contains(filterText.ToLower()));
            return getDashboards;
        }
    }
}
