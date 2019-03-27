using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class DistrictBuilder
    {
        public DistrictBuilder(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(b => b.City).WithMany(c => c.Districts).HasForeignKey(p => p.CityId);


            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
