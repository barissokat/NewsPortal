using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Model
{
    [Table("User")]
    public class User
    {
        public int ID { get; set; }

        [Display(Name = "Ad:")]
        public string Name { get; set; }

        [Display(Name = "Soyad:")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Geçersiz Email Adresi")]
        public string Email { get; set; }

        [Display(Name = "Şifre:")]
        [DataType(DataType.Password)]
        [Required]
        [MinLength(6, ErrorMessage = "Şifre 6 karakterden az olamaz")]
        [MaxLength(8, ErrorMessage = "Şifre 8 karakterden fazla olamaz")]
        public string Password { get; set; }

        [Display(Name = "Kayıt Tarihi:")]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Aktiflik:")]
        public bool Active { get; set; }

        public virtual Role Role { get; set; }
    }
}
