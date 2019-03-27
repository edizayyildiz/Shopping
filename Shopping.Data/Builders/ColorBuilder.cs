using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Model.Entities;


namespace Shopping.Data.Builders
{
    public class ColorBuilder
    {
        public ColorBuilder(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Value).IsRequired().HasMaxLength(200);
           
            builder.HasQueryFilter(b => !b.IsDeleted);
        }

    }
}

