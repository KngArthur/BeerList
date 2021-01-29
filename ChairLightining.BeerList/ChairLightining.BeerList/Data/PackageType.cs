using System;
using System.Collections.Generic;

#nullable disable

namespace ChairLightining.BeerList.Data
{
    public partial class PackageType
    {
        public PackageType()
        {
            BeerListings = new HashSet<BeerListing>();
        }

        public int PackagingId { get; set; }
        public string Packaging { get; set; }

        public virtual ICollection<BeerListing> BeerListings { get; set; }
    }
}
