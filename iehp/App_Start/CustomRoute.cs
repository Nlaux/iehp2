using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using Sitecore.Pipelines;

namespace iehp.App_Start
{
  public class RegisterCustomRoute
  {
    public virtual void Process(PipelineArgs args)
    {
      Register();
    }

    public static void Register()
    {
      RouteTable.Routes.MapRoute("CustomRoute", "api/UrgentTabCtrl/{controller}/{action}/{id}");
    }

  }
}