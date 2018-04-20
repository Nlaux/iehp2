using Sitecore.Mvc.Controllers;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class FadCalendarController : SitecoreController
    {
        [HttpGet]
        public JsonResult FadCalendarCtrl()
        {
            string data = "";

            if (Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Find a Doctor CTA"] != null)
            {
                data = Sitecore.Context.Database.GetItem("110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9").Fields["Find a Doctor CTA"].ToString();
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]

        public ActionResult FadFormView()
        {

            return PartialView("/Views/Components/fadForm.cshtml");
        }
    }
}