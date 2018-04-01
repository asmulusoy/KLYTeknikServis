using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TeknikServis.BLL.Repository;
using TeknikServis.Entity.Entities;

namespace TeknikServis.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServisTalepController : ApiController
    {
        public IEnumerable<Ariza> TeknisyeneGoreServisTalepListesi(string teknisyenId)
        {
            return new ArizaRepo().TeknisyeneGoreAktifServisTalebiListele(teknisyenId);
        }
        


    }
}
