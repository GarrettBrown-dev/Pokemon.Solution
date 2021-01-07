using Microsoft.AspNetCore.Mvc;
using PokemonDb.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PokemonDb.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly PokemonDbContext _db;
        public PokemonsController(PokemonDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View(_db.Pokemons.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.PokeTypeId = new SelectList(_db.PokeTypes, "PokeTypeId", "PokeTypeName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pokemon pokemon, int PokeTypeId)
        {
            _db.Pokemons.Add(pokemon);
            if (PokeTypeId != 0)
            {
                _db.Pokedex.Add(new Pokedex() { PokeTypeId = PokeTypeId, PokemonId = pokemon.PokemonId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var thisPokemon = _db.Pokemons
            .Include(pokemon => pokemon.PokeTypes)
            .ThenInclude(join => join.PokeType)
            .FirstOrDefault(pokemon => pokemon.PokemonId == id);
            return View(thisPokemon);
        }

        public ActionResult Edit(int id)
        {
            var thisPokemon = _db.Pokemons
            .Include(pokemon => pokemon.PokeTypes)
            .ThenInclude(join => join.PokeType)
            .FirstOrDefault(pokemon => pokemon.PokemonId == id);
            ViewBag.PokeTypeId = new SelectList(_db.PokeTypes, "PokeTypeId", "PokeTypeName");
            return View(thisPokemon);
        }
        [HttpPost]
        public ActionResult Edit(Pokemon pokemon, int PokeTypeId)
        {
            if (PokeTypeId != 0)
            {
                _db.Pokedex.Add(new Pokedex() { PokeTypeId = PokeTypeId, PokemonId = pokemon.PokemonId });
            }
            _db.Entry(pokemon).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisPokemon = _db.Pokemons.FirstOrDefault(pokemons => pokemons.PokemonId == id);
            return View(thisPokemon);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisPokemon = _db.Pokemons.FirstOrDefault(pokemons => pokemons.PokemonId == id);
            _db.Pokemons.Remove(thisPokemon);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeletePokeType(int joinId)
        {
            var joinEntry = _db.Pokedex.FirstOrDefault(entry => entry.PokedexId == joinId);
            _db.Pokedex.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}