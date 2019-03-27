using Shopping.Data.Builders;
using Shopping.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Shopping.Data
{
   


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostPostCategory> PostPostCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreBrand> StoreBrands { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<ProductQuestion> ProductQuestions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<Shipper> Shippers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var property in builder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            {
                property.Relational().ColumnType = "decimal(18, 2)";
            }
            var brandBuilder = new BrandBuilder(builder.Entity<Brand>());
            var colorBuilder = new ColorBuilder(builder.Entity<Color>());
            var fileBuilder = new FileBuilder(builder.Entity<File>());
            var languageBuilder = new LanguageBuilder(builder.Entity<Language>());
            var pageBuilder = new PageBuilder(builder.Entity<Page>());
            var postBuilder = new PostBuilder(builder.Entity<Post>());
            var postCategoryBuilder = new PostCategoryBuilder(builder.Entity<PostCategory>());
            var postPostCategoryBuilder = new PostPostCategoryBuilder(builder.Entity<PostPostCategory>());
            var productBuilder = new ProductBuilder(builder.Entity<Product>());
            var productCategoryBuilder = new ProductCategoryBuilder(builder.Entity<ProductCategory>());
            var productColorBuilder = new ProductColorBuilder(builder.Entity<ProductColor>());
            var productPhotoBuilder = new ProductPhotoBuilder(builder.Entity<ProductPhoto>());
            var reviewBuilder = new ReviewBuilder(builder.Entity<Review>());
            var slideBuilder = new SlideBuilder(builder.Entity<Slide>());
            var sliderBuilder = new SliderBuilder(builder.Entity<Slider>());
            var advertisementBuilder = new AdvertisementBuilder(builder.Entity<Advertisement>());
            var storeBuilder = new StoreBuilder(builder.Entity<Store>());
            var storeBrandBuilder = new StoreBrandBuilder(builder.Entity<StoreBrand>());
            var wishlistBuilder = new WishlistBuilder(builder.Entity<Wishlist>());
            var orderBuilder = new OrderBuilder(builder.Entity<Order>());
            var orderItemBuilder = new OrderItemBuilder(builder.Entity<OrderItem>());
            var addressBuilder = new AddressBuilder(builder.Entity<Address>());
            var cityBuilder = new CityBuilder(builder.Entity<City>());
            var countryBuilder = new CountryBuilder(builder.Entity<Country>());
            var couponBuilder = new CouponBuilder(builder.Entity<Coupon>());
            var districtBuilder = new DistrictBuilder(builder.Entity<District>());
            var productQuestionBuilder = new ProductQuestionBuilder(builder.Entity<ProductQuestion>());
            var questionCategoryBuilder = new QuestionCategoryBuilder(builder.Entity<QuestionCategory>());
            var shipperBuilder = new ShipperBuilder(builder.Entity<Shipper>());

            // data seeding
            ApplicationDbContextSeed.Seed(builder);

        }
    }
}
