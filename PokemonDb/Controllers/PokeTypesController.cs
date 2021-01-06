using Microsoft.AspNetCore.Mvc;
using PokemonDb.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PokemonDb.Controllers
{
    public class PokeTypesController : Controller
    {
        private readonly PokemonDbContext _db;

        public PokeTypesController(PokemonDbContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<PokeType> model = _db.PokeTypes.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PokeType pokeType)
        {
            _db.PokeTypes.Add(pokeType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisPokeType = _db.PokeTypes
                .Include(pokeType => pokeType.Pokemons)
                .ThenInclude(join => join.Pokemon)
                .FirstOrDefault(pokeType => pokeType.PokeTypeId == id);
            return View(thisPokeType);
        }

        public ActionResult Edit(int id)
        {
            var thisPokeType = _db.PokeTypes.FirstOrDefault(pokeType => pokeType.PokeTypeId == id);
            return View(thisPokeType);
        }

        [HttpPost]
        public ActionResult Edit(PokeType pokeType)
        {
            _db.Entry(pokeType).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisPokeType = _db.PokeTypes.FirstOrDefault(poketype => pokeType.PokeTypeId == id);
            return View(thisPokeType);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisPokeType = _db.PokeTypes.FirstOrDefault(poketype => poketype.PokeTypeId == id);
            _db.PokeTypes.Remove(thisPokeType);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}