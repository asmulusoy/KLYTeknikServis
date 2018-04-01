using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TeknikServis.Entity.ViewsModel
{
    public class PasswordViewModel
    {
        [Required(ErrorMessage = "Şifre alanının girilmesi zorunludur.")]
        [StringLength(15,MinimumLength = 5,ErrorMessage = "Geçersiz bir şifre girdiniz.")]
        [Display(Name = "Eski Şifre")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }


        [StringLength(15)]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z]\w{4,14}$", ErrorMessage = @"	
Şifrenin ilk karakteri bir harf olmalı, en az 5 en fazla 15 karakter içermeli ve harfler, sayılar ve alt çizgi dışındaki karakterler olmamalı.")]
        public string NewPassword { get; set; }


        [StringLength(15)]
        [Display(Name = "Yeni Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmNewPassword { get; set; }
    }
}
