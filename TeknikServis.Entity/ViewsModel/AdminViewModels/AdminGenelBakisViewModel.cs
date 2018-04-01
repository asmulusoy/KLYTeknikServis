using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.Entity.ViewsModel.AdminViewModels
{
    public class AdminGenelBakisViewModel
    {
        public List<ApplicationUser> Adminler { get; set; }
        public List<ApplicationUser> Operatorler { get; set; }
        public List<ApplicationUser> Teknisyenler { get; set; }
        public int giderilmisTalep { get; set; }
        public int iptalEdilmisTalep { get; set; }
        public int operatordeBekleyen { get; set; }
        public int teknisyendeBekleyen { get; set; }

    }
}
