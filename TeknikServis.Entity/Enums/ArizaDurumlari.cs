using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Enums
{
    public enum ArizaDurumlari
    {
        Olusturuldu,
        [Display(Name ="Teknik Servise Yönlendirildi")]
        ServiseYonlendirildi,
        [Display(Name = "Teknik Servis Yolda")]
        ServisYolda,
        [Display(Name = "Talep İptal Edildi")]
        Iptal,
        [Display(Name = "Arıza Giderildi")]
        ArizaGiderildi,
    }
}
