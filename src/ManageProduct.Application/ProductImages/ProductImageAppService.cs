using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ManageProduct.ProductImages
{
    public class ProductImageAppService : ApplicationService, IProductImageAppService
    {
        private readonly IProductImageRepository _productImageRepository;
        public ProductImageAppService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        public bool CheckId(List<Guid> ListId, Guid Id)
        {
            foreach(var item in ListId)
            {
                if (item == Id)
                    return true;
            }
            return false;
        }
        public async Task Create(List<CreateUpdateProductImage> input)
        {
            Guid idProduct = new Guid();
            //list Id image thêm vào
            List<Guid> ListGuid = new List<Guid>();
            //insert ảnh vào
            foreach(var item in input)
            {
                idProduct = item.IdProduct;
                var productImage = ObjectMapper.Map<CreateUpdateProductImage, ProductImage>(item);
                await _productImageRepository.InsertAsync(productImage);
                var dto = ObjectMapper.Map<ProductImage, ProductImageDto>(productImage);
                ListGuid.Add(dto.Id);

            }
            //var productImage = ObjectMapper.Map<CreateUpdateProductImage, ProductImage>(input);
            //xóa các ảnh trước đó
            var ProductImages = await _productImageRepository.GetListAsync(idProduct);
            foreach(var item in ProductImages)
            {
                if (!CheckId(ListGuid, item.Id))
                {
                    await _productImageRepository.DeleteAsync(item);
                }
            }
        }

        public async Task<List<ProductImageDto>> GetListAsync(Guid Id)
        {
            var items = await _productImageRepository.GetListAsync(Id);
            return ObjectMapper.Map<List<ProductImage>, List<ProductImageDto>>(items);
        }
    }
}
