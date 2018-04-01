using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("Fotograflar")]
    public class Fotograf:BaseEntity<int>
    {
        [Required]
        public string URL { get; set; }
        public int ArızaID { get; set; }
        [ForeignKey("ArızaID")]
        public Ariza Ariza { get; set; }
    }
}
