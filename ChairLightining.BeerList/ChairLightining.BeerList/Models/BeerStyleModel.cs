using ChairLightining.BeerList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChairLightining.BeerList.Models
{
    public class BeerStyleModel
    {
        public int BeerStyleId { get; set; }
        public string BeerStyleName { get; set; }
        public string BeerStyleAbriviation { get; set; }

        public ICollection<BeerListing> BeerListings { get; set; }
    }
}
