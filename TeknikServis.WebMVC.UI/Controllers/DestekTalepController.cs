using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using TeknikServis.BLL.Repository;
using TeknikServis.BLL.Settings;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.Enums;
using TeknikServis.Entity.ViewsModel;

namespace TeknikServis.WebMVC.UI.Controllers
{
    [Authorize]
    public class DestekTalepController : BaseController
    {
        // GET: DestekTalep
        
        public ActionResult DestekTalebiOlustur()
        {
            ViewBag.Title = "Destek Talep Formu | KLY Teknik Servis";
            var kategoriler = KategoriSelectList();
            ViewBag.kategoriler = kategoriler;
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DestekTalebiOlustur(ArizaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Title = "Destek Talep Formu | KLY Teknik Servis";
                var kategoriler = KategoriSelectList();
                ViewBag.kategoriler = kategoriler;
                return View(model);
            }
            if (model == null)
                return RedirectToAction("DestekTalebiOlustur");
            var yeniAriza = new Ariza()
            {
                UserID = User.Identity.GetUserId(),
                Aciklama = model.Aciklama,
                KategoriID = model.KategoriID,
                AdresAciklamasi = model.AdresAciklamasi,
                Baslik = model.Baslik,
                lat = model.lat,
                lng = model.lng
            };
            try
            {
                new ArizaRepo().Insert(yeniAriza);
                if (model.Fotograflar.Any())
                {
                    foreach (var dosya in model.Fotograflar)
                    {
                        if (dosya != null && dosya.ContentType.Contains("image") && dosya.ContentLength > 0)
                        {
                            var fileName = Path.GetFileNameWithoutExtension(dosya.FileName);
                            var extName = Path.GetExtension(dosya.FileName);
                            fileName = SiteSettings.UrlFormatConverter(fileName);
                            fileName += Guid.NewGuid().ToString().Replace("-", "");
                            var directoryPath = Server.MapPath("~/Uploads/ArizaImage");
                            var filePath = Server.MapPath("~/Uploads/ArizaImage/") + fileName + extName;
                            if (!Directory.Exists(directoryPath))
                                Directory.CreateDirectory(directoryPath);
                            dosya.SaveAs(filePath);
                            ResimBoyutlandir(400, 400, filePath);
                            new FotografRepo().Insert(new Fotograf()
                            {
                                ArızaID = yeniAriza.ID,
                                URL = @"/Uploads/ArizaImage/" + fileName + extName
                            });
                        }
                    }
                }
                var yeniArizaDurum = new ArizaDurum() //Ariza durumunu oluşturuldu olarak ekle
                {
                    Durum = ArizaDurumlari.Olusturuldu,
                    Aciklama = "Arıza kullanıcı tarafından oluşturuldu.",
                    ArizaID = yeniAriza.ID
                };
                yeniAriza.Durumlar.Add(yeniArizaDurum);
                new ArizaRepo().Update();
                RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                ViewBag.sonuc = "Arıza kaydedilirken beklenmeyen bir hata oluştu. > " + ex.Message;
                return RedirectToAction("DestekTalepListesi");
            }
            ViewBag.Title = "Destek Talep Formu | KLY Teknik Servis";
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult DestekTalepListesi()
        {
            var model = new ArizaRepo().GetAll().OrderByDescending(x => x.CreateDate).Where(x => x.UserID == User.Identity.GetUserId()).ToList();
            return View(model);
        } 
        [HttpGet]
        public ActionResult DestekTalepDetay(int id)
        {
            ViewBag.kategoriler = KategoriSelectList();
            var ariza = new ArizaRepo().GetById(id);
            var fotograflar = new FotografRepo().WithByFaultId(id);
            var model = new KullaniciArizaDetayViewModel()
            {
                Ariza = ariza,
                FotografList = fotograflar
            };
            return View(model);
        }
    }
}