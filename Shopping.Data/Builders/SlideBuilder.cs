using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class SlideBuilder
    {
        public SlideBuilder(EntityTypeBuilder<Slide> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Text).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Url).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Photo).IsRequired().HasMaxLength(200);
            builder.HasOne(b => b.Slider).WithMany(c => c.Slides).HasForeignKey(p => p.SliderId);

            builder.HasQueryFilter(b => !b.IsDeleted);

        }

    }
}
