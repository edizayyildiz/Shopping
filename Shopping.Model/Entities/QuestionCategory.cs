using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class QuestionCategory:BaseEntity
    {
        public QuestionCategory()
        {
            ProductQuestions = new HashSet<ProductQuestion>();
        }
        public string Name { get; set; }
        public virtual ICollection<ProductQuestion> ProductQuestions { get; set; }
    }
}
