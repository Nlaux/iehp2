using iehp.Navigation.Models;
using iehp.QueryCtrl;
using Sitecore;
using Sitecore.Data;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class NavigationController : Controller
    {
        //Navigation Menus
        public ActionResult NavigationCtrl(QueryCtrlRequest myRequest) 
        {
            //init Sitecore db 
            Database database = Context.Database;

            //init Model & create lists from querystring
            var model = new NavigationViewModel();

            model.Item1 = database.GetItem(new ID(myRequest.Guid1));
            model.Guid1List = model.Item1.Children.ToList();

            model.Item2 = database.GetItem(new ID(myRequest.Guid2));
            model.Guid2List = model.Item2.Children.ToList();

            model.Item3 = database.GetItem(new ID(myRequest.Guid3));
            model.Guid3List = model.Item3.Children.ToList();

            model.Item4 = database.GetItem(new ID(myRequest.Guid4));
            model.Guid4List = model.Item4.Children.ToList();

            model.Item5 = database.GetItem(new ID(myRequest.Guid5));
            model.Guid5List = model.Item5.Children.ToList();

            model.Item6 = database.GetItem(new ID(myRequest.Guid6));
            model.Guid6List = model.Item6.Children.ToList();

            return PartialView(myRequest.Pv, model);
        }
    }
}