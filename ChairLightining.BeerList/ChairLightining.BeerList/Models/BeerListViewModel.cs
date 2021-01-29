using ChairLightining.BeerList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChairLightining.BeerList.Models
{
    public class BeerListViewModel
    {
        public int BeerListingId { get; set; }
        [Display(Name = "Beer Name")]
        public string BeerName { get; set; }
        public string Description { get; set; }
        public int Brewery { get; set; }
        [Display(Name = "Style")]
        public int BeerStyle { get; set; }
        [Display(Name = "ABV")]
        public double Abv { get; set; }
        [Display(Name = "IBU")]
        public double? Ibu { get; set; }
        public int PackageType { get; set; }

        public ICollection<BeerStyle> BeerStyles { get; set; }
        public ICollection<Brewery> Breweries { get; set; }
        public ICollection<PackageType> PackageTypes { get; set; }
    }
}
