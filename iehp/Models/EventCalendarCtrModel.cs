using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.EventCalendar.Models
{
    public class EventViewModel
    {
        public Item Item { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }
        public Item Item4 { get; set; }
        public Item Item5 { get; set; }
        public Item Item6 { get; set; }

        public List<Item> Community { get; set; }
        public List<Item> Health { get; set; }
        public List<Item> UrgentTab1 { get; set; }
        public List<Item> UrgentTab2 { get; set; }
        public List<Item> PharmacyTab1 { get; set; }
        public List<Item> PharmacyTab2 { get; set; }
    }
}