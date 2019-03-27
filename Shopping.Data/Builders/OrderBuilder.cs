using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class OrderBuilder
    {
        public OrderBuilder(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.UserName).HasMaxLength(50);
            builder.Property(o => o.OrderCode).IsRequired().HasMaxLength(50);
            builder.HasOne(o => o.DeliveryAddress).WithMany(o => o.OrdersToDeliver).HasForeignKey(o => o.DeliveryAddressId);
            builder.HasOne(o => o.InvoiceAddress).WithMany(o => o.OrdersToInvoice).HasForeignKey(o => o.InvoiceAddressId);
            builder.HasOne(o => o.Store).WithMany(o => o.Orders).HasForeignKey(o => o.StoreId);
            builder.HasMany(o => o.OrderItems).WithOne(o => o.Order).HasForeignKey(o => o.OrderId);

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}
