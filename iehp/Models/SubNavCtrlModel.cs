using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.SubNav.Models
{

    public class NavigationViewModel
    {
        public Item Item { get; set; }

        public Item Item2 { get; set; }

        public List<Item> Children { get; set; }

        public List<Item> Children2 { get; set; }
    }
}