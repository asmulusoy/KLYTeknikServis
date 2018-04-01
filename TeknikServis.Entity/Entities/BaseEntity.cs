using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    public  class BaseEntity<T> where T:struct
    {
        [Key]
        public T ID { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;


    }
}
