using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class StoreBrandBuilder
    {
        public StoreBrandBuilder(EntityTypeBuilder<StoreBrand> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasOne(b => b.Store).WithMany(p => p.StoreBrands).HasForeignKey(c => c.StoreId);
            builder.HasOne(b => b.Brand).WithMany(p => p.StoreBrands).HasForeignKey(c => c.BrandId);
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
