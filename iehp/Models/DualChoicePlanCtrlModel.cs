using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.DualChoicePlan.Models
{
    public class EventViewModel
    {
        public Item Item { get; set; }

        public List<Item> DualChoicePlan { get; set; }
    }
}