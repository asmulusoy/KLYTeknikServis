using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entities;

namespace TeknikServis.Entity.ViewsModel.AdminViewModels
{
    public class AnketViewModel
    {
        public string anketadi { get; set; }
        public List<Soru> sorulistesi { get; set; }
    }
}
