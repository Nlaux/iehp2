using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.TopNav.Models
{

    public class NavigationViewModel
    {
        public Item Item { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }
        public List<Item> Guid1List { get; set; }
        public List<Item> Guid2List { get; set; }
        public List<Item> Guid3List { get; set; }
    }
}