using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ManageProduct.Carts
{
    public interface ICartAppService: IApplicationService
    {
        Task<PagedResultDto<CartDto>> GetListAsync(GetCartInput input);

        Task<List<CartDto>> GetListCart();

        Task<CartDto> AddCartCreateAsync(CreateCartDto input);

        Task DeleteAsync(Guid Id);

        Task UpdateQuanlity(Guid Id, int quanlityNew);
    }
}
