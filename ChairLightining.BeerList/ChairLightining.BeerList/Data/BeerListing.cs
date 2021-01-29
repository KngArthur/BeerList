using System;
using System.Collections.Generic;

#nullable disable

namespace ChairLightining.BeerList.Data
{
    public partial class BeerListing
    {
        public int BeerListingId { get; set; }
        public string BeerName { get; set; }
        public string Description { get; set; }
        public int Brewery { get; set; }
        public int BeerStyle { get; set; }
        public double Abv { get; set; }
        public double? Ibu { get; set; }
        public int PackageType { get; set; }

        public virtual BeerStyle BeerStyleNavigation { get; set; }
        public virtual Brewery BreweryNavigation { get; set; }
        public virtual PackageType PackageTypeNavigation { get; set; }
    }
}
