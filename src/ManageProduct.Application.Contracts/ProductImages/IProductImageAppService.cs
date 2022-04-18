using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ManageProduct.ProductImages
{
    public interface IProductImageAppService : IApplicationService
    {
        Task<List<ProductImageDto>> GetListAsync(Guid Id);

        Task Create(List<CreateUpdateProductImage> input);
    }
}
