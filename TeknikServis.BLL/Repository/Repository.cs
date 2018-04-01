using System.Collections.Generic;
using System.Linq;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.Enums;

namespace TeknikServis.BLL.Repository
{
    public class AnketRepo : RepositoryBase<Anket, int>{}
  public class SoruRepo : RepositoryBase<Soru, int>{}
  public class CevapRepo : RepositoryBase<Cevap, int>{}
    public class ArizaRepo : RepositoryBase<Ariza, int>
    {
        public List<Ariza> TeknisyeneGoreAktifServisTalebiListele(string teknisyenId)
        {
            var model = this.GetAll()
                .Where(x => x.TeknisyenID == teknisyenId && x.sonuclandiMi==false)
               .OrderByDescending(x => x.CreateDate)
                .ToList();
            return model;
        }

        public List<Ariza> TeknisyeneGoreTamamlanmisServisTalebiListele(string teknisyenId)
        {
            var model = new ArizaRepo().GetAll()
                .OrderByDescending(x => x.CreateDate)
                .Where(x => x.TeknisyenID == teknisyenId && x.sonuclandiMi==true)
                .ToList();
            return model;
        }

        public List<Ariza> AktifServisTalebiListele()
        {
            var model = this.GetAll().Where(x => x.sonuclandiMi == false).ToList();
            return model;
        }

        
    }
  public class ArizaDurumRepo : RepositoryBase<ArizaDurum, int>{}

    public class FotografRepo : RepositoryBase<Fotograf, int>
    {
        public List<Fotograf> WithByFaultId(int id)
        {
            return  this.GetAll()
                .Where(x => x.ArızaID == id)
                .ToList();
        }

    }
  public class KategoriRepo : RepositoryBase<Kategori, int>{}
  
}
