using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class ProductBuilder
    {
        public ProductBuilder(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Slug).IsRequired().HasMaxLength(200);
            builder.Property(b => b.MetaTitle).HasMaxLength(200);
            builder.Property(b => b.MetaDescription).HasMaxLength(500);
            builder.Property(b => b.ShortDescription).IsRequired().HasMaxLength(4000);
            builder.HasOne(b => b.Brand).WithMany(c => c.Products).HasForeignKey(p => p.BrandId);
            builder.HasOne(b => b.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            builder.HasOne(b => b.Store).WithMany(c => c.Products).HasForeignKey(p => p.StoreId);

            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
