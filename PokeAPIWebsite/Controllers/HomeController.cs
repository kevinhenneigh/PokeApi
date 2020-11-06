using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeApiCore;
using PokeAPIWebsite.Models;

namespace PokeAPIWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            int desiredId = 1;

            Pokemon result = await PokeAPIHelper.GetById(desiredId);
            PokedexEntryViewModel entry = PokeAPIHelper.GetPokedexEntryFromPokemon(result);

            return View(entry);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
