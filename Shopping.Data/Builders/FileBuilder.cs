using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shopping.Data.Builders
{
    public class FileBuilder

    {
        public FileBuilder(EntityTypeBuilder<Shopping.Model.Entities.File> builder) {

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(200);
            builder.Property(b => b.OriginalName).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Alt).IsRequired().HasMaxLength(4000);
            builder.Property(b => b.Category).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Type).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Extension).IsRequired().HasMaxLength(200);

            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
