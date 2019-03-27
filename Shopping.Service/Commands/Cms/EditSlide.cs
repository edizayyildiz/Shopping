using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Update, "Slayt güncellendi.")]
    public class EditSlide : Command
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public string Style { get; set; }
        public int Position { get; set; }
        public string Photo { get; set; }
        public string SliderId { get; set; }
        public bool IsActive { get; set; }
    }
}
