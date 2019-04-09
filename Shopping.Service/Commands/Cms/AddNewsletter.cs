using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Create, "Yeni abone oluşturur.")]
    public class AddNewsletter:Command
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime ConfirmationDate { get; set; }

    }
}
