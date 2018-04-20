using iehp.SubNav.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class SubNavController : SitecoreController
    {
        [HttpGet]
        public ActionResult SubNavCtrl(string guidValue, string pv)
        {
            //init Sitecore db 
            Database database = Context.Database;

            //init Model & create lists from querystring
            var model = new NavigationViewModel();
            model.Item = database.GetItem(guidValue);
            model.Children = model.Item.Children.ToList();

            return PartialView(pv, model);
        }

        //public ViewResult SubNavCtrl()
        //{

        //    //read in config file & get parentGuid value
        //    var parentGuidValue = Sitecore.Configuration.Settings.GetSetting("subNavMenuFolderGuid");

        //    //init Sitecore db 
        //    Database database = Context.Database;

        //    var model = new NavigationViewModel();
        //    model.Item = database.GetItem(parentGuidValue);
        //    model.Children = model.Item.Children.ToList();

        //    return View("/Views/Shared/SubNavCtrl.cshtml", model);
        //}
    }
}