using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping.Model.Entities
{
      public class Newsletter:BaseEntity
    {
        [Display(Name = "Ad-Soyad")]
        public string FullName { get; set; }
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [Display(Name ="E-posta Onay")]
        public bool IsConfirmed { get; set; }
        [Display(Name = "Onay tarihi")]
        public DateTime ConfirmationDate { get; set; }


    }
}
