using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.NewsArticles.Models
{
    public class EventViewModel
    {
        public Item Item { get; set; }

        public List<Item> NewsArticles { get; set; }

    }
}