using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            SeedProductCategory(builder.Entity<ProductCategory>());
            SeedSlider(builder.Entity<Slider>());
            SeedSlide(builder.Entity<Slide>());
            SeedBrand(builder.Entity<Brand>());
            SeedProduct(builder.Entity<Product>());
            SeedProductPhoto(builder.Entity<ProductPhoto>());
            SeedReview(builder.Entity<Review>());
            SeedAdvertisement(builder.Entity<Advertisement>());
            SeedStore(builder.Entity<Store>());
            SeedStoreBrand(builder.Entity<StoreBrand>());
            SeedOrder(builder.Entity<Order>());
            SeedOrderItem(builder.Entity<OrderItem>());
            SeedAddress(builder.Entity<Address>());
            SeedCountry(builder.Entity<Country>());
            SeedCity(builder.Entity<City>());
            SeedDistrict(builder.Entity<District>());
            SeedCoupon(builder.Entity<Coupon>());
            SeedProductQuestion(builder.Entity<ProductQuestion>());
            SeedQuestionCategory(builder.Entity<QuestionCategory>());
            SeedShipper(builder.Entity<Shipper>());

        }

        public static void SeedProductCategory(EntityTypeBuilder<ProductCategory> builder)
        {
            var productCategory1 = new ProductCategory()
            {
                Id = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                Name = "Tüm Kategoriler",
                Slug = "tum-kategoriler",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productCategory1);
            var pc1 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b1",
                Name = "Prime Video",
                Slug = "prime-video",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(pc1);
            var pc2 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b2",
                Name = "Music, CDs & Vinyl",
                Slug = "music-cds-vinly",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(pc2);
            var pc3 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b3",
                Name = "Kindle Store",
                Slug = "kindle-store",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(pc3);
            var pc4 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b4",
                Name = "Arts & Crafts",
                Slug = "arts-crafts",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(pc4);
            var pc5 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b5",
                Name = "Automotive",
                Slug = "automotive",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(pc5);
            var pc6 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b0",
                Name = "Baby",
                Slug = "baby",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(pc6);
            var pc7 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b7",
                Name = "Beauty & Personal Care",
                Slug = "beauty-personal-care",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(pc7);
            var pc8 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b8",
                Name = "Books",
                Slug = "books",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(pc8);
            var pc9 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b9",
                Name = "Computers",
                Slug = "computers",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(pc9);
            var productCategory2 = new ProductCategory()
            {
                Id = "6d8135c2-833f-42fc-900d-6eeeb1c607b6",
                Name = "Elektronics",
                Slug = "elektronics",
                ParentId = "2d53d8ef-0f19-42ed-9126-e03a0a1af060",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productCategory2);

            var productCategory3 = new ProductCategory()
            {
                Id = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                Name = "Bilgisayar",
                Slug = "bilgisayar",
                ParentId = "6d8135c2-833f-42fc-900d-6eeeb1c607b6",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productCategory3);

            var productCategory4 = new ProductCategory()
            {
                Id = "ed515341-522e-4bfa-8f68-15c874fd77e9",
                Name = "Dizüstü Notebook",
                Slug = "dizustu-notebook",
                ParentId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productCategory4);

            var productCategory5 = new ProductCategory()
            {
                Id = "1f2f8408-9ad2-4908-b310-92dbdabe5979",
                Name = "All-In-One",
                Slug = "all-ın-one",
                ParentId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productCategory5);

            var productCategory6 = new ProductCategory()
            {
                Id = "4b64df99-8909-4fb4-bc23-9a84e5063f27",
                Name = "Telefon",
                Slug = "telefon",
                ParentId = "6d8135c2-833f-42fc-900d-6eeeb1c607b6",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productCategory6);

            var productCategory7 = new ProductCategory()
            {
                Id = "8da13d65-1efb-40ea-b88f-08b06d0776ab",
                Name = "Kulaklık",
                Slug = "kulaklık",
                ParentId = "6d8135c2-833f-42fc-900d-6eeeb1c607b6",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productCategory7);


        }
        public static void SeedSlider(EntityTypeBuilder<Slider> builder)
        {
            var slider1 = new Slider()
            {
                Id = "b5616904-9304-40ab-9488-5d4809021445",
                Name = "Ana Kaydırıcı",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(slider1);

            var slider2 = new Slider()
            {
                Id = "d1689024-2cff-420d-a2aa-141e93cbbff7",
                Name = "Orta Kaydırıcı",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(slider2);
        }

        public static void SeedSlide(EntityTypeBuilder<Slide> builder)
        {
            var slide1 = new Slide()
            {
                Id = "007f78d2-f4d5-413a-9a80-737bc6850d5d",
                Name = "Kampanyalı Ürünlerimiz",
                Title = "Hediye Paketli Ürünlerimiz",
                Text = "Çeşit Çeşit Paketlerdeki Orjinal Hediyeler",
                Photo = "waterandmountains.jpg",
                Url = "http://www.google.com.tr",
                SliderId = "b5616904-9304-40ab-9488-5d4809021445",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(slide1);

            var slide2 = new Slide()
            {
                Id = "3a64713c-22b6-48ff-8d84-740dcefdbd37",
                Name = "Yurt Dışından Gelen Ürünler",
                Title = "Kaliteli ve Uygun Fiyatlarla",
                Text = "Bütün Avrupa ve Asya'daki ülkelerdeki ürünler",
                Photo = "yurtdış.jpg",
                Url = "http://www.apple.com.tr",
                SliderId = "b5616904-9304-40ab-9488-5d4809021445",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(slide2);

            var slide3 = new Slide()
            {
                Id = "0c0d6d02-c99a-4537-9821-f2c90f21f451",
                Name = "Düğün Paketlerimiz",
                Title = "Her Türlü Ev Eşyaları Uygun Fiyatlarla",
                Text = "Bütün Markaların Ürünleri Vitrinlerimizde",
                Photo = "aile.jpg",
                Url = "http://www.evkur.com.tr",
                SliderId = "b5616904-9304-40ab-9488-5d4809021445",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(slide3);

            var slide4 = new Slide()
            {
                Id = "cc3fc344-2141-40c5-be49-3b9c661d56b2",
                Name = "İndirimli Apple Ürünleri",
                Title = "%40 İndirim ile Vitrinlerimizde",
                Text = "Bütün Elektronik Cihazlar Vitrinlerimizde",
                Photo = "appleur.jpg",
                Url = "http://www.apple.com.tr",
                SliderId = "b5616904-9304-40ab-9488-5d4809021445",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(slide4);

            var slide5 = new Slide()
            {
                Id = "072df9fd-ef97-40f4-a10e-5b0e7dc3f08c",
                Name = "2019 Model MacBook Air",
                Title = "Şubat 2019'da Vitrinlerimizde",
                Text = "Kaçırmayın",
                Photo = "MacBookAir2019.jpg",
                Url = "http://www.apple.com.tr",
                SliderId = "b5616904-9304-40ab-9488-5d4809021445",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(slide5);
        }

        public static void SeedBrand(EntityTypeBuilder<Brand> builder)
        {
            var brand1 = new Brand()
            {
                Id = "e8840d39-abf2-4577-bfa5-a92144107b09",
                Name = "Apple",
                Slug = "apple",
                Image = "apple1.jpg",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(brand1);

            var brand2 = new Brand()
            {
                Id = "f3bf46ec-4135-4f13-b874-b6d0fea16ada",
                Name = "Dell",
                Slug = "dell",
                Image = "dell.jpg",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(brand2);

            var brand3 = new Brand()
            {
                Id = "6d85aacb-8f1b-4488-b5bd-5390b9cd76c6",
                Name = "Hp",
                Slug = "hp",
                Image = "hp1.jpg",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(brand3);

            var brand4 = new Brand()
            {
                Id = "c047e1e6-01d1-47d9-8087-ad1b3400ad0e",
                Name = "Lenovo",
                Slug = "lenovo",
                Image = "lenovo1.jpg",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(brand4);

            var brand5 = new Brand()
            {
                Id = "45ee14ef-d408-47e3-b104-01a9e23c5def",
                Name = "Samsung",
                Slug = "samsung",
                Image = "samsung1.jpg",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(brand5);

            var brand6 = new Brand()
            {
                Id = "109057a8-d4c0-40c5-bede-a238dcdf0245",
                Name = "Asus",
                Slug = "asus",
                Image = "asus.jpg",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(brand6);

            var brand7 = new Brand()
            {
                Id = "d228e627-feb9-4208-9a10-b3ac8dc866fa",
                Name = "Sony",
                Slug = "sony",
                Image = "sony.jpg",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(brand7);

            var brand8 = new Brand()
            {
                Id = "ff23d5c6-d2b6-4687-a715-299ee0c5dd25",
                Name = "Huawei",
                Slug = "huawei",
                Image = "huawei.jpg",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(brand8);

            var brand9 = new Brand()
            {
                Id = "be084f87-b383-4939-a1db-97c9d16ce295",
                Name = "Acer",
                Slug = "acer",
                Image = "acer.jpg",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(brand9);

        }

        public static void SeedProduct(EntityTypeBuilder<Product> builder)
        {
            var product1 = new Product()
            {
                Id = "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d",
                Name = "MacBook Pro 2018",
                Slug = "MacBook Pro 2018 Silver ",
                IsFeatured = true,
                IsOnSale = false,
                IsNew = false,
                ShortDescription = "MacBook Pro 2018 Silver 256 GB SSD ",
                Description = "Stokta 15 adet bulunan MacBook Pro 2018 çeşitli hediyeler ile toplam alımlarda %45 indirim ile vitrinimizde.",
                NewPrice = 13500,
                OldPrice = 15000,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 15,
                Weight = null,
                AdditionalInformation = "MacBook Pro 2018 Silver | 512 GB-256 GB-128 GB SSD çeşitleri | 16 GB RAM DDR5 | Ayrıca Hediyelerimiz: Çoklu USB portları,Apple mouse,harici dvd sürücü | ",
                MetaTitle = "Elektronik",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                BrandId = null,
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product1);

            var product2 = new Product()
            {
                Id = "7b4ff888-2e18-4490-b01a-76c4a7b3095b",
                Name = "iMac Pro Uzay Grisi",
                Slug = "imac pro uzay grisi",
                IsFeatured = true,
                IsOnSale = false,
                IsNew = false,
                ShortDescription = "iMac Pro Uzay Grisi ",
                Description = "iMac Pro Uzay Grisi 256 GB SSD | 16 GB RAM DDR5 | İntel i7-9900 3.2 Ghz | Hediyelerimiz: Uzay Grisi Klavye-Fare, Usb Çoğaltıcı, Harici DVD Sürücü, JPL Bluetooth Hoparlör",
                NewPrice = 25000,
                OldPrice = 30000,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 25,
                Weight = null,
                AdditionalInformation = "Hediyelerimiz bütün iMac ve Apple Pc'lerde geçerlidir.",
                MetaTitle = "Elektronik",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                BrandId = "e8840d39-abf2-4577-bfa5-a92144107b09",
                StoreId = "f544e6dd-70c7-4c99-834e-8147e1bff9f1",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product2);

            var product3 = new Product()
            {
                Id = "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0",
                Name = "iPhone 6 S 64 GB",
                Slug = "iPhone 6 S 64 GB Gümüş",
                IsFeatured = false,
                IsOnSale = true,
                IsNew = false,
                ShortDescription = "iPhone 6 S 64 GB Gümüş",
                Description = "iPhone 6 S 64 GB Gümüş | Hediyelerimiz: Kulaklık, Orjinal Bataryalı Kılıf, İki Uçlu Usb Bellek ",
                NewPrice = 2750,
                OldPrice = 2900,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 25,
                Weight = null,
                AdditionalInformation = "Hediyelerimiz bütün iPhone modellerinde geçerlidir.",
                MetaTitle = "Elektronik",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "4b64df99-8909-4fb4-bc23-9a84e5063f27",
                BrandId = "e8840d39-abf2-4577-bfa5-a92144107b09",
                StoreId = "5b843cf0-b7a5-475f-b22e-57054c54ba14",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product3);

            var product4 = new Product()
            {
                Id = "4330ef04-db35-4358-936a-d4db324d4fed",
                Name = "Samsung Galaxy Note 9 512 GB",
                Slug = "Samsung Galaxy Note 9 Note 9 512 GB Okyanus Mavisi",
                IsFeatured = false,
                IsOnSale = false,
                IsNew = true,
                ShortDescription = "Samsung Galaxy Note 9 512 GB Okyanus Mavisi",
                Description = "Samsung Galaxy Note 9 512 GB Okyanus Mavisi",
                NewPrice = 5200,
                OldPrice = 0,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 30,
                Weight = null,
                AdditionalInformation = "Piyasanın çok altında satıyoruz herkes kullansın diye.",
                MetaTitle = "Elektronik",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "4b64df99-8909-4fb4-bc23-9a84e5063f27",
                BrandId = "45ee14ef-d408-47e3-b104-01a9e23c5def",
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product4);

            var product5 = new Product()
            {
                Id = "fe01d29b-f753-4b89-a6e8-a502de6cfbe1",
                Name = "Apple AirPods Kulaklık ",
                Slug = "apple airpods kulaklık",
                IsFeatured = false,
                IsOnSale = true,
                IsNew = false,
                ShortDescription = "Apple AirPods Kulaklık",
                Description = "Apple AirPods Kulaklık | Hediyelerimiz: Yedek Parçaları Orjinal, Yedek Şarjı",
                NewPrice = 930,
                OldPrice = 1000,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 30,
                Weight = null,
                AdditionalInformation = "Bütün AirPodslarda hediyelerimiz geçerlidir.",
                MetaTitle = "Elektronik",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "8da13d65-1efb-40ea-b88f-08b06d0776ab",
                BrandId = "e8840d39-abf2-4577-bfa5-a92144107b09",
                StoreId = "f544e6dd-70c7-4c99-834e-8147e1bff9f1",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product5);

            var product6 = new Product()
            {
                Id = "7fdad843-e55c-4003-8b6a-486344e6d8cb",
                Name = " Pembe Yasin-i Şerif ve Sureler Kitabı",
                Slug = "Pembe Yasin-i Şerif ve Sureler Kitabı",
                IsFeatured = true,
                IsOnSale = false,
                IsNew = false,
                ShortDescription = "Pembe Yasin-i Şerif ve Sureler Kitabı",
                Description = "Pembe Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih ",
                NewPrice = 2,
                OldPrice = 4,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 15,
                Weight = null,
                AdditionalInformation = "Pembe Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih",
                MetaTitle = "Hediyelik Kitap",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                BrandId = null,
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product6);

            var product7 = new Product()
            {
                Id = "cd9d729e-b245-4606-b480-4e90b94a3882",
                Name = " Mavi Yasin-i Şerif ve Sureler Kitabı",
                Slug = "Mavi Yasin-i Şerif ve Sureler Kitabı",
                IsFeatured = true,
                IsOnSale = false,
                IsNew = false,
                ShortDescription = "Mavi Yasin-i Şerif ve Sureler Kitabı",
                Description = "Mavi Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih ",
                NewPrice = 2,
                OldPrice = 4,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 15,
                Weight = null,
                AdditionalInformation = "Mavi Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih",
                MetaTitle = "Hediyelik Kitap",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                BrandId = null,
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product7);

            var product8 = new Product()
            {
                Id = "700fe299-bb99-47a1-acd5-d614016a374e",
                Name = " Kırmızı Yasin-i Şerif ve Sureler Kitabı",
                Slug = "Kırmızı Yasin-i Şerif ve Sureler Kitabı",
                IsFeatured = true,
                IsOnSale = false,
                IsNew = false,
                ShortDescription = "Kırmızı Yasin-i Şerif ve Sureler Kitabı",
                Description = "Kırmızı Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih ",
                NewPrice = 2,
                OldPrice = 4,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 15,
                Weight = null,
                AdditionalInformation = "Kırmızı Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih",
                MetaTitle = "Hediyelik Kitap",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                BrandId = null,
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product8);

            var product9 = new Product()
            {
                Id = "5e575e49-7724-4527-9ee9-15f4718c0778",
                Name = "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti",
                Slug = "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti",
                IsFeatured = true,
                IsOnSale = false,
                IsNew = false,
                ShortDescription = "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti",
                Description = "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti",
                NewPrice = 3,
                OldPrice = 5,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 15,
                Weight = null,
                AdditionalInformation = "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti",
                MetaTitle = "Hediyelik Kitap",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                BrandId = null,
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product9);

            var product10 = new Product()
            {
                Id = "1db450c1-594b-4bed-b726-d4462a4d54f6",
                Name = "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk",
                Slug = "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk",
                IsFeatured = true,
                IsOnSale = false,
                IsNew = false,
                ShortDescription = "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk",
                Description = "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk",
                NewPrice = 89,
                OldPrice = 0,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 15,
                Weight = null,
                AdditionalInformation = "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk",
                MetaTitle = "Hediyelik Kitap",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                BrandId = null,
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product10);

            var product11 = new Product()
            {
                Id = "48ffccbf-b72e-4328-a5eb-cf487863589c",
                Name = "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk",
                Slug = "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk",
                IsFeatured = true,
                IsOnSale = false,
                IsNew = false,
                ShortDescription = "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk",
                Description = "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk",
                NewPrice = 89,
                OldPrice = 0,
                Discount = 0,
                Cost = 0,
                Tax = 0,
                RatingsCount = 5,
                RatingsValue = 4,
                AvailabilityCount = 15,
                Weight = null,
                AdditionalInformation = "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk",
                MetaTitle = "Hediyelik Kitap",
                MetaDescription = null,
                MetaKeywords = null,
                CategoryId = "42729bdd-3160-41f8-b1a6-c68ead8e314d",
                BrandId = null,
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(product11);


        }

        public static void SeedProductPhoto(EntityTypeBuilder<ProductPhoto> builder)
        {
            var productPhoto1 = new ProductPhoto()
            {
                Id = "3e4cc993-9f23-4bb7-a943-59c3cf7fc166",
                Medium = "macBookPro2018.jpg",
                Small = "macBookPro2018.jpg",
                Large = "macBookPro2018.jpg",
                Alt = "MacBook Pro 2018 Silver ",
                ProductId = "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto1);

            var productPhoto2 = new ProductPhoto()
            {
                Id = "cf363e7a-b99a-425f-8d07-50487081049b",
                Medium = "iMacPro.jpg",
                Small = "iMacPro.jpg",
                Large = "iMacPro.jpg",
                Alt = "iMac Pro Uzay Grisi",
                ProductId = "7b4ff888-2e18-4490-b01a-76c4a7b3095b",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto2);

            var productPhoto3 = new ProductPhoto()
            {
                Id = "12c5d0df-7ac8-4a6c-8f59-aa4037940c1b",
                Medium = "iPhone664.jpg",
                Small = "iPhone664.jpg",
                Large = "iPhone664.jpg",
                Alt = "iPhone 6 S 64 GB Gümüş",
                ProductId = "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto3);

            var productPhoto4 = new ProductPhoto()
            {
                Id = "85dfb6e4-908d-45c1-b414-a488b6891197",
                Medium = "samsungnote9.jpg",
                Small = "samsungnote9.jpg",
                Large = "samsungnote9.jpg",
                Alt = "Samsung Galaxy Note 9 512 GB Okyanus Mavisi",
                ProductId = "4330ef04-db35-4358-936a-d4db324d4fed",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto4);

            var productPhoto5 = new ProductPhoto()
            {
                Id = "d5266161-dff1-4c09-9a36-d84ac5cc3b1b",
                Medium = "airpods.jpg",
                Small = "airpods.jpg",
                Large = "airpods.jpg",
                Alt = "Apple AirPods Kulaklık ",
                ProductId = "fe01d29b-f753-4b89-a6e8-a502de6cfbe1",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto5);

            var productPhoto6 = new ProductPhoto()
            {
                Id = "54a82e8b-de71-4f99-9841-4431e78b7552",
                Medium = "duakitabıp.jpg",
                Small = "duakitabıp.jpg",
                Large = "duakitabıp.jpg",
                Alt = "Yasin-i Şerif ve Bazı Sureler Pembe Kitap ",
                ProductId = "7fdad843-e55c-4003-8b6a-486344e6d8cb",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto6);

            var productPhoto7 = new ProductPhoto()
            {
                Id = "077e4e64-313e-4d4e-a340-5c84e0a3d748",
                Medium = "duakitabım.jpg",
                Small = "duakitabım.jpg",
                Large = "duakitabım.jpg",
                Alt = "Yasin-i Şerif ve Bazı Sureler Mavi Kitap ",
                ProductId = "cd9d729e-b245-4606-b480-4e90b94a3882",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto7);

            var productPhoto8 = new ProductPhoto()
            {
                Id = "df2bd20c-176a-4392-a918-f0e8509c9161",
                Medium = "duakitabık.jpg",
                Small = "duakitabık.jpg",
                Large = "duakitabık.jpg",
                Alt = "Yasin-i Şerif ve Bazı Sureler Kırmızı Kitap ",
                ProductId = "700fe299-bb99-47a1-acd5-d614016a374e",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto8);

            var productPhoto9 = new ProductPhoto()
            {
                Id = "7778feda-520c-4157-a80e-0bee5ee57511",
                Medium = "kurantesbih.jpg",
                Small = "kurantesbih.jpg",
                Large = "kurantesbih.jpg",
                Alt = "Kabe Desenli Yasin ve Tül Keseli Tespih Seti",
                ProductId = "5e575e49-7724-4527-9ee9-15f4718c0778",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto9);

            var productPhoto10 = new ProductPhoto()
            {
                Id = "f9a0eaa5-2934-4097-8c09-551d3cf8b48b",
                Medium = "50adettesbih.jpg",
                Small = "50adettesbih.jpg",
                Large = "50adettesbih.jpg",
                Alt = "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk",
                ProductId = "1db450c1-594b-4bed-b726-d4462a4d54f6",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto10);

            var productPhoto11 = new ProductPhoto()
            {
                Id = "c7e447b9-fcbe-43e7-a46c-1a578400fa8e",
                Medium = "50adettesbihs.jpg",
                Small = "50adettesbihs.jpg",
                Large = "50adettesbihs.jpg",
                Alt = "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk",
                ProductId = "48ffccbf-b72e-4328-a5eb-cf487863589c",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(productPhoto11);
        }
        public static void SeedReview(EntityTypeBuilder<Review> builder)
        {
            var review1 = new Review()
            {
                Id = "86b27fee-aa1a-4552-9bcd-6c8100b11138",
                Name = "Emir Demirci",
                Email = "karmaillegal57@gmail.com",
                Body = "Çok iyi bir telefon elimde şu an",
                Rating = 0,
                IsApproved = false,
                ApprovedBy = null,
                ProductId = "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(review1);

            var review2 = new Review()
            {
                Id = "a93dffde-741e-45bc-8aab-8976e03c172d",
                Name = "Murat Demirci",
                Email = "mdemirci@outlook.com",
                Body = "Çok iyi bir telefon elimde şu an",
                Rating = 0,
                IsApproved = false,
                ApprovedBy = null,
                ProductId = "4330ef04-db35-4358-936a-d4db324d4fed",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(review2);

            var review3 = new Review()
            {
                Id = "c35776e9-c002-4af9-8553-eb9e466b8910",
                Name = "Yasin Demirci",
                Email = "ydemirci@outlook.com",
                Body = "Çok iyi bir notebook.",
                Rating = 0,
                IsApproved = false,
                ApprovedBy = null,
                ProductId = "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(review3);

            var review4 = new Review()
            {
                Id = "a19e279f-65b3-4b9d-b658-037c9b763aac",
                Name = "Cihan Demirci",
                Email = "cdemirci@outlook.com",
                Body = "Çok iyi bir notebook.",
                Rating = 0,
                IsApproved = false,
                ApprovedBy = null,
                ProductId = "7b4ff888-2e18-4490-b01a-76c4a7b3095b",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(review4);

            var review5 = new Review()
            {
                Id = "ad673d9a-ff2d-4cb0-bcac-5587f08d2ffc",
                Name = "Meryem Demirci",
                Email = "medemirci@outlook.com",
                Body = "Çok iyi bir kulaklık.",
                Rating = 0,
                IsApproved = false,
                ApprovedBy = null,
                ProductId = "fe01d29b-f753-4b89-a6e8-a502de6cfbe1",
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedBy = "username",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "username"
            };
            builder.HasData(review5);
        }

        public static void SeedAdvertisement(EntityTypeBuilder<Advertisement> builder)
        {
            var advertisement = new Advertisement()
            {
                Id = "06edb6a0-30d0-498c-a380-45561360b347",
                Title = "Yeni Notebooklar",
                SubTitle = "%30 İndirimlerle",
                Html = "notebook",
                Image = "macBookAir.jpg",
                Location = "0",
                Style = ""
            };
            builder.HasData(advertisement);

            var advertisement1 = new Advertisement()
            {
                Id = "f2fb95c1-2c3d-4c80-914d-56fa25aabd03",
                Title = "Yeni Cep Telefonlar",
                SubTitle = "2018 Model",
                Html = "Yeni telefonlar",
                Image = "yenitelefon.jpg",
                Location = "1",
                Style = "",
                ButtonText = null,
                Url = null
            };
            builder.HasData(advertisement1);

            var advertisement2 = new Advertisement()
            {
                Id = "2ac117b2-466b-4cd5-abf8-1843e40ef53e",
                Title = "Yeni Saatler",
                SubTitle = "2018 Model",
                Html = "Yeni saatler",
                Image = "yenisaatler.jpg",
                Location = "2",
                Style = "",
                ButtonText = null,
                Url = null
            };
            builder.HasData(advertisement2);

            var advertisement3 = new Advertisement()
            {
                Id = "43f5f97e-c1ed-46b4-8f2b-76461b96244f",
                Title = "Yeni Güneş Gözlükleri",
                SubTitle = "2018 Model",
                Html = "Yeni Gözlük",
                Image = "yenigunesgozluk.jpg",
                Location = "3",
                Style = "",
                ButtonText = null,
                Url = null
            };
            builder.HasData(advertisement3);


            var advertisement4 = new Advertisement()
            {
                Id = "ab7eb932-7930-401a-9414-a598fc0b71f2",
                Title = "Yeni Model Ayakkabılar",
                SubTitle = "2018 Model",
                Html = "Yeni Ayakkabılar",
                Image = "yeniayakkabi.jpg",
                Location = "4",
                Style = "",
                ButtonText = null,
                Url = null
            };
            builder.HasData(advertisement4);

            var advertisement5 = new Advertisement()
            {
                Id = "e1e2c415-1b92-4325-b826-25ffad381878",
                Title = "Yeni Model Takılar",
                SubTitle = "2018 Model",
                Html = "Yeni Takılar",
                Image = "yenitakilar.jpg",
                Location = "5",
                Style = "",
                ButtonText = null,
                Url = null
            };
            builder.HasData(advertisement5);

        }

        public static void SeedStore(EntityTypeBuilder<Store> builder)
        {
            var store1 = new Store()
            {
                Id = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                Name = "Vatan Bilgisayar",
                Slug = "http://www.vatanbilgisayar.com",
                Owner = "mdemirci01@outlook.com",
                Logo = "vatan.jpg",
                ContactName = "Murat Demirci",
                ContactPhone = "05395675645",
                ContactEmail = "emir.dmrc57@gmail.com",
                Address = "Üsküdar",
                Description = "",

            };
            builder.HasData(store1);

            var store2 = new Store()
            {
                Id = "5b843cf0-b7a5-475f-b22e-57054c54ba14",
                Name = "AppStore1",
                Slug = "http://www.hepsiburada.com",
                Owner = "emirdemirci721@gmail.com",
                Logo = "appstore1.jpg",
                ContactName = "Emir Demirci",
                ContactPhone = "05301564531",
                ContactEmail = "karmaillegal57@gmail.com",
                Address = "Yeşilpınar Mah. Girne Cad. No:14 Daire:12",
                Description = "",

            };
            builder.HasData(store2);

            var store3 = new Store()
            {
                Id = "f544e6dd-70c7-4c99-834e-8147e1bff9f1",
                Name = "Teknosa",
                Slug = "http://www.teknosa.com",
                Owner = "karmaillegal57@gmail.com",
                Logo = "teknosa.jpg",
                ContactName = "Yasin Demirci",
                ContactPhone = "05678954567",
                ContactEmail = "edmrc57@gmail.com",
                Address = "Eyüp",
                Description = "Teknosa Herkes İçin Teknoloji"

            };
            builder.HasData(store3);

        }

        private static void SeedStoreBrand(EntityTypeBuilder<StoreBrand> builder)
        {
            var storeBrand1 = new StoreBrand()
            {
                Id = "ecc78fd7-fafc-4969-be4f-193ed1f84532",
                StoreId = "f544e6dd-70c7-4c99-834e-8147e1bff9f1",
                BrandId = "6d85aacb-8f1b-4488-b5bd-5390b9cd76c6"
            };
            builder.HasData(storeBrand1);

            var storeBrand2 = new StoreBrand()
            {
                Id = "86dcccf4-3481-4e07-8ec9-0bcbbd90b1ad",
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                BrandId = "45ee14ef-d408-47e3-b104-01a9e23c5def"
            };
            builder.HasData(storeBrand2);

            var storeBrand3 = new StoreBrand()
            {
                Id = "ad83d190-64b9-4828-aded-af481dbc8934",
                StoreId = "5b843cf0-b7a5-475f-b22e-57054c54ba14",
                BrandId = "e8840d39-abf2-4577-bfa5-a92144107b09"
            };
            builder.HasData(storeBrand3);
        }


        private static void SeedOrder(EntityTypeBuilder<Order> builder)
        {
            var order1 = new Order()
            {
                Id = "3349a57f-2dcb-4b9b-922f-7c134517bd47",
                UserName = "emir",
                OrderDate = new DateTime(2019 - 02 - 25),
                DemandDate = new DateTime(2019 - 02 - 27),
                OrderCode = "204723561283",
                //Quantity = 2,
                DeliveryAddressId = "440eb108-0a22-4e9c-a5fb-df0f43a92558",
                InvoiceAddressId = "c3f70794-26a5-4386-b6d6-09dec963b210"

            };
            builder.HasData(order1);

            var order2 = new Order()
            {
                Id = "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f",
                UserName = "emir",
                OrderDate = new DateTime(2019 - 02 - 26),
                DemandDate = new DateTime(2019 - 02 - 28),
                OrderCode = "204723561286",
                //Quantity = 2,
                DeliveryAddressId = "440eb108-0a22-4e9c-a5fb-df0f43a92558",
                InvoiceAddressId = "c3f70794-26a5-4386-b6d6-09dec963b210"

            };
            builder.HasData(order2);

            var order3 = new Order()
            {
                Id = "51c16d53-3f56-4b7f-b652-37d546811f6b",
                UserName = "emir",
                OrderDate = new DateTime(2019 - 02 - 27),
                DemandDate = new DateTime(2019 - 03 - 01),
                OrderCode = "204723561287",
                //Quantity = 3,
                DeliveryAddressId = "440eb108-0a22-4e9c-a5fb-df0f43a92558",
                InvoiceAddressId = "c3f70794-26a5-4386-b6d6-09dec963b210"


            };
            builder.HasData(order3);

            var order4 = new Order()
            {
                Id = "cb93a8b3-c1d6-4c2c-8878-ea91e7e6864c",
                UserName = "emir",
                OrderDate = new DateTime(2019 - 02 - 08),
                DemandDate = new DateTime(2019 - 03 - 02),
                OrderCode = "204723561288",
                //Quantity = 1,
                DeliveryAddressId = "440eb108-0a22-4e9c-a5fb-df0f43a92558",
                InvoiceAddressId = "c3f70794-26a5-4386-b6d6-09dec963b210"

            };
            builder.HasData(order4);

            var order5 = new Order()
            {
                Id = "e4c732da-9f37-4015-b12b-d2d858dfa03a",
                UserName = "emir",
                OrderDate = new DateTime(2019 - 02 - 29),
                DemandDate = new DateTime(2019 - 03 - 03),
                OrderCode = "204723561281",
                //Quantity = 2,
                DeliveryAddressId = "440eb108-0a22-4e9c-a5fb-df0f43a92558",
                InvoiceAddressId = "c3f70794-26a5-4386-b6d6-09dec963b210"

            };
            builder.HasData(order5);
        }

        private static void SeedShipper(EntityTypeBuilder<Shipper> builder)
        {
            var shipper1 = new Shipper()
            {
                Id = "8a8f0d2c-cc86-4d11-98d8-eb30847859a7",
                Name = "Sürat Kargo",
                Url = "http://www.suratkargo.com"

            };
            builder.HasData(shipper1);

            var shipper2 = new Shipper()
            {
                Id = "5a240eef-d844-4341-811e-3b2377920a5d",
                Name = "MNG Kargo",
                Url = "http://www.mngkargo.com"

            };
            builder.HasData(shipper2);

            var shipper3 = new Shipper()
            {
                Id = "dc20a22d-51d7-439c-9898-1015954cdbbd",
                Name = "Yurtiçi Kargo",
                Url = "http://www.yurticikargo.com"

            };
            builder.HasData(shipper3);

            var shipper4 = new Shipper()
            {
                Id = "a54ae47b-f94b-4bf8-ab1c-fffabd092012",
                Name = "Aras Kargo",
                Url = "http://www.araskargo.com"

            };
            builder.HasData(shipper4);

        }

        private static void SeedOrderItem(EntityTypeBuilder<OrderItem> builder)
        {
            var orderItem1 = new OrderItem()
            {
                Id = "c96f1242-aeef-458b-95f5-3a1af309e286",
                OrderId = "51c16d53-3f56-4b7f-b652-37d546811f6b",
                ProductId = "4330ef04-db35-4358-936a-d4db324d4fed",
                Quantity = 2,
                ShipperId = "8a8f0d2c-cc86-4d11-98d8-eb30847859a7",
                Name = "Deneme",
                ShortDescription = "Açıklama"
            };
            builder.HasData(orderItem1);

            var orderItem2 = new OrderItem()
            {
                Id = "97d763e3-04ab-4fc3-ba6f-28742f582630",
                OrderId = "cb93a8b3-c1d6-4c2c-8878-ea91e7e6864c",
                ProductId = "7b4ff888-2e18-4490-b01a-76c4a7b3095b",
                Quantity = 1,
                ShipperId = "5a240eef-d844-4341-811e-3b2377920a5d",
                Name = "Deneme",
                ShortDescription = "Açıklama"
            };
            builder.HasData(orderItem2);

            var orderItem3 = new OrderItem()
            {
                Id = "75711118-3cf5-484d-910d-8897403583b0",
                OrderId = "3349a57f-2dcb-4b9b-922f-7c134517bd47",
                ProductId = "4330ef04-db35-4358-936a-d4db324d4fed",
                Quantity = 2,
                ShipperId = "dc20a22d-51d7-439c-9898-1015954cdbbd",
                Name = "Deneme",
                ShortDescription = "Açıklama"
            };
            builder.HasData(orderItem3);

            var orderItem4 = new OrderItem()
            {
                Id = "787b2292-70fa-4c94-b8b3-4e0ccea4a00a",
                OrderId = "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f",
                ProductId = "4330ef04-db35-4358-936a-d4db324d4fed",
                Quantity = 1,
                ShipperId = "a54ae47b-f94b-4bf8-ab1c-fffabd092012",
                Name = "Deneme",
                ShortDescription = "Açıklama"
            };
            builder.HasData(orderItem4);

            var orderItem5 = new OrderItem()
            {
                Id = "b010d994-29ef-4f37-a175-da7f3d98159e",
                OrderId = "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f",
                Quantity = 3,
                ProductId = "7b4ff888-2e18-4490-b01a-76c4a7b3095b",
                ShipperId = "8a8f0d2c-cc86-4d11-98d8-eb30847859a7",
                Name = "Deneme",
                ShortDescription = "Açıklama"
            };
            builder.HasData(orderItem5);

            var orderItem6 = new OrderItem()
            {
                Id = "7ace5a6d-1d8d-47db-939f-97d770746c12",
                OrderId = "e4c732da-9f37-4015-b12b-d2d858dfa03a",
                ProductId = "fe01d29b-f753-4b89-a6e8-a502de6cfbe1",
                Quantity = 2,
                ShipperId = "5a240eef-d844-4341-811e-3b2377920a5d",
                Name = "Deneme",
                ShortDescription = "Açıklama"
            };
            builder.HasData(orderItem6);

            var orderItem7 = new OrderItem()
            {
                Id = "a10f1ef4-9bb8-4378-acdc-d6303d594a4d",
                OrderId = "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f",
                ProductId = "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d",
                Quantity = 1,
                ShipperId = "dc20a22d-51d7-439c-9898-1015954cdbbd",
                Name = "Deneme",
                ShortDescription = "Açıklama"
            };
            builder.HasData(orderItem7);

            var orderItem8 = new OrderItem()
            {
                Id = "55d69686-2ae8-4060-8e78-8538d484cbe9",
                OrderId = "51c16d53-3f56-4b7f-b652-37d546811f6b",
                ProductId = "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0",
                Quantity = 1,
                ShipperId = "a54ae47b-f94b-4bf8-ab1c-fffabd092012",
                Name = "Deneme",
                ShortDescription = "Açıklama"
            };
            builder.HasData(orderItem8);
        }

        private static void SeedAddress(EntityTypeBuilder<Address> builder)
        {
            var address1 = new Address()
            {
                Id = "c3f70794-26a5-4386-b6d6-09dec963b210",
                FirstName = "Emir",
                MiddleName = "Sezer",
                LastName = "Demirci",
                Company = "",
                Email = "edmrc58@gmail.com",
                CityId = "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba",
                CountryId = "820b84fc-a4e0-4f56-a34f-e752287d7e52",
                DistrictId = "5c8d78df-6a68-4d2a-abe9-bc5638d91fa3",
                AddressDescription = "Yeşilpınar Mah. Üsküp Sok. No:20  Daire:15",
                PostalCode = "34122",
                Phone = "053456789046",
                InvoiceType = 0,
                IdentityNumber = "23456789567",

            };
            builder.HasData(address1);

            var address2 = new Address()
            {
                Id = "440eb108-0a22-4e9c-a5fb-df0f43a92558",
                FirstName = "Emir",
                MiddleName = "Sezer",
                LastName = "Demirci",
                Email = "karmaillegal57@gmail.com",
                Company = "",
                CityId = "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba",
                CountryId = "820b84fc-a4e0-4f56-a34f-e752287d7e52",
                DistrictId = "5c8d78df-6a68-4d2a-abe9-bc5638d91fa3",
                AddressDescription = "Yeşilpınar Mah. Çoşkun Sok. No:20  Daire:15",
                PostalCode = "34132",
                Phone = "053356383046",
                InvoiceType = 0,
                IdentityNumber = "23333389567",

            };
            builder.HasData(address2);

            var address3 = new Address()
            {
                Id = "19f1a6cc-8e89-4efa-9ea1-8255f3a4616b",
                FirstName = "Yasin",
                MiddleName = "",
                LastName = "Demirci",
                Email = "ydmrc57@gmail.com",
                Company = "İstanbul Ağaç ve Peyzaj A.Ş",
                CityId = "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba",
                CountryId = "820b84fc-a4e0-4f56-a34f-e752287d7e52",
                DistrictId = "5c8d78df-6a68-4d2a-abe9-bc5638d91fa3",
                AddressDescription = "Mimar Sinan Mah. Zenciler Sok. No:10 Daire:9",
                PostalCode = "34533",
                Phone = "05301567890",
                InvoiceType = 0,
                IdentityNumber = "23891540669",


            };
            builder.HasData(address3);

        }

        private static void SeedCountry(EntityTypeBuilder<Country> builder)
        {
            var country1 = new Country()
            {
                Id = "820b84fc-a4e0-4f56-a34f-e752287d7e52",
                Name = "Turkey"

            };
            builder.HasData(country1);

            var country2 = new Country()
            {
                Id = "f356f493-c46a-48d2-8908-64deeb51e92f",
                Name = "Germany"

            };
            builder.HasData(country2);
        }

        private static void SeedCity(EntityTypeBuilder<City> builder)
        {
            var city1 = new City()
            {
                Id = "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba",
                Name = "Istanbul",
                CountryId = "820b84fc-a4e0-4f56-a34f-e752287d7e52",

            };
            builder.HasData(city1);

            var city2 = new City()
            {
                Id = "7c51c498-8047-4665-bec9-48283eb8de8e",
                Name = "Berlin",
                CountryId = "f356f493-c46a-48d2-8908-64deeb51e92f",

            };
            builder.HasData(city2);

        }
        private static void SeedDistrict(EntityTypeBuilder<District> builder)
        {
            var ilce1 = new District()
            {
                Id = "5c8d78df-6a68-4d2a-abe9-bc5638d91fa3",
                Name = "Üsküdar",
                CityId = "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba",

            };
            builder.HasData(ilce1);

            var ilce2 = new District()
            {
                Id = "6c438a90-833a-48a1-9c4e-bda2820abcbe",
                Name = "Mitte",
                CityId = "7c51c498-8047-4665-bec9-48283eb8de8e",

            };
            builder.HasData(ilce2);
        }

        private static void SeedCoupon(EntityTypeBuilder<Coupon> builder)
        {
            var coupon1 = new Coupon()
            {
                Id = "b52b6f2d-b8af-4536-ab90-c3cbc57deedf",
                CouponNo = "8414727",
                Name = "Size Özel 133 TL Kupon",
                OrderId = "3349a57f-2dcb-4b9b-922f-7c134517bd47",
                StartDate = new DateTime(2019, 02, 21),
                EndDate = new DateTime(2019, 03, 20),
                ForStoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                MinTotalPrice = 5.500M,
                Discount = 133M,
                Conditions = "5.500.00 TL üzeri alışverişlerde geçerlidir."

            };
            builder.HasData(coupon1);

            var coupon2 = new Coupon()
            {
                Id = "8d43b37c-47c2-4229-90c4-e0348c603890",
                CouponNo = "8514212",
                Name = "Size Özel 90 TL Kupon",
                OrderId = "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f",
                StartDate = new DateTime(2019, 02, 21),
                EndDate = new DateTime(2019, 03, 30),
                ForStoreId = "f544e6dd-70c7-4c99-834e-8147e1bff9f1",
                MinTotalPrice = 1.500M,
                Discount = 90M,
                Conditions = "3.500.00 TL üzeri alışverişlerde geçerlidir."

            };
            builder.HasData(coupon2);
        }

        private static void SeedProductQuestion(EntityTypeBuilder<ProductQuestion> builder)
        {
            var productQuestion1 = new ProductQuestion()
            {
                Id = "5a08fa86-8ef2-4e9b-b690-58fd3569d0da",
                ProductId = "4330ef04-db35-4358-936a-d4db324d4fed",
                QuestionCategoryId = "c91699f8-0688-4bf5-926d-9f445191a97e",
                StoreId = "6ad3fd8a-9b43-440d-bd83-fcf033101d9d",
                Title = "Kargo firmanız hale ürünü getirmedi.",
                ShareDate = new DateTime(2019, 02, 21),
                IsPublic = true,
                Description = "Açıklama"
            };
            builder.HasData(productQuestion1);
        }

        private static void SeedQuestionCategory(EntityTypeBuilder<QuestionCategory> builder)
        {
            var quantityCategory1 = new QuestionCategory()
            {
                Id = "c91699f8-0688-4bf5-926d-9f445191a97e",
                Name = "Kargo"
            };
            builder.HasData(quantityCategory1);
        }
    }
}
