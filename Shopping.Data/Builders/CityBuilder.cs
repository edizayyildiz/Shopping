using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class CityBuilder
    {
        public CityBuilder(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(b => b.Country).WithMany(c => c.Cities).HasForeignKey(p => p.CountryId);

            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
