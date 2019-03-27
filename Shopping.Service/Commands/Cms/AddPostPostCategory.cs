using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Create, "Yazı ile yazı kategorisi arasında yeni ilişki oluşturur.")]
    public class AddPostPostCategory : Command
    {
        public string PostId { get; set; }
        public string PostCategoryId { get; set; }
    }
}
