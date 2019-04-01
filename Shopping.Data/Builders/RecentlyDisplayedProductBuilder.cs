using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class RecentlyDisplayedProductBuilder
    {
        public RecentlyDisplayedProductBuilder(EntityTypeBuilder<RecentlyDisplayedProduct> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.UserName).IsRequired().HasMaxLength(100);
            builder.HasOne(b => b.Product).WithMany(c => c.RecentlyDisplayedProducts).HasForeignKey(p => p.ProductId);

            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
