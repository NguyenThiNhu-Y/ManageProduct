using ManageProduct.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ManageProduct.Carts
{
    public class CartAppService : ApplicationService, ICartAppService
    {
        private readonly ICartRepository _cartRepository;

        private readonly IProductRepository _productRepository;
        public CartAppService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public async Task<CartDto> AddCartCreateAsync(CreateCartDto input)
        {
            var item = ObjectMapper.Map<CreateCartDto, Cart>(input);
            await _cartRepository.InsertAsync(item);
            return ObjectMapper.Map<Cart, CartDto>(item);
        }

        public async Task DeleteAsync(Guid Id)
        {
            var item = await _cartRepository.FindAsync(Id);
            await _cartRepository.DeleteAsync(item);
        }

        public async Task<PagedResultDto<CartDto>> GetListAsync(GetCartInput input)
        {
            var count = await _cartRepository.GetCountAsync(input.filterText, input.name);
            var items = await _cartRepository.GetListAsync(input.filterText, input.name);

            List<CartDto> ListCartDto = new List<CartDto>();
            CartDto cartDto;
            foreach (var item in items)
            {
                cartDto = new CartDto();
                var product = await _productRepository.FindAsync(item.IdProduct);
                if (product != null)
                {
                    cartDto.Id = item.Id;
                    cartDto.IdProduct = product.Id;
                    cartDto.Name = product.Name;
                    cartDto.Price = product.Price;
                    cartDto.Quantity = 1;
                    cartDto.Image = product.Image;
                    cartDto.Total = cartDto.Price * cartDto.Quantity;
                    ListCartDto.Add(cartDto);
                }
                
                
            }
            return new PagedResultDto<CartDto>
            {
                TotalCount = count,
                Items = ListCartDto
            };
        }

        public async Task<List<CartDto>> GetListCart()
        {
            var items = await _cartRepository.GetListAsync("","");
            List<CartDto> ListCartDto = new List<CartDto>();
            CartDto cartDto;
            foreach (var item in items)
            {
                cartDto = new CartDto();
                var product = await _productRepository.FindAsync(item.IdProduct);
                if (product != null)
                {
                    cartDto.Id = item.Id;
                    cartDto.IdProduct = product.Id;
                    cartDto.Name = product.Name;
                    cartDto.Price = product.Price;
                    cartDto.Quantity = item.Quantity;
                    cartDto.Image = product.Image;
                    cartDto.Total = cartDto.Price * cartDto.Quantity;
                    ListCartDto.Add(cartDto);
                }

            }
            return ListCartDto;
        }

        public async Task UpdateQuanlity(Guid Id, int quanlityNew)
        {
            var item = await _cartRepository.FindAsync(Id);
            item.Quantity = quanlityNew;
            await _cartRepository.UpdateAsync(item);
        }
    }
}
