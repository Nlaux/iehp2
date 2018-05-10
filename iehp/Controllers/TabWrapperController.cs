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

            //init Model & create lists from querystring
            var model = new EventViewModel();

            //grab Tab Guid ID's from Config
            var Guid1val = Sitecore.Configuration.Settings.GetSetting("doctorTab1FolderGuid");
            var Guid2val = Sitecore.Configuration.Settings.GetSetting("doctorTab2FolderGuid");
            var Guid3val = Sitecore.Configuration.Settings.GetSetting("urgentTab1FolderGuid");
            var Guid4val = Sitecore.Configuration.Settings.GetSetting("urgentTab2FolderGuid");
            var Guid5val = Sitecore.Configuration.Settings.GetSetting("pharmacyTab1FolderGuid");
            var Guid6val = Sitecore.Configuration.Settings.GetSetting("pharmacyTab2FolderGuid");

            var Guid7val = Sitecore.Configuration.Settings.GetSetting("newsArticlesTab1FolderGuid"); //news articles for tab 1
            var Guid8val = Sitecore.Configuration.Settings.GetSetting("newsArticlesTab2FolderGuid"); //news articles for tab 2
            var Guid9val = Sitecore.Configuration.Settings.GetSetting("newsArticlesTab3FolderGuid"); //news articles for tab 3

            //Tab specific Info, compare incoming Guid to config Guid and process
            if (myRequest.Tab1 == "DoctorTab") //Doctor Tab
            {
                if (Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Find a Doctor CTA"] != null)
                {
                    ViewBag.CTA = Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Find a Doctor CTA"];
                }

                ViewBag.ecTitle = "<h4 id='ueHeader'>Upcoming Events</h4>";
                ViewBag.ecLink1 = "<a class='eventLink1 nav-link active' href='#' data-toggle='tab'>Community</a>";
                ViewBag.ecLink2 = "<a class='eventLink2 nav-link' href='#' data-toggle='tab'>Health</a>";

                model.Item = database.GetItem(Guid1val); //event tab 1
                model.Item2 = database.GetItem(Guid2val); //event tab 2
                model.Item3 = database.GetItem(Guid7val); //news articles for tab 1

                model.Guid1 = model.Item.Children.ToList();
                model.Guid2 = model.Item2.Children.ToList();
                model.Guid3 = model.Item3.Children.ToList();

                ViewBag.guidList1 = model.Guid1.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.Qty1); //tab 1
                ViewBag.guidList2 = model.Guid2.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.Qty2); //tab 2
                ViewBag.guidList3 = model.Guid3.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.Qty3); //newslist

            }

            if (myRequest.Tab1 == "UrgentTab") //Urgent Care Tab      
            {
                if (Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Urgent Care CTA"] != null)
                {
                    ViewBag.CTA = Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Urgent Care CTA"];
                }

                ViewBag.ecTitle = "<h4>Upcoming Events</h4>";
                ViewBag.ecLink1 = "<a class='eventLink1 nav-link active' href='#' data-toggle='tab'>Doctors</a>";
                ViewBag.ecLink2 = "<a class='eventLink2 nav-link' href='#' data-toggle='tab'>Hospitals</a>";

                model.Item = database.GetItem(Guid3val); //event tab 1
                model.Item2 = database.GetItem(Guid4val); //event tab 2
                model.Item3 = database.GetItem(Guid8val); //news articles for tab 2

                model.Guid1 = model.Item.Children.ToList();
                model.Guid2 = model.Item2.Children.ToList();
                model.Guid3 = model.Item3.Children.ToList();

                ViewBag.guidList1 = model.Guid1.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.Qty1); //tab 1
                ViewBag.guidList2 = model.Guid2.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.Qty2); //tab 2
                ViewBag.guidList3 = model.Guid3.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.Qty3); //newslist

            }

            if (myRequest.Tab1 == "PharmacyTab") //Pharmacy Tab
            {
                if (Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Pharmacy CTA"] != null)
                {
                    ViewBag.CTA = Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Pharmacy CTA"];
                }

                ViewBag.ecTitle = "<h4>Upcoming Events</h4>";
                ViewBag.ecLink1 = "<a class='eventLink1 nav-link active' href='#' data-toggle='tab'>Drugs</a>";
                ViewBag.ecLink2 = "<a class='eventLink2 nav-link' href='#' data-toggle='tab'>Cartels</a>";

                model.Item = database.GetItem(Guid5val); //event tab 1
                model.Item2 = database.GetItem(Guid6val); //event tab 2
                model.Item3 = database.GetItem(Guid9val); //news articles for tab 2

                model.Guid1 = model.Item.Children.ToList();
                model.Guid2 = model.Item2.Children.ToList();
                model.Guid3 = model.Item3.Children.ToList();

                ViewBag.guidList1 = model.Guid1.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.Qty1); //tab 1
                ViewBag.guidList2 = model.Guid2.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.Qty2); //tab 2
                ViewBag.guidList3 = model.Guid3.Where(x => x.Fields["Active"] != null && x.Fields["Active"].Value == "1").Take(myRequest.Qty3); //newslist
            }
            

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