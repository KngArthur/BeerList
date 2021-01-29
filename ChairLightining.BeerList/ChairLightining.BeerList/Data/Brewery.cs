using System;
using System.Collections.Generic;

#nullable disable

namespace ChairLightining.BeerList.Data
{
    public partial class Brewery
    {
        public Brewery()
        {
            BeerListings = new HashSet<BeerListing>();
        }

        public int BreweryId { get; set; }
        public string BreweryName { get; set; }

        public virtual ICollection<BeerListing> BeerListings { get; set; }
    }
}
