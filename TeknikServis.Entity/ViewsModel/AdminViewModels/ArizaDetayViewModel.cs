using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.Entity.ViewsModel.AdminViewModels
{
    public class ArizaDetayViewModel
    {
        public List<Fotograf> FotografList { get; set; }
        public Ariza Ariza { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationUser Teknisyen { get; set; }
        public ApplicationUser Operator { get; set; }
        public List<ArizaDurum> DurumListesi { get; set; }
    }
}
