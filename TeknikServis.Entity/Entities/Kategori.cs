using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("Kategoriler")]
   public class Kategori:BaseEntity<int>
    {
        [Required]
        public string KategoriAdi { get; set; }
        public List<Ariza> Arizalar { get; set; } = new List<Ariza>();
    }
}
