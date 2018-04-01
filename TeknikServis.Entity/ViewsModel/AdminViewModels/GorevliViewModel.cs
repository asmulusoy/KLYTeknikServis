using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Enums;

namespace TeknikServis.Entity.ViewsModel.AdminViewModels
{
    public class GorevliViewModel
    {
        public string ID { get; set; }
        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name="Firma Adı")]
        public string FirmaAdi { get; set; }
        [Required(ErrorMessage ="Kullanıcı rolünün belirlenmesi zorunludur!")]
        [Display(Name="Kullanıcı Rolü")]
        public string RoleID { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name="Telefon")]
        public string Telefon { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z]\w{4,14}$", ErrorMessage = @"	
The password's first character must be a letter, it must contain at least 5 characters and no more than 15 characters and no characters other than letters, numbers and the underscore may be used")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
