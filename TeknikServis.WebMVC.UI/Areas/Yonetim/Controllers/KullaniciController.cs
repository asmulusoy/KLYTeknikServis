using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TeknikServis.BLL.Account;
using TeknikServis.Entity.IdentityModels;
using TeknikServis.Entity.ViewsModel.AdminViewModels;

namespace TeknikServis.WebMVC.UI.Areas.Yonetim.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KullaniciController : BaseController
    {
        // GET: Yonetim/Kullanici
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Kullanicilar()
        {
            var modelList = new List<GorevliListViewModel>();
            var userManager = MembershipTools.NewUserManager();
            userManager.Users.ToList()
                .ForEach(item => modelList.Add(new GorevliListViewModel()
                {
                    FirmaAdi = item.FirmaAdi,
                    Name = item.Name,
                    Surname = item.SurName,
                    Email = item.Email,
                    Username = item.UserName,
                    ID = item.Id,
                    RoleId = item.Roles.First()?.RoleId
                }));
            var roller = MembershipTools.NewRoleManager().Roles.ToList();
            modelList.ForEach(x => x.Role = roller.FirstOrDefault(y => y.Id == x.RoleId)?.Name);
            return Json( new {data=modelList}, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult KullaniciEkle()
        {
            ViewBag.roller = RoleSelectList();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KullaniciEkle(GorevliViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.roller = RoleSelectList();
                return View(model);
            }
            var userManager = MembershipTools.NewUserManager();
            var checkUser = userManager.FindByName(model.Username);
            if (checkUser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu kullanıcı adı daha önceden kayıt edilmiş");
                ViewBag.roller = RoleSelectList();
                return View(model);
            }

            var activationCode = Guid.NewGuid().ToString().Replace("-", "");
            var user = new ApplicationUser()
            {
                FirmaAdi = model.FirmaAdi,
                Name = model.Name,
                SurName = model.Surname,
                Email = model.Email,
                PhoneNumber = model.Telefon,
                UserName = model.Username,
                ActivationCode = activationCode
            };
            var sonuc = userManager.Create(user, model.Password);
            if (sonuc.Succeeded)
            {
                userManager.AddToRole(user.Id, MembershipTools.NewRoleManager().FindById(model.RoleID).Name);

                var siteUrl = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host +
                                 (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port); // BURASI eski adres ? 

                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı kayıt işleminde hata oluştu!");
                ViewBag.roller = RoleSelectList();
                return View(model);
            }
        }


        public ActionResult KullaniciDuzenle(string id)
        {

            ViewBag.roller = RoleSelectList();
            var userManager = MembershipTools.NewUserManager();

            var seciliUser = userManager.Users.FirstOrDefault(x => x.Id == id);
            KullaniciDuzenleViewModel gorevli = new KullaniciDuzenleViewModel()
            {
                Email = seciliUser.Email,
                Name = seciliUser.Name,
                Surname = seciliUser.SurName,
                RoleID = seciliUser.Roles.FirstOrDefault(x => x.UserId == seciliUser.Id).RoleId,
                Username = seciliUser.UserName,
                FirmaAdi = seciliUser.FirmaAdi,
                Telefon = seciliUser.PhoneNumber,
                ID = seciliUser.Id
            };
            return View(gorevli);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KullaniciDuzenle(KullaniciDuzenleViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index");
            var userManager = MembershipTools.NewUserManager();
            var seciliUser = userManager.Users.Where(x => x.Id == model.ID).FirstOrDefault();
            // var checkUser = userManager.FindByName(model.Username);
            //if (checkUser!=null)
            //{
            //    ModelState.AddModelError(string.Empty, "Bu kullanıcı adı daha önceden kayıt edilmiş!");
            //    return RedirectToAction("KullaniciDuzenle",new { id=model.ID});
            //}
            var eskirol = MembershipTools.NewRoleManager().FindById(seciliUser.Roles.FirstOrDefault().RoleId).Name;
            var yenirol = MembershipTools.NewRoleManager().FindById(model.RoleID).Name;
            userManager.RemoveFromRole(model.ID, eskirol); //eskirol silindi
            userManager.AddToRole(model.ID, yenirol); // rol eklendi
            //if (model.Password!=null)
            //{
            //    userManager.RemovePassword(model.ID);
            //    userManager.AddPassword(model.ID, model.Password);
            //}
            seciliUser.Name = model.Name;
            seciliUser.SurName = model.Surname;
            seciliUser.UserName = model.Username;
            seciliUser.PhoneNumber = model.Telefon;
            seciliUser.FirmaAdi = model.FirmaAdi;
            seciliUser.Email = model.Email;
            userManager.Update(seciliUser);
            return RedirectToAction("KullaniciListele", "Admin");
        }


    }
}