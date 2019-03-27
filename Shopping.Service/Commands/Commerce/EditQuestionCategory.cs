using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Soru kategorisi günceller.")]
    public class EditQuestionCategory : Command
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
