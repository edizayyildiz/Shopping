using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class WishlistBuilder
    {
        public WishlistBuilder(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(e => new { e.UserName, e.ProductId, e.IsDeleted }).IsUnique();
            builder.HasOne(b => b.Product).WithMany(p => p.Wishlists).HasForeignKey(c => c.ProductId);
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
