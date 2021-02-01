using ChairLightining.BeerList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChairLightining.BeerList.Models
{
    public class BreweryModel
    {
        public int BreweryId { get; set; }
        public string BreweryName { get; set; }

        public ICollection<BeerListing> BeerListings { get; set; }
    }
}
