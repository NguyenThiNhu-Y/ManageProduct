using ManageProduct.Categories;
using ManageProduct.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ManageProduct.Products
{
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductAppService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        

        public Task ChangeStatus(Guid id)
        {
            throw new NotImplementedException();
        }

        

        public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            var product = ObjectMapper.Map<CreateUpdateProductDto, Product>(input);
            await _productRepository.InsertAsync(product);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var product = await _productRepository.FindAsync(Id);
            await _productRepository.DeleteAsync(product);
            return true;
        }

        public async Task<List<ProductDto>> GetAllProduct()
        {
            var items = await _productRepository.GetListAsync();
            return ObjectMapper.Map<List<Product>, List<ProductDto>>(items);
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.FindAsync(id);
            Category categoryParent = new Category();
            if (product.IdCategory != null)
            {
                categoryParent = await _categoryRepository.FindAsync(product.IdCategory.Value);
            }

            string categoryParentName = " ";
            if (categoryParent != null)
            {

                categoryParentName = categoryParent.Name;

            }
            var result = ObjectMapper.Map<Product, ProductDto>(product);
            result.CategoryName = categoryParentName;
            return result;
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync(GetProductInput input)
        {
            var count = await _productRepository.GetCountAsync(input.FilterText, input.Name);
            var items = await _productRepository.GetListAsync(input.FilterText, input.Name, input.Sorting, input.MaxResultCount, input.SkipCount);

            var index = 1;
            List<ProductDto> result = new List<ProductDto>();
            foreach (var product in items)
            {
                Category categoryParent = new Category();
                if (product.IdCategory != null)
                {
                    categoryParent = await _categoryRepository.FindAsync(product.IdCategory.Value);
                }

                string categoryParentName = " ";
                if (categoryParent != null)
                {

                    categoryParentName = categoryParent.Name;

                }
                
                result.Add(new ProductDto()
                {
                    STT = index++,
                    Id = product.Id,
                    Name = product.Name,
                    CategoryName = categoryParentName,
                    Image = product.Image,
                    Describe = product.Describe,
                    IdCategory = product.IdCategory,
                    Price = product.Price
                });
            }
            return new PagedResultDto<ProductDto>
            {
                TotalCount = count,
                //Items = ObjectMapper.Map<List<Category>, List<CategoryDto>>(items)
                Items = result
            };
        }

        public async Task<List<ProductDto>> GetListRelatedProduct(Guid IdCategory)
        {
            var items = await _productRepository.GetListProductRelatedAsync(IdCategory);
            return ObjectMapper.Map<List<Product>, List<ProductDto>>(items);

        }

        public async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var oldProduct = await _productRepository.FindAsync(id);
            oldProduct.Name = input.Name;
            if(input.Image != oldProduct.Image && input.Image != null)
            {
                oldProduct.Image = input.Image;
            }
            oldProduct.Describe = input.Describe;
            oldProduct.IdCategory = input.IdCategory;
            oldProduct.Price = input.Price;
            await _productRepository.UpdateAsync(oldProduct);
            return ObjectMapper.Map<Product, ProductDto>(oldProduct);
        }

        
        public Task<int> UpdateCountProduct(Guid id, bool add)
        {
            throw new NotImplementedException();
        }
    }
}
