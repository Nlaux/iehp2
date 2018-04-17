using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.MediCalPlan.Models
{
    public class EventViewModel
    {
        public Item Item { get; set; }

        public List<Item> MediCalPlan { get; set; }
    }
}