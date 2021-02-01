using ChairLightining.BeerList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChairLightining.BeerList.Models
{
    public class PackageTypeModel
    {
        public int PackagingId { get; set; }
        public string Packaging { get; set; }

        public ICollection<BeerListing> BeerListings { get; set; }
    }
}
