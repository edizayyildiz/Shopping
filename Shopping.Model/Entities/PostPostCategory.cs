using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class PostPostCategory:BaseEntity
    {
        public string PostId { get; set; }
        public Post Post { get; set; }

        public string PostCategoryId { get; set; }
        public PostCategory PostCategory { get; set; }
    }
}
