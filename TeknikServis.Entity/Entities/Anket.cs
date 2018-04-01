using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("Anketler")]
    public class Anket: BaseEntity<int>
    {
        public string AnketIsmi { get; set; }
        public List<Soru> Sorular { get; set; } = new List<Soru>();
        public override string ToString()
        {
            return AnketIsmi;
        }
    }
}
