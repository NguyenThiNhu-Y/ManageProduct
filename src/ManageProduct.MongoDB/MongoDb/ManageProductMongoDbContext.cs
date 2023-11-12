using ManageProduct.Banners;
using ManageProduct.Categories;
using ManageProduct.Products;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using ManageProduct.ProductImages;
using ManageProduct.Carts;

namespace ManageProduct.MongoDB
{

    [ConnectionStringName("Default")]
    public class ManageProductMongoDbContext : AbpMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            //builder.Entity<YourEntity>(b =>
            //{
            //    //...
            //});
        }
        public IMongoCollection<Category> Categories => Collection<Category>();
        public IMongoCollection<Product> Producta => Collection<Product>();
        public IMongoCollection<Banner> Banners => Collection<Banner>();
        public IMongoCollection<ProductImage> ProductImages => Collection<ProductImage>();
        public IMongoCollection<Cart> Carts => Collection<Cart>();

    }
}