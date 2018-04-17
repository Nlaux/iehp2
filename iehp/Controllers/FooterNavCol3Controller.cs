using iehp.FooterNavCol3.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class FooterNavCol3Controller : SitecoreController
    {
        public ViewResult FooterNavCol3Ctrl()
        {

            //read in config file & get parentGuid value
            var parentGuidValue = Sitecore.Configuration.Settings.GetSetting("footerNavCol3FolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new NavigationViewModel();
            model.Item = database.GetItem(parentGuidValue);
            model.Children = model.Item.Children.ToList();

            return View("/Views/Shared/FooterNavCol3Ctrl.cshtml", model);
        }
    }
}