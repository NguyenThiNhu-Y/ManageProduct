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

namespace ManageProduct.ProductImages
{
    public class ProductImageRepository : MongoDbRepository<ManageProductMongoDbContext, ProductImage, Guid>, IProductImageRepository
    {
        public ProductImageRepository(IMongoDbContextProvider<ManageProductMongoDbContext> dbContext) : base(dbContext)
        {

        }

        public async Task<List<ProductImage>> GetListAsync(Guid IdProduct)
        {
            var query = ApplyFilter(await GetMongoQueryableAsync(), IdProduct);
            return await query.As<IMongoQueryable<ProductImage>>()
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync(GetCancellationToken());
        }

        protected virtual IQueryable<ProductImage> ApplyFilter(
            IQueryable<ProductImage> query,
            Guid IdProduct)
        {
            var dbContext = GetDbContextAsync();
            var getDashboards = query
                //.WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Image.ToLower().Contains(filterText.ToLower()));
                .Where(e => e.IdProduct == IdProduct);
            return getDashboards;
        }
    }
}
