using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("Sorular")]
    public class Soru:BaseEntity<int>
    {
        [Required]
        public string SoruMetni { get; set; }
        public int AnketID { get; set; }

        public List<Cevap> Cevaplar { get; set; } = new List<Cevap>();
        [ForeignKey("AnketID")]
        public Anket Anket { get; set; }
    }
}
