using iehp.MainNav.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class MainNavController : SitecoreController
    {
        public ActionResult MainNavCtrl(string Guid1, string Guid2, string Pv)
        {

            //read in config file & get parentGuid value
            //var parentGuidValue = Sitecore.Configuration.Settings.GetSetting("mainNavMenuFolderGuid");
           // var parentGuidValue2 = Sitecore.Configuration.Settings.GetSetting("subNavDropdownMenuFolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            //init Model & create lists from querystring
            var model = new NavigationViewModel();
            model.Item = database.GetItem(Guid1);
            model.Item2 = database.GetItem(Guid2);
            model.Children = model.Item.Children.ToList();
            model.Children2 = model.Item2.Children.ToList();

            return PartialView(Pv, model);

            //var model = new NavigationViewModel();
            //model.Item = database.GetItem(parentGuidValue);
            //model.Item2 = database.GetItem(parentGuidValue2);
            //model.Children = model.Item.Children.ToList();
            //model.Children2 = model.Item2.Children.ToList();

            //return View("/Views/Shared/MainNavCtrl.cshtml", model);
        }
    }
}