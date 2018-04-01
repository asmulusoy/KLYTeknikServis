using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.ViewsModel
{
    public class ContactMailModel
    {
        [Required(ErrorMessage ="Gönderen Ad alanının girilmesi zorunludur!")]
        public string GonderenAd { get; set; }
        [Required(ErrorMessage = "E-Mail adresinin girilmesi zorunludur!")]
        [EmailAddress(ErrorMessage ="Belirtilen Mail adresi geçerli değildir!")]
        public string GonderenEmail { get; set; }
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Mesaj alanının girilmesi zorunludur!")]
        public string Mesaj { get; set; }



    }
}
