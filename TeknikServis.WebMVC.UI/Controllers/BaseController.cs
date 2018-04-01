using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using TeknikServis.BLL.Repository;

namespace TeknikServis.WebMVC.UI.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        [NonAction]
        public void ResimBoyutlandir(int en, int boy, string yol)
        {
            WebImage img = new WebImage(yol);
            img.Resize(en, boy, false);
            img.AddTextWatermark("KLYTeknikServis",opacity:50, fontColor:"Tomato", fontSize: 18, fontFamily: "Verdana");
            img.Save(yol);
        }

        [NonAction]
        public List<SelectListItem> KategoriSelectList()
        {
            var kategoriList =  new KategoriRepo().GetAll();
            var kategoriler = new List<SelectListItem>();
            kategoriList.ForEach(x =>
            kategoriler.Add(new SelectListItem
            {//burda problem var ! 
                Text = x.KategoriAdi,
                Value = x.ID.ToString()
            }));
            return kategoriler;
        }
    }
}