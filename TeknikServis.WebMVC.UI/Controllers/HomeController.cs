using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TeknikServis.BLL.Repository;
using TeknikServis.BLL.Settings;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.Enums;
using TeknikServis.Entity.ViewsModel;

namespace TeknikServis.WebMVC.UI.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index() // .COMMIT
        {
            ViewBag.Title = "Anasayfa | KLY Teknik Servis";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "İletişim | KLY Teknik Servis";
            return View();
        } //Taşınacak
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactMailModel model)
        {
            await SiteSettings.SendMail(new ContactMailModel()
            {
                GonderenAd = model.GonderenAd,
                GonderenEmail = model.GonderenEmail,
                Mesaj = model.Mesaj,
                Telefon = model.Telefon
            });
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Title = "Hakkımızda | KLY Teknik Servis";
            return View();
        } //Taşınacak
        
        public ActionResult Anket(int? id,string userId)
        {
            var anket = new AnketRepo().GetById(id.Value);
            var sorular = new SoruRepo().GetAll().Where(x => x.AnketID == id.Value).ToList();


            var model = new KullaniciAnketiViewModel()
            {
                anket = anket,
                sorular = sorular,
                UserID = userId
            };
            return View(model);
        } //Taşınacak

        [HttpPost]
        public ActionResult Anket(List<AnketCevapViewModel> cevaplar)
        {
            foreach (var item in cevaplar)
            {
                new CevapRepo().Insert(new Cevap()
                {
                    UserID = item.userid,
                    SoruID = item.soruid,
                    SoruCevap = (AnketCevaplari)item.cevapid
                });
            }
            return Content("başarılı");
        } //Taşınacak
        
    }
}