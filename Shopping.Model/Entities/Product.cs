using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Images = new HashSet<ProductPhoto>();
            Reviews = new HashSet<Review>();
            ProductColors = new HashSet<ProductColor>();
            Wishlists = new HashSet<Wishlist>();
            OrderItems = new HashSet<OrderItem>();
            ProductQuestions = new HashSet<ProductQuestion>();
            CartItems = new HashSet<CartItem>();
            Condition = Condition.NotSpecified;
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsNew { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Cost { get; set; }
        public Currency Currency { get; set; }
        public float Tax { get; set; }
        public int RatingsCount { get; set; }
        public float RatingsValue { get; set; }
        public int AvailabilityCount { get; set; }
        public Condition Condition { get; set; }
        public float? Weight { get; set; }
        public string AdditionalInformation { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public virtual ICollection<ProductPhoto> Images { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public string CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
        public string StoreId { get; set; }
        public Store Store { get; set; }

        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductQuestion> ProductQuestions { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

    }
}
