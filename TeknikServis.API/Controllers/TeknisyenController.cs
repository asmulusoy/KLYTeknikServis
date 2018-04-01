using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using TeknikServis.BLL.Repository;
using TeknikServis.Entity.Entities;

namespace TeknikServis.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TeknisyenController : ApiController
    {
        public IEnumerable<Ariza> Get()
        {
            return new ArizaRepo().GetAll();

        }

    }
}
