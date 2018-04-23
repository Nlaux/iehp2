using iehp.TopNav.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class TopNavController : SitecoreController
    {
        public ActionResult TopNavCtrl()
        {
            //read in config file & get parentGuid value
            var Guid1val = Sitecore.Configuration.Settings.GetSetting("subNavMenuFolderGuid");
            var Guid2val = Sitecore.Configuration.Settings.GetSetting("mainNavMenuFolderGuid");
            var Guid3val = Sitecore.Configuration.Settings.GetSetting("mainNavDropdownMenuFolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new NavigationViewModel();
            model.Item = database.GetItem(Guid1val);
            model.Item2 = database.GetItem(Guid2val);
            model.Item3 = database.GetItem(Guid3val);
            model.Guid1List = model.Item.Children.ToList();
            model.Guid2List = model.Item2.Children.ToList();
            model.Guid3List = model.Item3.Children.ToList();

            return View("/Views/Shared/TopNavCtrl.cshtml", model);
        }
    }
}