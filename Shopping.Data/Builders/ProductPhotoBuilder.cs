using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class ProductPhotoBuilder
    {
        public ProductPhotoBuilder(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Medium).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Small).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Large).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Alt).IsRequired().HasMaxLength(4000);

            builder.HasOne(b => b.Product).WithMany(c => c.Images).HasForeignKey(p => p.ProductId);
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
