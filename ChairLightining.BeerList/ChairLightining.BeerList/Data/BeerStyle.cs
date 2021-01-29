using System;
using System.Collections.Generic;

#nullable disable

namespace ChairLightining.BeerList.Data
{
    public partial class BeerStyle
    {
        public BeerStyle()
        {
            BeerListings = new HashSet<BeerListing>();
        }

        public int BeerStyleId { get; set; }
        public string BeerStyle1 { get; set; }
        public string BeerStyleAbriviation { get; set; }

        public virtual ICollection<BeerListing> BeerListings { get; set; }
    }
}
