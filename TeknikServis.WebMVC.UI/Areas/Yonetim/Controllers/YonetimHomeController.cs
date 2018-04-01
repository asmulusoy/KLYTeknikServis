using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeknikServis.BLL.Account;
using TeknikServis.BLL.Repository;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.Enums;
using TeknikServis.Entity.IdentityModels;
using TeknikServis.Entity.ViewsModel;
using TeknikServis.Entity.ViewsModel.AdminViewModels;

namespace TeknikServis.WebMVC.UI.Areas.Yonetim.Controllers
{
    
    public class YonetimHomeController : BaseController
    {
        

        public ActionResult AdminIndex()
        {
            return View();
        }

        //public ActionResult KullaniciListele()
        //{
        //    var modelList = new List<GorevliListViewModel>();
        //    var userManager = MembershipTools.NewUserManager();
        //    userManager.Users.ToList()
        //        .ForEach(item => modelList.Add(new GorevliListViewModel()
        //        {
        //            Name = item.Name,
        //            Surname = item.SurName,
        //            Email = item.Email,
        //            Username = item.UserName,
        //            ID = item.Id,
        //            RoleId = item.Roles.First()?.RoleId
        //        }));
        //    var roller = MembershipTools.NewRoleManager().Roles.ToList();
        //    modelList.ForEach(x => x.Role = roller.FirstOrDefault(y => y.Id == x.RoleId)?.Name);

        //    return View(modelList);
        //}

        //public ActionResult KullaniciEkle()
        //{
        //    var roleSelectList = RoleSelectList();
        //    ViewBag.roller = roleSelectList;

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult KullaniciEkle(GorevliViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.roller = RoleSelectList();
        //        return View(model);
        //    }
        //    var userManager = MembershipTools.NewUserManager();
        //    var checkUser = userManager.FindByName(model.Username);
        //    if (checkUser != null)
        //    {
        //        ModelState.AddModelError(string.Empty, "Bu kullanıcı adı daha önceden kayıt edilmiş");
        //        ViewBag.roller = RoleSelectList();
        //        return View(model);
        //    }

        //    var activationCode = Guid.NewGuid().ToString().Replace("-", "");
        //    var user = new ApplicationUser()
        //    {
        //        FirmaAdi = model.FirmaAdi,
        //        Name = model.Name,
        //        SurName = model.Surname,
        //        Email = model.Email,
        //        PhoneNumber = model.Telefon,
        //        UserName = model.Username,
        //        ActivationCode = activationCode
        //    };
        //    var sonuc = userManager.Create(user, model.Password);
        //    if (sonuc.Succeeded)
        //    {
        //        userManager.AddToRole(user.Id, MembershipTools.NewRoleManager().FindById(model.RoleID).Name);

        //        string siteUrl = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host +
        //                         (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port); // BURASI eski adres ? 

        //        return RedirectToAction("KullaniciListele", "Admin");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Kullanıcı kayıt işleminde hata oluştu!");
        //        ViewBag.roller = RoleSelectList();
        //        return View(model);
        //    }
        //}

        //public ActionResult KullaniciDuzenle(string id)
        //{

        //    ViewBag.roller = RoleSelectList();
        //    var userManager = MembershipTools.NewUserManager();

        //    var seciliUser = userManager.Users.FirstOrDefault(x => x.Id == id);
        //    KullaniciDuzenleViewModel gorevli = new KullaniciDuzenleViewModel()
        //    {
        //        Email = seciliUser.Email,
        //        Name = seciliUser.Name,
        //        Surname = seciliUser.SurName,
        //        RoleID = seciliUser.Roles.FirstOrDefault(x => x.UserId == seciliUser.Id).RoleId,
        //        Username = seciliUser.UserName,
        //        FirmaAdi = seciliUser.FirmaAdi,
        //        Telefon = seciliUser.PhoneNumber,
        //        ID = seciliUser.Id
        //    };
        //    return View(gorevli);
        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult KullaniciDuzenle(KullaniciDuzenleViewModel model)
        //{
        //    if (!ModelState.IsValid) return RedirectToAction("Index");
        //    var userManager = MembershipTools.NewUserManager();
        //    var seciliUser = userManager.Users.Where(x => x.Id == model.ID).FirstOrDefault();
        //    // var checkUser = userManager.FindByName(model.Username);
        //    //if (checkUser!=null)
        //    //{
        //    //    ModelState.AddModelError(string.Empty, "Bu kullanıcı adı daha önceden kayıt edilmiş!");
        //    //    return RedirectToAction("KullaniciDuzenle",new { id=model.ID});
        //    //}
        //    var eskirol = MembershipTools.NewRoleManager().FindById(seciliUser.Roles.FirstOrDefault().RoleId).Name;
        //    var yenirol = MembershipTools.NewRoleManager().FindById(model.RoleID).Name;
        //    userManager.RemoveFromRole(model.ID, eskirol); //eskirol silindi
        //    userManager.AddToRole(model.ID, yenirol); // rol eklendi
        //    //if (model.Password!=null)
        //    //{
        //    //    userManager.RemovePassword(model.ID);
        //    //    userManager.AddPassword(model.ID, model.Password);
        //    //}
        //    seciliUser.Name = model.Name;
        //    seciliUser.SurName = model.Surname;
        //    seciliUser.UserName = model.Username;
        //    seciliUser.PhoneNumber = model.Telefon;
        //    seciliUser.FirmaAdi = model.FirmaAdi;
        //    seciliUser.Email = model.Email;
        //    userManager.Update(seciliUser);
        //    return RedirectToAction("KullaniciListele", "Admin");
        //}

        //public ActionResult KullaniciSil(string id)
        //{
        //    if (!ModelState.IsValid) return RedirectToAction("Index");
        //    var userManager = MembershipTools.NewUserManager();
        //    var seciliUser = userManager.Users.Where(x => x.Id == id).FirstOrDefault();

        //    return RedirectToAction("KullaniciListele", "Admin");
        //}

        
        

        //public ActionResult AnketEkle()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AnketEkle(AnketViewModel model)
        //{
        //    var anketrepo = new AnketRepo();
        //    var sorurepo = new SoruRepo();
        //    Anket yeniAnket = new Anket()
        //    {
        //        AnketIsmi = model.anketadi
        //    };
        //    anketrepo.Insert(yeniAnket);

        //    model.sorulistesi.ForEach(x =>
        //    {
        //        sorurepo.Insert(new Soru()
        //        {
        //            SoruMetni = x.SoruMetni,
        //            AnketID = yeniAnket.ID,
        //        });
        //    });

        //    return View();
        //}

        //public ActionResult AnketListesi(List<Anket> model)
        //{
        //    model = new AnketRepo().GetAll();
        //    return View(model);
        //}

        //public ActionResult AnketGoruntule(int? id)
        //{
        //    if (id == null) return RedirectToAction("Index", "Admin");

        //    var seciliAnket = new AnketRepo().GetById(id.Value);
        //    var sorular = new SoruRepo().GetAll().Where(x => x.AnketID == id.Value).ToList();

        //    var model = new KullaniciAnketiViewModel()
        //    {
        //        anket = seciliAnket,
        //        sorular = sorular
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AnketDuzenle(int soruid, int anketid, string sorumetni)
        //{
        //    try
        //    {
        //        var soruRepo = new SoruRepo();
        //        var seciliSoru = soruRepo.GetById(soruid);
        //        seciliSoru.SoruMetni = sorumetni;
        //        soruRepo.Update();
        //        return RedirectToAction("AnketGoruntule", new { id = anketid });
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("AnketListesi");
        //    }

        //}
        
    }
}