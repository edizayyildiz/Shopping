using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class NewsletterQuery:Query
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime ConfirmationDate { get; set; }
    }
}
