using iehp.TabWrapper.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class TabWrapperController : SitecoreController
    {
        [HttpGet]
        public ActionResult TabWrapperCtrl(string guidValue1, string guidValue2, string guidValue3, int guidQty1, int guidQty2, int guidQty3, string pv)
        {
            //init Sitecore db 
            Database database = Context.Database;

            //Tab specific Info
            if (guidValue1 == "CDF3A3AC-7F8A-4742-8CBB-AA8839DDE0B6") //Doctor Tab
            {
                if (Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Find a Doctor CTA"] != null)
                {
                    ViewBag.CTA = Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Find a Doctor CTA"];
                }

                ViewBag.ecTitle = "<h4>Upcoming Events - Find a Doctor Tab</h4>";
                ViewBag.ecLink1 = "<a class='eventLink1 nav-link active' href='#' data-toggle='tab'>Community</a>";
                ViewBag.ecLink2 = "<a class='eventLink2 nav-link' href='#' data-toggle='tab'>Health</a>";
            }
            else if (guidValue1 == "068BD40E-ECA6-4F46-9EED-351A0AB2B991") //Urgent Care Tab
            {
                if (Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Urgent Care CTA"] != null)
                {
                    ViewBag.CTA = Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Urgent Care CTA"];
                }

                ViewBag.ecTitle = "<h4>Upcoming Events - Urgent Care Tab</h4>";
                ViewBag.ecLink1 = "<a class='eventLink1 nav-link active' href='#' data-toggle='tab'>Doctors</a>";
                ViewBag.ecLink2 = "<a class='eventLink2 nav-link' href='#' data-toggle='tab'>Hospitals</a>";
            }
            else if (guidValue1 == "FB878BA8-7D65-4DF4-BE8E-42A3D0D05AA1") //Pharmacy Tab
            {
                if (Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Pharmacy CTA"] != null)
                {
                    ViewBag.CTA = Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Pharmacy CTA"];
                }

                ViewBag.ecTitle = "<h4>Upcoming Events - Pharmacy Tab</h4>";
                ViewBag.ecLink1 = "<a class='eventLink1 nav-link active' href='#' data-toggle='tab'>Drugs</a>";
                ViewBag.ecLink2 = "<a class='eventLink2 nav-link' href='#' data-toggle='tab'>Cartels</a>";
            }
            

            //init Model & create lists from querystring
            var model = new EventViewModel();
            model.Item = database.GetItem(guidValue1);
            model.Guid1 = model.Item.Children.ToList();

            model.Item2 = database.GetItem(guidValue2);
            model.Guid2 = model.Item2.Children.ToList();

            model.Item3 = database.GetItem(guidValue3);
            model.Guid3 = model.Item3.Children.ToList();

            //trunicate list to resultsQty from querystring
            ViewBag.guidList1 = model.Guid1.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(guidQty1);
            ViewBag.guidList2 = model.Guid2.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(guidQty2);
            ViewBag.guidList3 = model.Guid3.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(guidQty3);

            return PartialView(pv, model);
        }
    }
}