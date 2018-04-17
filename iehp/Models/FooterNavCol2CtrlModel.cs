using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.FooterNavCol2.Models
{
    public class NavigationViewModel
    {
        public Item Item { get; set; }

        public List<Item> Children { get; set; }
    }
}