using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TeknikServis.BLL.Account;
using TeknikServis.BLL.Repository;
using TeknikServis.BLL.Settings;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.Enums;
using TeknikServis.Entity.ViewsModel;
using TeknikServis.Entity.ViewsModel.AdminViewModels;

namespace TeknikServis.WebMVC.UI.Areas.Yonetim.Controllers
{
    public class ServisTalepController : BaseController
    {
        // GET: Yonetim/ServisTalep
        [Authorize(Roles = "Admin,Operator,Teknisyen")]
        public ActionResult Index()
        {
            var model = new ArizaRepo().GetAll().OrderByDescending(x => x.CreateDate).Take(100);
            return View(model);
        }

        [Authorize(Roles = "Admin,Operator")]
        [HttpGet]
        public ActionResult AktifServisTalepleri()
        {
            var model = new ArizaRepo().AktifServisTalebiListele();
            return View(model);
        }

        [Authorize(Roles = "Admin,Operator,Teknisyen")]
        [HttpGet]
        public ActionResult TeknisyeneGoreAktifServisTalepleri(string teknisyenId)
        {
            var model = new ArizaRepo().TeknisyeneGoreAktifServisTalebiListele(teknisyenId);
            return View(model);
        }

        [Authorize(Roles = "Admin,Operator,Teknisyen")]
        [HttpGet]
        public ActionResult TeknisyeneGoreTamamlanmisServisTalepleri(string teknisyenId)
        {
            var model=new ArizaRepo().TeknisyeneGoreTamamlanmisServisTalebiListele(teknisyenId);
            return View(model);
        }

