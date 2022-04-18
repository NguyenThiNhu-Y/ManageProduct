using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ManageProduct.ProductImages
{
    public interface IProductImageRepository : IRepository<ProductImage, Guid>
    {
        Task<List<ProductImage>> GetListAsync(
                    Guid IdProduct
                );

    }
}
