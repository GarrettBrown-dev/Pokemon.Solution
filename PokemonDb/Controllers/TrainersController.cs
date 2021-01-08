using Microsoft.AspNetCore.Mvc;
using PokemonDb.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PokemonDb.Controllers
{
    public class TrainersController : Controller
    {
        private readonly PokemonDbContext _db;

        public TrainersController(PokemonDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Trainer> model = _db.Trainers.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trainer trainer)
        {
            _db.Trainers.Add(trainer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Trainer thisTrainer = _db.Trainers.FirstOrDefault(trainer => trainer.TrainerId == id);
            return View(thisTrainer);
        }

        public ActionResult Edit(int id)
        {
            var thisTrainer = _db.Trainers.FirstOrDefault(trainer => trainer.TrainerId == id);
            return View(thisTrainer);
        }

        [HttpPost]
        public ActionResult Edit(Trainer trainer)
        {
            _db.Entry(trainer).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisTrainer = _db.Trainers.FirstOrDefault(trainer => trainer.TrainerId == id);
            return View(thisTrainer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisTrainer = _db.Trainers.FirstOrDefault(trainer => trainer.TrainerId == id);
            _db.Trainers.Remove(thisTrainer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}