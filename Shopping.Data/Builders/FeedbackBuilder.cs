using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data.Builders
{
   public class FeedbackBuilder
    {
        public FeedbackBuilder(EntityTypeBuilder<Feedback> entity) {

            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Subject).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Message).IsRequired();
        }
    }
}
