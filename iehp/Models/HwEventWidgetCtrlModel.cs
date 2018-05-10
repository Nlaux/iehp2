using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.HwEventWidget.Models
{
    public class EventViewModel
    {
        public Item Item { get; set; }

        public List<Item> HwEventWidgetList { get; set; }
    }
}