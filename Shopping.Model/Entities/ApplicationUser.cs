using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Pic { get; set; }
        public string Fullname { get; set; }
    }
}
