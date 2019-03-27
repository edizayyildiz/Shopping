using Shopping.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
     public class ProductQuestionBuilder
    {
        public ProductQuestionBuilder(EntityTypeBuilder<ProductQuestion> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
            builder.Property(b => b.Description).IsRequired().HasMaxLength(4000);
            builder.Property(b => b.ShareDate).IsRequired();
            builder.HasOne(b => b.Product).WithMany(c => c.ProductQuestions).HasForeignKey(p => p.ProductId);
            builder.HasOne(b => b.QuestionCategory).WithMany(c => c.ProductQuestions).HasForeignKey(p => p.QuestionCategoryId);
            builder.HasOne(b => b.Store).WithMany(c => c.ProductQuestions).HasForeignKey(p => p.StoreId);
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
