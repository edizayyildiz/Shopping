using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
     public class AddressBuilder
    {
        public AddressBuilder(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(b => b.LastName).IsRequired().HasMaxLength(100);
            builder.Property(b => b.MiddleName).HasMaxLength(100);
            builder.Property(b => b.Email).HasMaxLength(100);
            builder.Property(b => b.Company).HasMaxLength(200);
            builder.Property(b => b.IdentityNumber).HasMaxLength(100);

            builder.HasOne(b => b.City).WithMany(c => c.Addresses).HasForeignKey(p => p.CityId);
            builder.HasOne(b => b.Country).WithMany(c => c.Addresses).HasForeignKey(p => p.CountryId);
            builder.HasOne(b => b.District).WithMany(c => c.Addresses).HasForeignKey(p => p.DistrictId);
           



            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
