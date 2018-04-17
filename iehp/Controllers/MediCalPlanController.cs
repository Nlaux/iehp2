using iehp.MediCalPlan.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class MediCalPlanController : SitecoreController
    {
        public ViewResult MediCalPlanCtrl()
        {

            //read in config file & get parentGuid value
            var mediCalPlanGuid = Sitecore.Configuration.Settings.GetSetting("mediCalFolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new EventViewModel();
            model.Item = database.GetItem(mediCalPlanGuid);
            model.MediCalPlan = model.Item.Children.ToList();

            return View("/Views/Components/MediCalPlanCtrl.cshtml", model);
        }
    }
}