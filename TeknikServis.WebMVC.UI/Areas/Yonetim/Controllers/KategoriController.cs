using System;
using System.Linq;
using System.Web.Mvc;
using TeknikServis.BLL.Repository;
using TeknikServis.Entity.Entities;

namespace TeknikServis.WebMVC.UI.Areas.Yonetim.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Yonetim/Kategori
        public ActionResult Index()
        {
            var kategoriler = new KategoriRepo().GetAll().OrderByDescending(x=>x.CreateDate).ToList();
            return View(kategoriler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategoriDuzenle(int duzkatid, string kategoriAdi)
        {
            try
            {
                var secili = new KategoriRepo().GetById(duzkatid);
                secili.KategoriAdi = kategoriAdi;
                new KategoriRepo().Update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index", "Kategori");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategoriEkle(string kategoriAdi)
        {
                new KategoriRepo().Insert(new Kategori()
                {
                    KategoriAdi = kategoriAdi
                });
            return RedirectToAction("Index", "Kategori");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategoriSil(int katId)
        {
            try
            {
                var secili = new KategoriRepo().GetById(katId);
                new KategoriRepo().Delete(secili);
                return RedirectToAction("KategoriIslemleri", "Admin");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    }
