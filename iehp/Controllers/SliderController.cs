using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class SliderController : SitecoreController
    {
        // GET: Slider
        public ViewResult ImageSlider()
        {
            Item contentItem = null;
            var database = Context.Database;
            if (database != null)
            {
                if (!string.IsNullOrEmpty(
                    RenderingContext.Current.Rendering.DataSource))
                {
                    contentItem = database.GetItem(new Sitecore.Data.ID(
                        RenderingContext.Current.Rendering.DataSource));
                }
            }
            return View(contentItem);
        }
    }
}