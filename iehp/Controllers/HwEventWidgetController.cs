using iehp.HwEventWidget.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class HwEventWidgetController : SitecoreController
    {
        public ViewResult HwEventWidgetCtrl()
        {

            //read in config file & get parentGuid value
            var HwEventWidgetGuid = Sitecore.Configuration.Settings.GetSetting("hwEventGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new EventViewModel();
            model.Item = database.GetItem(HwEventWidgetGuid);
            model.HwEventWidgetList = model.Item.Children.ToList();
            ViewBag.eventList1 = model.HwEventWidgetList.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(1);

            return View("/Views/Components/_HwEventWidgetCtrl.cshtml", model);
        }
    }
}