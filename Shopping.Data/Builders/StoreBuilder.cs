using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class StoreBuilder
    {
        public StoreBuilder(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Slug).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Owner).IsRequired().HasMaxLength(200);
            builder.Property(b => b.ContactName).IsRequired().HasMaxLength(200);
            builder.Property(b => b.ContactPhone).IsRequired().HasMaxLength(200);
            builder.Property(b => b.ContactEmail).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Address).IsRequired().HasMaxLength(500);
            builder.Property(b => b.Description).IsRequired().HasMaxLength(400);
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
