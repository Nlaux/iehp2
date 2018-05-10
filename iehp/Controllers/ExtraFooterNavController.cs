using iehp.ExtraFooterNav.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class ExtraFooterNavController : SitecoreController
    {
        public ActionResult ExtraFooterNavCtrl()
        {
            //read in config file & get parentGuid value
            var Guid1val = Sitecore.Configuration.Settings.GetSetting("extraFooterNavFolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new NavigationViewModel();
            model.Item = database.GetItem(Guid1val);
            model.Guid1List = model.Item.Children.ToList();

            //get current year and pass to view
            ViewBag.currentYear = DateTime.Now.Year.ToString();

            return View("/Views/Shared/_ExtraFooterNavCtrl.cshtml", model);
        }
    }
}