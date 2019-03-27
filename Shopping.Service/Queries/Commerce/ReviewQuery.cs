using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class ReviewQuery
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
