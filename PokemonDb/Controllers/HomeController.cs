using Microsoft.AspNetCore.Mvc;
using PokemonDb.Models;
using System.Collections.Generic;

namespace PokemonDb.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}