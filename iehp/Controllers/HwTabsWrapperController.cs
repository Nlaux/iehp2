using iehp.HwTabsWrapper.Models;
using iehp.HwTabsWrapperCtrl;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class HwTabsWrapperController : SitecoreController
    {
        public ActionResult HwTabsWrapperCtrl(HwTabsWrapperCtrlRequest myRequest)
        {
            //grab Tab Guid ID's from Config
            var Guid1val = Sitecore.Configuration.Settings.GetSetting("hwTab1Guid");
            var Guid2val = Sitecore.Configuration.Settings.GetSetting("hwTab2Guid");
            var Guid3val = Sitecore.Configuration.Settings.GetSetting("hwTab3Guid");
            var Guid4val = Sitecore.Configuration.Settings.GetSetting("hwTab4Guid");
            var Guid5val = Sitecore.Configuration.Settings.GetSetting("hwTab5Guid");
            var Guid6val = Sitecore.Configuration.Settings.GetSetting("hwTab6Guid");

            //init Sitecore db 
            Database database = Context.Database;

            //init Model & create lists from querystring
            var model = new EventViewModel();

            //Tab specific Info, compare incoming Guid to config Guid and process
            if (myRequest.Tab == "HwTab1") 
            {
                model.Item = database.GetItem(Guid1val); //hw Tab 1
                model.Guid1 = model.Item.Children.ToList();
            }

            if (myRequest.Tab == "HwTab2")
            {
                model.Item = database.GetItem(Guid2val); //hw Tab 2
                model.Guid1 = model.Item.Children.ToList();
            }

            if (myRequest.Tab == "HwTab3")
            {
                model.Item = database.GetItem(Guid3val); //hw Tab 3
                model.Guid1 = model.Item.Children.ToList();
            }

            if (myRequest.Tab == "HwTab4")
            {
                model.Item = database.GetItem(Guid4val); //hw Tab 4
                model.Guid1 = model.Item.Children.ToList();
            }

            if (myRequest.Tab == "HwTab5")
            {
                model.Item = database.GetItem(Guid5val); //hw Tab 5
                model.Guid1 = model.Item.Children.ToList();
            }

            if (myRequest.Tab == "HwTab6")
            {
                model.Item = database.GetItem(Guid6val); //hw Tab 6
                model.Guid1 = model.Item.Children.ToList();
            }

            return PartialView(myRequest.Pv, model);
        }
    }
}