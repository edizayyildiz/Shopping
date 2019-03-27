using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class OrderItemBuilder
    {
        public OrderItemBuilder(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.Product).WithMany(o => o.OrderItems).HasForeignKey(o => o.ProductId);
            builder.HasOne(o => o.Shipper).WithMany(o => o.OrderItems).HasForeignKey(o => o.ShipperId);
            builder.HasOne(o => o.Order).WithMany(o => o.OrderItems).HasForeignKey(o => o.OrderId);
            builder.HasOne(o => o.Category).WithMany(o => o.OrderItems).HasForeignKey(o => o.CategoryId);
            builder.HasOne(o => o.Brand).WithMany(o => o.OrdersItems).HasForeignKey(o => o.BrandId);
            builder.HasOne(o => o.Store).WithMany(o => o.OrderItems).HasForeignKey(o => o.StoreId);

            builder.Property(o => o.Name).IsRequired().HasMaxLength(200);
            builder.Property(o => o.ShortDescription).IsRequired().HasMaxLength(500);
            
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
