using iehp.MemberHero.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class MemberHeroController : SitecoreController
    {
        // GET: MemberHero
        public ViewResult MemberHeroCtrl()
        {
            //read in config file & get parentGuid value
            var memberGuid = Sitecore.Configuration.Settings.GetSetting("memberHeroImageGuid");

            //init Sitecore db 
            Database database = Context.Database;

            var model = new MemberHeroCtrlModel();
            return View("/Views/Components/MemberHeroCtrl.cshtml", model);
        }
    }
}