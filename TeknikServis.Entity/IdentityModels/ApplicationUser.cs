using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entities;

namespace TeknikServis.Entity.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string SurName { get; set; }
        [StringLength(50)]
        public string FirmaAdi { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public string ActivationCode { get; set; }

        public List<Cevap> Cevaplar { get; set; } = new List<Cevap>();

        public List<Ariza> Arızalar { get; set; } = new List<Ariza>();
    }
}
