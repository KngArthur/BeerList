using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChairLightining.BeerList.Models;
using ChairLightining.BeerList.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ChairLightining.BeerList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var beers = GetAllBeers();
            var viewModels = beers.Select(b => new BeerListViewModel
            {
                BeerListingId = b.BeerListingId,
                BeerName = b.BeerName,
                Brewery = b.Brewery,
                Description = b.Description,
                Abv = b.Abv,
                Ibu = b.Ibu,
                BeerStyle = b.BeerStyle,
                PackageType = b.PackageType
            }).ToList();

            return View(viewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public static List<BeerListing> GetAllBeers()
        {
            var context = new BeerListContext();
            var beerList = context.BeerListings
                                                .OrderBy(bl => bl.BeerStyle)
                                                .ThenBy(bl => bl.Brewery)
                                                .ToList();

            return beerList;
        }

        public static List<Brewery> GetAll()
        {
            var context = new BeerListContext();
            var breweryTypes = context.Breweries.ToList();
            return breweryTypes;
        }

        public static IList GetAsKeyValuePairs()
        {
            var context = new BeerListContext();
            var breweryTypes = context.Breweries.Select(bt => new
            {
                Value = bt.BreweryId,
                Text = bt.BreweryName
            }).ToList();

            return breweryTypes;
        }

        //public static List<BeerListing> GetAllByPackageType(int PackageType)
        //{
        //    var context = new BeerListContext();
        //}
    }
}
