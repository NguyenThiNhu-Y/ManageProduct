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

namespace ManageProduct.Banners
{
    public class MongoBannerRepository : MongoDbRepository<ManageProductMongoDbContext, Banner, Guid>, IBannerRepository
    {
        public MongoBannerRepository(IMongoDbContextProvider<ManageProductMongoDbContext> dbContext) : base(dbContext)
        {

        }
        public async Task<long> GetCountAsync(string filterText = null, string name = null, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name);
            return await query.As<IMongoQueryable<Banner>>().LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Banner>> GetListAsync(string filterText = null, string name = null, string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name);
            return await query.As<IMongoQueryable<Banner>>()
                .OrderByDescending(x => x.CreationTime)
                .PageBy<Banner, IMongoQueryable<Banner>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Banner> ApplyFilter(
            IQueryable<Banner> query,
            string filterText, string name = null)
        {
            var dbContext = GetDbContextAsync();
            var getDashboards = query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.ToLower().Contains(filterText.ToLower()));
            return getDashboards;
        }
    }
}
