using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.TabWrapper.Models
{
    public class EventViewModel
    {
        public Item Item { get; set; }
        public Item Item2 { get; set; }
        public Item Item3 { get; set; }

        public List<Item> Guid1 { get; set; }
        public List<Item> Guid2 { get; set; }
        public List<Item> Guid3 { get; set; }
    }
}