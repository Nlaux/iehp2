using iehp.DualChoicePlan.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class DualChoicePlanController : SitecoreController
    {
        public ViewResult DualChoicePlanCtrl()
        {

            //read in config file & get parentGuid value
            var dualChoicePlanGuid = Sitecore.Configuration.Settings.GetSetting("dualChoiceFolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new EventViewModel();
            model.Item = database.GetItem(dualChoicePlanGuid);
            model.DualChoicePlan = model.Item.Children.ToList();

            return View("/Views/Components/DualChoicePlanCtrl.cshtml", model);
        }
    }
}