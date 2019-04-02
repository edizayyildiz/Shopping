using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class CartItemBuilder
    {
        public CartItemBuilder(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Cart).WithMany(w => w.CartItems).HasForeignKey(p => p.CartId);
            builder.HasOne(p => p.Product).WithMany(w => w.CartItems).HasForeignKey(p => p.ProductId);
        }
    }
}
