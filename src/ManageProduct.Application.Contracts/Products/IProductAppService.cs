using ManageProduct.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ManageProduct.Products
{
    public interface IProductAppService
    {
        Task<PagedResultDto<ProductDto>> GetListAsync(GetProductInput input);

        Task<List<ProductDto>> GetListRelatedProduct(Guid IdCategory);
        Task<ProductDto> CreateAsync(CreateUpdateProductDto input);

        Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input);

        Task<ProductDto> GetAsync(Guid id);

        Task<bool> DeleteAsync(Guid Id);

        Task<int> UpdateCountProduct(Guid id, bool add);

        Task ChangeStatus(Guid id);

        Task<List<ProductDto>> GetAllProduct(string search = null, Guid? category=null, int maxResult = int.MaxValue, int skipCount = 0, string sort = null);
    }
}
