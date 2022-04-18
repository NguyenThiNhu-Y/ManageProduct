using AutoMapper;
using ManageProduct.Banners;
using ManageProduct.Categories;
using ManageProduct.ProductImages;
using ManageProduct.Products;

namespace ManageProduct
{

    public class ManageProductApplicationAutoMapperProfile : Profile
    {
        public ManageProductApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateUpdatecategoryDto, Category>();
            CreateMap<CategoryDto, CreateUpdatecategoryDto>();
            
            CreateMap<Product, ProductDto>();
            CreateMap<CreateUpdateProductDto, Product>();
            CreateMap<ProductDto, CreateUpdateProductDto>();

            CreateMap<Banner, BannerDto>();
            CreateMap<CreateOrUpdateBannerDto, Banner>();
            CreateMap<BannerDto, CreateOrUpdateBannerDto>();

            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<CreateUpdateProductImage, ProductImage>();

        }
    }
}