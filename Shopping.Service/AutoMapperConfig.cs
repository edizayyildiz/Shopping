using Shopping.Model.Entities;
using Shopping.Service.Commands;
using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Shopping.Service.Queries;

namespace Shopping.Service
{
    public class AutoMapperConfig
    {
        public void Initialize()
        {
            var cfg = new MapperConfigurationExpression();

            // create all maps here
            cfg.CreateMap<Brand, AddBrand>().ReverseMap();
            cfg.CreateMap<Brand, EditBrand>().ReverseMap();
            cfg.CreateMap<Brand, BrandQuery>().ReverseMap();

            cfg.CreateMap<Language, AddLanguage>().ReverseMap();
            cfg.CreateMap<Language, EditLanguage>().ReverseMap();
            cfg.CreateMap<Language, LanguageQuery>().ReverseMap();

            cfg.CreateMap<File, AddFile>().ReverseMap();
            cfg.CreateMap<File, EditFile>().ReverseMap();
            cfg.CreateMap<File, FileQuery>().ReverseMap();

            cfg.CreateMap<Page, AddPage>().ReverseMap();
            cfg.CreateMap<Page, EditPage>().ReverseMap();
            cfg.CreateMap<Page, PageQuery>().ReverseMap();

            cfg.CreateMap<Post, AddPost>().ReverseMap();
            cfg.CreateMap<Post, EditPost>().ReverseMap();
            cfg.CreateMap<Post, PostQuery>().ReverseMap();

            cfg.CreateMap<PostCategory, AddPostCategory>().ReverseMap();
            cfg.CreateMap<PostCategory, EditPostCategory>().ReverseMap();
            cfg.CreateMap<PostCategory, PostCategoryQuery>().ReverseMap();

            cfg.CreateMap<PostPostCategory, AddPostPostCategory>().ReverseMap();
            cfg.CreateMap<PostPostCategory, EditPostPostCategory>().ReverseMap();
            cfg.CreateMap<PostPostCategory, PostPostCategoryQuery>().ReverseMap();

            cfg.CreateMap<Slide, AddSlide>().ReverseMap();
            cfg.CreateMap<Slide, EditSlide>().ReverseMap();
            cfg.CreateMap<Slide, SlideQuery>()
                .ForMember(dest => dest.SliderName, opt => opt.MapFrom(x => x.Slider.Name))
                .ReverseMap();

            cfg.CreateMap<Slider, AddSlider>().ReverseMap();
            cfg.CreateMap<Slider, EditSlider>().ReverseMap();
            cfg.CreateMap<Slider, SliderQuery>().ReverseMap();

            cfg.CreateMap<Color, AddColor>().ReverseMap();
            cfg.CreateMap<Color, EditColor>().ReverseMap();
            cfg.CreateMap<Color, ColorQuery>().ReverseMap();
            
            cfg.CreateMap<Product, AddProduct>().ReverseMap();
            
            cfg.CreateMap<Product, EditProduct>().ReverseMap();
            cfg.CreateMap<Product, ProductQuery>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(x => x.Category.Name))
            .ReverseMap();

            cfg.CreateMap<ProductCategory, AddProductCategory>().ReverseMap();
            cfg.CreateMap<ProductCategory, EditProductCategory>().ReverseMap();
            cfg.CreateMap<ProductCategory, ProductCategoryQuery>().ReverseMap();

            cfg.CreateMap<ProductColor, AddProductColor>().ReverseMap();
            cfg.CreateMap<ProductColor, EditProductColor>().ReverseMap();
            cfg.CreateMap<ProductColor, ProductColorQuery>().ReverseMap();

            cfg.CreateMap<ProductPhoto, AddProductPhoto>().ReverseMap();
            cfg.CreateMap<ProductPhoto, EditProductPhoto>().ReverseMap();
            cfg.CreateMap<ProductPhoto, ProductPhotoQuery>().ReverseMap();

            cfg.CreateMap<Review, AddReview>().ReverseMap();
            cfg.CreateMap<Review, EditReview>().ReverseMap();
            cfg.CreateMap<Review, ReviewQuery>().ReverseMap();

            cfg.CreateMap<Advertisement, AddAdvertisement>().ReverseMap();
            cfg.CreateMap<Advertisement, EditAdvertisement>().ReverseMap();
            cfg.CreateMap<Advertisement, AdvertisementQuery>().ReverseMap();

            cfg.CreateMap<Store, AddStore>().ReverseMap();
            cfg.CreateMap<Store, EditStore>().ReverseMap();
            cfg.CreateMap<Store, StoreQuery>().ReverseMap();

            cfg.CreateMap<StoreBrand, AddStoreBrand>().ReverseMap();
            cfg.CreateMap<StoreBrand, EditStoreBrand>().ReverseMap();
            cfg.CreateMap<StoreBrand, StoreBrandQuery>().ReverseMap();

