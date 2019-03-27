using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
   public class PostPostCategoryBuilder
    {
        public PostPostCategoryBuilder(EntityTypeBuilder<PostPostCategory> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasOne(b => b.Post).WithMany(p => p.PostPostCategories).HasForeignKey(c => c.PostId);
            builder.HasOne(b => b.PostCategory).WithMany(p => p.PostPostCategories).HasForeignKey(c => c.PostCategoryId);
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
