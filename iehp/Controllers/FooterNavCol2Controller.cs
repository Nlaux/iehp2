using iehp.FooterNavCol2.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class FooterNavCol2Controller : SitecoreController
    {
        public ViewResult FooterNavCol2Ctrl()
        {

            //read in config file & get parentGuid value
            var parentGuidValue = Sitecore.Configuration.Settings.GetSetting("footerNavCol2FolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new NavigationViewModel();
            model.Item = database.GetItem(parentGuidValue);
            model.Children = model.Item.Children.ToList();

            return View("/Views/Shared/FooterNavCol2Ctrl.cshtml", model);
        }
    }
}