            cfg.CreateMap<Wishlist, AddWishlist>().ReverseMap();
            cfg.CreateMap<Wishlist, EditWishlist>().ReverseMap();
            cfg.CreateMap<Wishlist, WishlistQuery>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.ProductId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Product.Name))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(x => x.Product.Slug))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(x => x.Product.Images))
                .ForMember(dest => dest.IsFeatured, opt => opt.MapFrom(x => x.Product.IsFeatured))
                .ForMember(dest => dest.IsOnSale, opt => opt.MapFrom(x => x.Product.IsOnSale))
                .ForMember(dest => dest.IsNew, opt => opt.MapFrom(x => x.Product.IsNew))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(x => x.Product.ShortDescription))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(x => x.Product.Description))
                .ForMember(dest => dest.NewPrice, opt => opt.MapFrom(x => x.Product.NewPrice))
                .ForMember(dest => dest.OldPrice, opt => opt.MapFrom(x => x.Product.OldPrice))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(x => x.Product.Discount))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(x => x.Product.Cost))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(x => x.Product.Currency))
                .ForMember(dest => dest.Condition, opt => opt.MapFrom(x => x.Product.Condition))
                .ForMember(dest => dest.Cost, opt => opt.MapFrom(x => x.Product.Cost))
                .ForMember(dest => dest.Tax, opt => opt.MapFrom(x => x.Product.Tax))
                .ForMember(dest => dest.RatingsCount, opt => opt.MapFrom(x => x.Product.RatingsCount))
                .ForMember(dest => dest.RatingsValue, opt => opt.MapFrom(x => x.Product.RatingsValue))
                .ForMember(dest => dest.AvailabilityCount, opt => opt.MapFrom(x => x.Product.AvailabilityCount))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(x => x.Product.Weight))
                .ForMember(dest => dest.AdditionalInformation, opt => opt.MapFrom(x => x.Product.AdditionalInformation))
                .ForMember(dest => dest.MetaTitle, opt => opt.MapFrom(x => x.Product.MetaTitle))
                .ForMember(dest => dest.MetaDescription, opt => opt.MapFrom(x => x.Product.MetaDescription))
                .ForMember(dest => dest.MetaKeywords, opt => opt.MapFrom(x => x.Product.MetaKeywords))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(x => x.Product.CategoryId))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(x => x.Product.Category))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(x => x.Product.BrandId))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(x => x.Product.Brand))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(x => x.Product.StoreId))
                .ForMember(dest => dest.Store, opt => opt.MapFrom(x => x.Product.Store))
                .ReverseMap();

            cfg.CreateMap<Order, AddOrder>().ReverseMap();
            cfg.CreateMap<Order, EditOrder>().ReverseMap();
            cfg.CreateMap<Order, OrderQuery>().ForMember(dest => dest.OrderItems, opt => opt.MapFrom(x => x.OrderItems));

            cfg.CreateMap<OrderItem, AddOrderItem>().ReverseMap();
            cfg.CreateMap<OrderItem, EditOrderItem>().ReverseMap();
            cfg.CreateMap<OrderItem, OrderItemQuery>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.ProductId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Product.Name))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(x => x.Product.ShortDescription))
                .ForMember(dest => dest.NewPrice, opt => opt.MapFrom(x => x.Product.NewPrice))
                .ForMember(dest => dest.OldPrice, opt => opt.MapFrom(x => x.Product.OldPrice))
                .ForMember(dest => dest.AvailabilityCount, opt => opt.MapFrom(x => x.Product.AvailabilityCount))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(x => x.Product.CategoryId))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(x => x.Product.Category))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(x => x.Product.BrandId))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(x => x.Product.Brand))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(x => x.Product.StoreId))
                .ForMember(dest => dest.Store, opt => opt.MapFrom(x => x.Product.Store))


                .ReverseMap(); ;

            cfg.CreateMap<Shipper, AddShipper>().ReverseMap();
            cfg.CreateMap<Shipper, EditShipper>().ReverseMap();
            cfg.CreateMap<Shipper, ShipperQuery>().ReverseMap();

            cfg.CreateMap<Address, AddAddress>().ReverseMap();
            cfg.CreateMap<Address, EditAddress>().ReverseMap();
            cfg.CreateMap<Address, AddressQuery>().ReverseMap();

            cfg.CreateMap<City, AddCity>().ReverseMap();
            cfg.CreateMap<City, EditCity>().ReverseMap();
            cfg.CreateMap<City, CityQuery>().ReverseMap();

            cfg.CreateMap<Country, AddCountry>().ReverseMap();
            cfg.CreateMap<Country, EditCountry>().ReverseMap();
            cfg.CreateMap<Country, CountryQuery>().ReverseMap();

            cfg.CreateMap<District, AddDistrict>().ReverseMap();
            cfg.CreateMap<District, EditDistrict>().ReverseMap();
            cfg.CreateMap<District, DistrictQuery>().ReverseMap();

            cfg.CreateMap<Coupon, AddCoupon>().ReverseMap();
            cfg.CreateMap<Coupon, EditCoupon>().ReverseMap();
            cfg.CreateMap<Coupon, CouponQuery>().ReverseMap();

            cfg.CreateMap<ProductQuestion, AddProductQuestion>().ReverseMap();
            cfg.CreateMap<ProductQuestion, EditProductQuestion>().ReverseMap();
            cfg.CreateMap<ProductQuestion, ProductQuestionQuery>().ReverseMap();

            cfg.CreateMap<QuestionCategory, AddQuestionCategory>().ReverseMap();
            cfg.CreateMap<QuestionCategory, EditQuestionCategory>().ReverseMap();
            cfg.CreateMap<QuestionCategory, QuestionCategoryQuery>().ReverseMap();



            Mapper.Initialize(cfg);
        }
    }
}
