using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Web.Models
{
    public class Contacts
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olabilir.")]
        public string Name { get; set; }
       
        [Display(Name = "E-posta")]
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        [Required]
        [Phone]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Display(Name = "Yorum")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
    }
}
