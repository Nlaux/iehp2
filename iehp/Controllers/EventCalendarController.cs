using iehp.EventCalendar.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class EventCalendarController : SitecoreController
    {
        [HttpGet]
        public ActionResult EventCalendarCtrl()
        {
            //read config file & get parentGuid values
            var communityGuid = Sitecore.Configuration.Settings.GetSetting("communityEventCalendarFolderGuid");
            var communityResultsQty = Sitecore.Configuration.Settings.GetSetting("communityResultsQty");

            var healthGuid = Sitecore.Configuration.Settings.GetSetting("healthEventCalendarFolderGuid");
            var healthResultsQty = Sitecore.Configuration.Settings.GetSetting("healthResultsQty");

            int communityResultsQtyTemp = Int32.Parse(communityResultsQty);
            int healthResultsQtyTemp = Int32.Parse(healthResultsQty);
          
            //init Sitecore db 
            Database database = Context.Database;

            var model = new EventViewModel();
            model.Item = database.GetItem(communityGuid);
            model.Community = model.Item.Children.ToList();

            model.Item2 = database.GetItem(healthGuid);
            model.Health = model.Item2.Children.ToList();

            //trunicate list to resultsQty from config
            ViewBag.communityList = model.Community.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(communityResultsQtyTemp);
            ViewBag.healthList = model.Health.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(healthResultsQtyTemp);

            return PartialView("/Views/Components/_FADEventCalendarCtrl.cshtml", model);
        }

        [HttpGet]
        public ActionResult UrgentTabCtrl()
        {
            //read config file & get parentGuid values
            var urgentTab1Guid = Sitecore.Configuration.Settings.GetSetting("urgentTab1EventCalendarFolderGuid");
            var urgentTab1ResultsQty = Sitecore.Configuration.Settings.GetSetting("urgentTab1ResultsQty");

            var urgentTab2Guid = Sitecore.Configuration.Settings.GetSetting("urgentTab2EventCalendarFolderGuid");
            var urgentTab2ResultsQty = Sitecore.Configuration.Settings.GetSetting("urgentTab2ResultsQty");

            int urgentTab1ResultsQtyTemp = Int32.Parse(urgentTab1ResultsQty);
            int urgentTab2ResultsQtyTemp = Int32.Parse(urgentTab2ResultsQty);

            //init Sitecore db 
            Database database = Context.Database;

            var model = new EventViewModel();
            model.Item3 = database.GetItem(urgentTab1Guid);
            model.UrgentTab1 = model.Item3.Children.ToList();

            model.Item4 = database.GetItem(urgentTab2Guid);
            model.UrgentTab2 = model.Item4.Children.ToList();

            //trunicate list to resultsQty from config

            ViewBag.urgentTab1List = model.UrgentTab1.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(urgentTab1ResultsQtyTemp);
            ViewBag.urgentTab2List = model.UrgentTab2.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(urgentTab2ResultsQtyTemp);

            return PartialView("/Views/Components/_UCEventCalendarCtrl.cshtml", model);
        }

        [HttpGet]
        public ActionResult PharmacyTabCtrl()
        {
            //read config file & get parentGuid values
            var pharmacyTab1Guid = Sitecore.Configuration.Settings.GetSetting("pharmacyTab1EventCalendarFolderGuid");
            var pharmacyTab1ResultsQty = Sitecore.Configuration.Settings.GetSetting("pharmacyTab1ResultsQty");

            var pharmacyTab2Guid = Sitecore.Configuration.Settings.GetSetting("pharmacyTab2EventCalendarFolderGuid");
            var pharmacyTab2ResultsQty = Sitecore.Configuration.Settings.GetSetting("pharmacyTab2ResultsQty");

            int pharmacyTab1ResultsQtyTemp = Int32.Parse(pharmacyTab1ResultsQty);
            int pharmacyTab2ResultsQtyTemp = Int32.Parse(pharmacyTab2ResultsQty);

            //init Sitecore db 
            Database database = Context.Database;

            var model = new EventViewModel();
            model.Item5 = database.GetItem(pharmacyTab1Guid);
            model.PharmacyTab1 = model.Item5.Children.ToList();

            model.Item6 = database.GetItem(pharmacyTab2Guid);
            model.PharmacyTab2 = model.Item6.Children.ToList();

            //trunicate list to resultsQty from config
            ViewBag.pharmacyTab1List = model.PharmacyTab1.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(pharmacyTab1ResultsQtyTemp);
            ViewBag.pharmacyTab2List = model.PharmacyTab2.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(pharmacyTab2ResultsQtyTemp);

            return PartialView("/Views/Components/_PharmEventCalendarCtrl.cshtml", model);
        }
    }
}