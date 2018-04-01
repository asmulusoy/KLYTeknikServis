using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.BLL.Repository;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.ViewsModel;
using TeknikServis.Entity.ViewsModel.AdminViewModels;

namespace TeknikServis.WebMVC.UI.Areas.Yonetim.Controllers
{
    public class AnketController : Controller
    {
        // GET: Yonetim/Anket
        public ActionResult Index()
        {
          var  model = new AnketRepo().GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AnketEkle()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnketEkle(AnketViewModel model)
        {
            var anketrepo = new AnketRepo();
            var sorurepo = new SoruRepo();
            var yeniAnket = new Anket()
            {
                AnketIsmi = model.anketadi
            };
            anketrepo.Insert(yeniAnket);

            model.sorulistesi.ForEach(x =>
            {
                sorurepo.Insert(new Soru()
                {
                    SoruMetni = x.SoruMetni,
                    AnketID = yeniAnket.ID,
                });
            });

            return View();
        }

        [HttpGet]
        public ActionResult AnketDetay(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Anket");

            var seciliAnket = new AnketRepo().GetById(id.Value);
            var sorular = new SoruRepo().GetAll().Where(x => x.AnketID == id.Value).ToList();
            var model = new KullaniciAnketiViewModel()
            {
                anket = seciliAnket,
                sorular = sorular
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnketDuzenle(int soruid, int anketid, string sorumetni)
        {
            try
            {
                var soruRepo = new SoruRepo();
                var seciliSoru = soruRepo.GetById(soruid);
                seciliSoru.SoruMetni = sorumetni;
                soruRepo.Update();
                return RedirectToAction("AnketDetay", new { id = anketid });
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

        //public ActionResult SoruSil(int id)
        //{
        //    var repo = new SoruRepo();
        //    var soru = repo.GetById(id);
        //    repo.Delete(soru);
        //    repo.Update();
        //    return Json()
        //}

        public ActionResult SoruEkle()
        {
            return Content("qwee");
        }

    }
}