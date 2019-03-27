using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Store, Authorities.Create, "Yeni mağaza oluşturur.")]
    public class AddStore : Command
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Owner { get; set; }
        public string Logo { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        

    }
}
