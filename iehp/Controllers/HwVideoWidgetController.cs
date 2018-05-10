using iehp.HwVideoWidget.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class HwVideoWidgetController : SitecoreController
    {
        public ViewResult HwVideoWidgetCtrl()
        {

            //read in config file & get parentGuid value
            var HwVideoWidgetGuid = Sitecore.Configuration.Settings.GetSetting("hwVideoGuid");

            //init Sitecore db 
            Database database = Context.Database;

            //setup model & grab database ID
            var model = new EventViewModel();
            model.Item = database.GetItem(HwVideoWidgetGuid);
            model.HwVideoWidgetList = model.Item.Children.ToList();

            //determine the first active video to play
            ViewBag.activeVideoList = model.HwVideoWidgetList.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(1);
            //model.JavascriptToRun = "createVideoPlaylist()";

            return View("/Views/Components/_HwVideoWidgetCtrl.cshtml", model);
        }
    }
}