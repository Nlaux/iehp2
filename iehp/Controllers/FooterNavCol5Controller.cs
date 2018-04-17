using iehp.FooterNavCol5.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class FooterNavCol5Controller : SitecoreController
    {
        public ViewResult FooterNavCol5Ctrl()
        {

            //read in config file & get parentGuid value
            var parentGuidValue = Sitecore.Configuration.Settings.GetSetting("footerNavCol5FolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new NavigationViewModel();
            model.Item = database.GetItem(parentGuidValue);
            model.Children = model.Item.Children.ToList();

            return View("/Views/Shared/FooterNavCol5Ctrl.cshtml", model);
        }
    }
}