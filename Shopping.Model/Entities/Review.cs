using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Review:BaseEntity
    {
        public Review()
        {
            IsApproved = false;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}

