using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entities;

namespace TeknikServis.Entity.ViewsModel
{
    public class KullaniciAnketiViewModel
    {
        public Anket anket { get; set; }
        public List<Soru> sorular { get; set; }
        public string UserID { get; set; }

    }
}
