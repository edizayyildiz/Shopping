using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class FeedbackQuery:Query
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
