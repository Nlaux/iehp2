using iehp.MrLinks.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class MrLinksController : SitecoreController
    {
        public ActionResult MrLinksCtrl()
        {
            //read in config file & get parentGuid value
            var Guid1val = Sitecore.Configuration.Settings.GetSetting("mrLinksCol1Guid");
            var Guid2val = Sitecore.Configuration.Settings.GetSetting("mrLinksCol2Guid");
            var Guid3val = Sitecore.Configuration.Settings.GetSetting("mrLinksCol3Guid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new NavigationViewModel();
            model.Item = database.GetItem(Guid1val);
            model.Item2 = database.GetItem(Guid2val);
            model.Item3 = database.GetItem(Guid3val);

            model.Guid1List = model.Item.Children.ToList();
            model.Guid2List = model.Item2.Children.ToList();
            model.Guid3List = model.Item3.Children.ToList();

            return View("/Views/Components/_MrLinksCtrl.cshtml", model);
        }
    }
}