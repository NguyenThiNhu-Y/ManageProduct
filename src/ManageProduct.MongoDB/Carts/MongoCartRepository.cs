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

namespace ManageProduct.Carts
{
    public class MongoCartRepository : MongoDbRepository<ManageProductMongoDbContext, Cart, Guid>, ICartRepository
    {
        public MongoCartRepository(IMongoDbContextProvider<ManageProductMongoDbContext> dbContext) : base(dbContext)
        {

        }

        public async Task<long> GetCountAsync(string filterText = null, string name = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name);
            return await query.As<IMongoQueryable<Cart>>().LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Cart>> GetListAsync(string filterText = null, string name = null, string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name);
            return await query.As<IMongoQueryable<Cart>>()
                .OrderByDescending(x => x.CreationTime)
                .PageBy<Cart, IMongoQueryable<Cart>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Cart> ApplyFilter(IQueryable<Cart> query, string filterText, string name)
        {
            var dbContext = GetDbContextAsync();
            var getDashboard = query.WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.ToLower().Contains(filterText.ToLower()));
            return getDashboard;
        }
    }
}
