using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class FadCalendarController : SitecoreController
    {
        [HttpGet]
        public JsonResult FadCalendarCtrl()
        {
            //Database database = Sitecore.Context.Database;
            //Item data = database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9");
            //var fieldValue = data.Fields["Find a Doctor CTA"];

            string data = "Hello.";

            return Json(data, JsonRequestBehavior.AllowGet);
        }      
    }
}