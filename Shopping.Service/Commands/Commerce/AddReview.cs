using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Yeni görüş oluşturur.")]
    public class AddReview : Command
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public string ProductId { get; set; }


    }
}
