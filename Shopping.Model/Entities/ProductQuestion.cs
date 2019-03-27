using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class ProductQuestion : BaseEntity
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string QuestionCategoryId { get; set; }
        public QuestionCategory QuestionCategory { get; set; }
        public string StoreId { get; set; }
        public Store Store { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ShareDate { get; set; }
        public bool IsPublic { get; set; }
    }
}
