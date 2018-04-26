using Sitecore.Data.Items;
using System.Collections.Generic;

namespace iehp.HeroSlider.Models
{
    public class SliderViewModel
    {
        public Item Item { get; set; }
        public List<Item> Children { get; set; }
    }
}