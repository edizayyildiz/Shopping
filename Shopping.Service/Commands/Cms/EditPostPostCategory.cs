using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Update, "Yazı ile yazı kategorisi arasındaki ilişki güncellendi.")]
    public class EditPostPostCategory : Command
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string PostCategoryId { get; set; }


    }
}
