using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.BLL.Account;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.WebMVC.UI.Areas.Yonetim.Controllers
{
    public class BaseController : Controller
    {
        // GET: Yonetim/Base


        [NonAction]
        public List<SelectListItem> RoleSelectList()
        {
            var roleList = MembershipTools.NewRoleManager().Roles.ToList();
            var roller = new List<SelectListItem>();
            roleList.ForEach(x =>
            roller.Add(new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));
            return roller;
        }

        [NonAction]
        public List<SelectListItem> TeknisyenSelectList()
        {
            var teknisyenList = MembershipTools.NewUserManager().Users.Where(x => x.Roles.FirstOrDefault().RoleId == "2628da05-6a23-48dc-90bb-8db46f818762").ToList();
            var teknisyenler = new List<SelectListItem>();
            teknisyenList.ForEach(x =>
            teknisyenler.Add(new SelectListItem
            {//burda problem var ! 
                Text = x.Name + " " + x.SurName,
                Value = x.Id.ToString()
            }));
            return teknisyenler;
        }
    }
}