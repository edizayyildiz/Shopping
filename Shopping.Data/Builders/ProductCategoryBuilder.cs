using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class ProductCategoryBuilder
    {
        public ProductCategoryBuilder(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Slug).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Photo).HasMaxLength(200);
            builder.HasMany(b => b.Childs).WithOne(c => c.Parent).HasForeignKey(p => p.ParentId);
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
