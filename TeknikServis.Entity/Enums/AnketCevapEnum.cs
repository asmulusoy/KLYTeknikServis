using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Enums
{
    public enum AnketCevaplari
    {
        [Display(Name ="Çok Kötü")]
        CokKotu,
        [Display(Name = "Kötü")]
        Kotu,
        [Display(Name = "Orta")]
        Orta,
        [Display(Name = "İyi")]
        Iyi,
        [Display(Name = "Çok İyi")]
        CokIyi
    }
}