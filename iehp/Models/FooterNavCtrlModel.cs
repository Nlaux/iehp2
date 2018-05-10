using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.FooterNav.Models
{

    public class NavigationViewModel
    {
        public Item Item { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }
        public Item Item4 { get; set; }
        public Item Item5 { get; set; }
        public Item Item6 { get; set; }

        public List<Item> Guid1List { get; set; }
        public List<Item> Guid2List { get; set; }
        public List<Item> Guid3List { get; set; }
        public List<Item> Guid4List { get; set; }
        public List<Item> Guid5List { get; set; }
        public List<Item> Guid6List { get; set; }
    }
}