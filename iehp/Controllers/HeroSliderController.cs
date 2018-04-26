using iehp.HeroSlider.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class HeroSliderController : SitecoreController
    {
        public ViewResult HeroSliderCtrl()
        {

            //read in config file & get parentGuid value
            var parentGuidValue = Sitecore.Configuration.Settings.GetSetting("heroSliderFolderGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new SliderViewModel();
            model.Item = database.GetItem(parentGuidValue);
            model.Children = model.Item.Children.ToList();

            return View("/Views/Components/HeroSliderCtrl.cshtml", model);
        }
    }
}