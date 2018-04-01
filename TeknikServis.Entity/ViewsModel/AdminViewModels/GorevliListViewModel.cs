using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.ViewsModel.AdminViewModels
{
    public class GorevliListViewModel
    {
        [Display(Name = "Firma Adı")]
        public string FirmaAdi { get; set; }
        public string ID { get; set; }
        [Required]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kullanıcı rolünün belirlenmesi zorunludur!")]
        [Display(Name = "Kullanıcı Rolü")]
        public string Role { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string RoleId { get; set; }

    }
}
