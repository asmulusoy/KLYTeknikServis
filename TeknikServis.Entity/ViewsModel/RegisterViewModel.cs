using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Enums;

namespace TeknikServis.Entity.ViewsModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        public IdentityRoles Role { get; set; } = IdentityRoles.Passive;
        [Required]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Display(Name="Firma Adı")]
        [StringLength(50)]
        public string FirmaAdi { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name="Telefon")]
        [Phone]
        public string Telefon { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z]\w{4,14}$", ErrorMessage = @"	
Şifrenin ilk karakteri bir harf olmalı, en az 5 en fazla 15 karakter içermeli ve harfler, sayılar ve alt çizgi dışındaki karakterler olmamalı.")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
