using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.ViewsModel
{
    public class ProfileViewModel
    {
        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }
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
        [Phone]
        public string Telefon { get; set; }
        public string FirmaAdi { get; set; }
        
    }
}
