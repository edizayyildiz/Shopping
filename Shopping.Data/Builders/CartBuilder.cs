using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
    public class CartBuilder
    {
        public CartBuilder(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
        }
    }
}