        [Authorize(Roles = "Admin,Operator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GorevliAta(string teknisyenId, int arizaId)
        {
            var seciliAriza = new ArizaRepo().GetById(arizaId);
            seciliAriza.TeknisyenID = teknisyenId;
            seciliAriza.OperatorID = User.Identity.GetUserId();
            var userManager = MembershipTools.NewUserManager();
            var operatoradsoy = userManager.Users.FirstOrDefault(x => x.Id == seciliAriza.OperatorID).Name + " " + userManager.Users.FirstOrDefault(x => x.Id == seciliAriza.OperatorID).SurName;
            var teknisyenadsoy = userManager.Users.FirstOrDefault(x => x.Id == seciliAriza.TeknisyenID).Name + " " + userManager.Users.FirstOrDefault(x => x.Id == seciliAriza.TeknisyenID).SurName;
            new ArizaDurumRepo().Insert(new ArizaDurum()
            {
                ArizaID = arizaId,
                Durum = Entity.Enums.ArizaDurumlari.ServiseYonlendirildi,
                Aciklama = $"Arıza için {operatoradsoy}(Operatör) tarafından {teknisyenadsoy}(Teknisyen) görevlendirilmiştir."
            });
            new ArizaRepo().Update();
            return RedirectToAction("Index", "ServisTalep");
        }
        [Authorize(Roles = "Admin,Operator")]
        [HttpGet]
        public ActionResult Detay(int id)
        {
            var kullaniciId = new ArizaRepo().GetById(id).UserID;
            var teknisyenler = TeknisyenSelectList();
            ViewBag.Teknisyenler = teknisyenler;
            var model = new ArizaDetayViewModel
            {
                Ariza = new ArizaRepo().GetById((int)id),
                DurumListesi = new ArizaDurumRepo().GetAll().Where(x => x.ArizaID == id).ToList(),
                User = MembershipTools.NewUserManager().Users.FirstOrDefault(x => x.Id == kullaniciId)
            };

            return View(model);
        }
        [Authorize(Roles = "Admin,Operator,Teknisyen")]

        [HttpGet]
        public ActionResult ArizaDetay(int id)
        {
            var arizaRepo = new ArizaRepo();
            var userManager = MembershipTools.NewUserManager();
            string userId = arizaRepo.GetById(id).UserID;
            string operatorId = arizaRepo.GetById(id).OperatorID;
            string teknisyenId = arizaRepo.GetById(id).TeknisyenID;


            var model = new ArizaDetayViewModel
            {
                FotografList = new FotografRepo().GetAll().Where(x => x.ArızaID == id).ToList(),
                Ariza = new ArizaRepo().GetById(id),
                DurumListesi = new ArizaDurumRepo().GetAll().Where(x => x.ArizaID == id).ToList(),
                Operator = userManager.Users.FirstOrDefault(x => x.Id == operatorId),
                Teknisyen = userManager.Users.FirstOrDefault(x => x.Id == teknisyenId),
                User = userManager.Users.FirstOrDefault(x => x.Id == userId)
            };
            return View(model);
        }
        [Authorize(Roles = "Admin,Operator,Teknisyen")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DurumEkle(string durumId, string durumIcerik, int? Ariza_ID, string user_ID, string teknisyen_ID)
        {

            // var user = MembershipTools.NewUserManager().Users.Where(x => x.Id == user_ID).FirstOrDefault();
            var user = MembershipTools.NewUserManager().Users.FirstOrDefault(x => x.Id == user_ID);
            var teknisyen = MembershipTools.NewUserManager().Users.FirstOrDefault(x => x.Id == teknisyen_ID);
            var durumID = Convert.ToInt32(durumId);
            var arizaRepo = new ArizaRepo();
            arizaRepo.GetById(Ariza_ID.Value).Durumlar.Add(new ArizaDurum()
            {
                ArizaID = Ariza_ID.Value,
                Durum = (ArizaDurumlari)durumID,
                Aciklama = durumIcerik
            });
            arizaRepo.Update();
            var siteUrl = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host +
                                 (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
            var anketurl = $"{siteUrl}/Home/Anket?id=5&userId={user.Id}";
            var devamMesaj = $"Merhaba {user.Name} {user.SurName}, <br/> Arıza talebinizin durumu Teknisyen {teknisyen.Name} {teknisyen.SurName} tarafından <b>{(ArizaDurumlari)durumID}</b> olarak güncellenmiştir.<br/> <b>Güncellemeye dair mesaj :</b>.{durumIcerik}";
            var anketliMesaj = $"Merhaba {user.Name} {user.SurName}, <br/> Arıza talebinizin durumu Teknisyen {teknisyen.Name} {teknisyen.SurName} tarafından <b>{(ArizaDurumlari)durumID}</b> olarak güncellenmiştir.<br/> <b>Güncellemeye dair mesaj :</b>.{durumIcerik} <br/> <b>Siz değerli müşterilerimize daha iyi hizmet verebilmek için anket formunu doldurmanızı rica ederiz. </b></br><b>Vereceğiniz tüm bilgiler siz değerli müşterilerimize daha iyi hizmet verebilmek için bizlere önemli bir kaynaktır. </b></br><b>Anketi doldurmak için <a href=" + anketurl + ">tıklayınız</a></b> ";
            if (((ArizaDurumlari)durumID).ToString() == "ArizaGiderildi" || ((ArizaDurumlari)durumID).ToString() == "Iptal")
            {
                arizaRepo.GetById(Ariza_ID.Value).sonuclandiMi = true;
                arizaRepo.Update();
                await SiteSettings.SendMail(new MailModel()
                {
                    To = user.Email,
                    Subject = $"KLY Teknik Servis - {(ArizaDurumlari)durumID}",
                    Message = anketliMesaj
                });
            }
            else
            {
                await SiteSettings.SendMail(new MailModel()
                {
                    To = user.Email,
                    Subject = $"KLY Teknik Servis - {(ArizaDurumlari)durumID}",
                    Message = devamMesaj
                });
            }
            return RedirectToAction("ArizaDetay", "ServisTalep", new { id = Ariza_ID });
        }

    }
}