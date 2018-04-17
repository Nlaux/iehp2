using iehp.NewsArticles.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class NewsArticlesController : SitecoreController
    {
        public ViewResult NewsArticlesCtrl()
        {

            //read in config file & get parentGuid value
            var newsArticleGuid = Sitecore.Configuration.Settings.GetSetting("newsArticlesFolderGuid");
            var newsArticleResultsQty = Sitecore.Configuration.Settings.GetSetting("newsArticlesResultsQty");

            int newsArticlesResultsQtyTemp = Int32.Parse(newsArticleResultsQty);

            //init Sitecore db 
            Database database = Context.Database;

            var model = new EventViewModel();
            model.Item = database.GetItem(newsArticleGuid);
            model.NewsArticles = model.Item.Children.ToList();


            //trunicate list to resultsQty from config
            ViewBag.newsList = model.NewsArticles.Take(newsArticlesResultsQtyTemp);

            return View("/Views/Components/NewsCtrl.cshtml", model);
        }
    }
}