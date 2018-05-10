using iehp.FooterNav.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class FooterNavController : SitecoreController
    {
        public ActionResult FooterNavCtrl()
        {
            //read in config file & get parentGuid value
            var Guid1val = Sitecore.Configuration.Settings.GetSetting("footerNavCol1FolderGuid");
            var Guid2val = Sitecore.Configuration.Settings.GetSetting("footerNavCol2FolderGuid");
            var Guid3val = Sitecore.Configuration.Settings.GetSetting("footerNavCol3FolderGuid");
            var Guid4val = Sitecore.Configuration.Settings.GetSetting("footerNavCol4FolderGuid");
            var Guid5val = Sitecore.Configuration.Settings.GetSetting("footerNavCol5FolderGuid");
            var Guid6val = Sitecore.Configuration.Settings.GetSetting("extraFooterNavFolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new NavigationViewModel();
            model.Item = database.GetItem(Guid1val);
            model.Item2 = database.GetItem(Guid2val);
            model.Item3 = database.GetItem(Guid3val);
            model.Item4 = database.GetItem(Guid4val);
            model.Item5 = database.GetItem(Guid5val);
            model.Item6 = database.GetItem(Guid6val);

            model.Guid1List = model.Item.Children.ToList();
            model.Guid2List = model.Item2.Children.ToList();
            model.Guid3List = model.Item3.Children.ToList();
            model.Guid4List = model.Item4.Children.ToList();
            model.Guid5List = model.Item5.Children.ToList();
            model.Guid6List = model.Item6.Children.ToList();

            return View("/Views/Shared/_FooterNavCtrl.cshtml", model);
        }
    }
}