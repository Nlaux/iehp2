using iehp.TopNav.Models;
using Sitecore;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace iehp.Controllers
{
    public class TopNavController : SitecoreController
    {
        public ActionResult TopNavCtrl()
        {
            
            //init Sitecore db 
            Database database = Context.Database;

            //read config file & get folder guids
            var model = new NavigationViewModel();
            model.Item = database.GetItem(Sitecore.Configuration.Settings.GetSetting("subNavMenuFolderGuid"));                  //subNav Folder
            model.Item2 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("mainNavMenuFolderGuid"));                //mainNav Folder
            model.Item3 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("mainNavDropdownMenuFolderGuid"));        //mainNavDropdown Folder

            model.Item4 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fadMegaNavCol1FolderGuid"));             //fadMegaNav Col1 Folder
            model.Item5 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fadMegaNavCol2FolderGuid"));             //fadMegaNav Col2 Folder
            model.Item6 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fadMegaNavCol3FolderGuid"));             //fadMegaNav Col3 Folder

            model.Item7 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fmMegaNavCol1FolderGuid"));              //fmMegaNav Col1 Folder
            model.Item8 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fmMegaNavCol2FolderGuid"));              //fmMegaNav Col2 Folder
            model.Item9 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fmMegaNavCol3FolderGuid"));              //fmMegaNav Col3 Folder

            model.Item10 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fpMegaNavCol1FolderGuid"));         //fpMegaNav Col1 Folder
            model.Item11 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fpMegaNavCol2FolderGuid"));         //fpMegaNav Col2 Folder
            model.Item12 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fpMegaNavCol3FolderGuid"));         //fpMegaNav Col3 Folder

            model.Item13 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fcMegaNavCol1FolderGuid"));         //fcMegaNav Col1 Folder
            model.Item14 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fcMegaNavCol2FolderGuid"));         //fcMegaNav Col2 Folder
            model.Item15 = database.GetItem(Sitecore.Configuration.Settings.GetSetting("fcMegaNavCol3FolderGuid"));         //fcMegaNav Col3 Folder


            //create lists from guids
            model.Guid1List = model.Item.Children.ToList();     //subNav
            model.Guid2List = model.Item2.Children.ToList();    //mainNav
            model.Guid3List = model.Item3.Children.ToList();    //mainNavDropdown

            model.Guid4List = model.Item4.Children.ToList();    //fadMegaNavCol1
            model.Guid5List = model.Item5.Children.ToList();    //fadmegaNavCol2
            model.Guid6List = model.Item6.Children.ToList();    //fadmegaNavCol3

            model.Guid7List = model.Item7.Children.ToList();    //fmMegaNavCol1
            model.Guid8List = model.Item8.Children.ToList();    //fmMegaNavCol2
            model.Guid9List = model.Item9.Children.ToList();    //fmMegaNavCol3

            model.Guid10List = model.Item10.Children.ToList();    //fpMegaNavCol1
            model.Guid11List = model.Item11.Children.ToList();    //fpMegaNavCol2
            model.Guid12List = model.Item12.Children.ToList();    //fpMegaNavCol3

            model.Guid13List = model.Item13.Children.ToList();    //fcMegaNavCol1
            model.Guid14List = model.Item14.Children.ToList();    //fcMegaNavCol2
            model.Guid15List = model.Item15.Children.ToList();    //fcMegaNavCol3

            return View("/Views/Shared/TopNavCtrl.cshtml", model);
        }
    }
}