using iehp.TabWrapper.Models;
using iehp.TabWrapperCtrl;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class TabWrapperController : SitecoreController
    {
        public ActionResult TabWrapperCtrl(TabWrapperCtrlRequest myRequest) //int pageA = 0, int pageB = 0, int pageC = 0
        {
            //init Sitecore db 
            Database database = Context.Database;

            //Tab specific Info
            if (myRequest.Guid1 == "CDF3A3AC-7F8A-4742-8CBB-AA8839DDE0B6") //Doctor Tab
            {
                if (Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Find a Doctor CTA"] != null)
                {
                    ViewBag.CTA = Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Find a Doctor CTA"];
                }

                ViewBag.ecTitle = "<h4>Upcoming Events - Find a Doctor Tab</h4>";
                ViewBag.ecLink1 = "<a class='eventLink1 nav-link active' href='#' data-toggle='tab'>Community</a>";
                ViewBag.ecLink2 = "<a class='eventLink2 nav-link' href='#' data-toggle='tab'>Health</a>";

            } else if (myRequest.Guid1 == "068BD40E-ECA6-4F46-9EED-351A0AB2B991") //Urgent Care Tab
                
            {
                if (Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Urgent Care CTA"] != null)
                {
                    ViewBag.CTA = Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Urgent Care CTA"];
                }

                ViewBag.ecTitle = "<h4>Upcoming Events - Urgent Care Tab</h4>";
                ViewBag.ecLink1 = "<a class='eventLink1 nav-link active' href='#' data-toggle='tab'>Doctors</a>";
                ViewBag.ecLink2 = "<a class='eventLink2 nav-link' href='#' data-toggle='tab'>Hospitals</a>";

            } else if (myRequest.Guid1 == "FB878BA8-7D65-4DF4-BE8E-42A3D0D05AA1") //Pharmacy Tab
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
            model.Item = database.GetItem(myRequest.Guid1);
            model.Guid1 = model.Item.Children.ToList();

            model.Item2 = database.GetItem(myRequest.Guid2);
            model.Guid2 = model.Item2.Children.ToList();

            model.Item3 = database.GetItem(myRequest.Guid3);
            model.Guid3 = model.Item3.Children.ToList();

            //trunicate list to resultsQty from querystring
            ViewBag.guidList1 = model.Guid1.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.GuidQty1);
            ViewBag.guidList2 = model.Guid2.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.GuidQty2);
            ViewBag.guidList3 = model.Guid3.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.GuidQty3);

            //pagination stuff
            //const int PageSize = 3;
            //var count1 = model.Guid1.Count();
            //var count2 = model.Guid2.Count();
            //var count3 = model.Guid3.Count();

            //var data1 = this.ViewBag.GuidList1.Skip(pageA * PageSize).Take(PageSize).ToList();
            //var data2 = this.ViewBag.GuidList2.Skip(pageB * PageSize).Take(PageSize).ToList();
            //var data3 = this.ViewBag.GuidList3.Skip(pageC * PageSize).Take(PageSize).ToList();

            //ViewBag.MaxPage1 = (count1 / PageSize) - (count1 % PageSize == 0 ? 1 : 0);
            //ViewBag.MaxPage2 = (count2 / PageSize) - (count2 % PageSize == 0 ? 1 : 0);
            //ViewBag.MaxPage3 = (count3 / PageSize) - (count3 % PageSize == 0 ? 1 : 0);
            //ViewBag.PageA = pageA;
            //ViewBag.PageB = pageB;
            //ViewBag.PageC = pageC;

            return PartialView(myRequest.Pv, model);
        }
    }
}