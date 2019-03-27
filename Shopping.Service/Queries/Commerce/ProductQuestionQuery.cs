using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class ProductQuestionQuery : Query
    {
       
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string QuestionCategoryId { get; set; }
        public QuestionCategory QuestionCategory { get; set; }
        public string StoreId { get; set; }
        public Shopping.Model.Entities.Store Store { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string ShareDate { get; set; }
        public string IsPublic { get; set; }




    }

}
