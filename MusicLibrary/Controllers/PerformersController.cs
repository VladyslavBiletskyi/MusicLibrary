using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace MusicLibrary.Controllers
{
    public class PerformersController : BaseCrudController
    {
        private readonly IPerformerRepository performerRepository;
        private readonly IAlbumRepository albumRepository;

        public PerformersController(IPerformerRepository performerRepository, IAlbumRepository albumRepository)
        {
            this.performerRepository = performerRepository;
            this.albumRepository = albumRepository;
        }

        // GET: Performer/Details/5
        public ActionResult Details(int id)
        {
            Performer performer = performerRepository.GetEntity(id);
            if (performer != null)
            {
                return View(performer);
            }
            return RedirectToAction("Search", "Performers");
        }

        // POST: Performer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int[] albums = (int[])collection.GetValue("albums").RawValue;
                var performer = new Performer
                {
                    Name = collection.GetValue("name").AttemptedValue,
                    DateOfBirth = DateTime.Parse(collection.GetValue("date").AttemptedValue),
                    Albums = albumRepository.GetAll().Where(composition => albums.Contains(composition.Id)).ToList()
                };

                if (!performerRepository.AddEntity(performer))
                {
                    throw new InvalidOperationException("Error during performer creation");
                }

                return RedirectToAction("Search", "Performers");
            }
            catch
            {
                ViewBag.Error = "Error during performer creation";
                return RedirectToAction("Create", "Performers");
            }
        }

        // GET: Performer/Edit/5
        public ActionResult Edit(int id)
        {
            Performer performer = performerRepository.GetEntity(id);
            if (performer != null)
            {
                return View(performer);
            }
            return RedirectToAction("Search", "Performers");
        }

        // POST: Performer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                int[] albums = (int[])collection.GetValue("albums").RawValue;
                var performer = new Performer
                {
                    Name = collection.GetValue("name").AttemptedValue,
                    DateOfBirth = DateTime.Parse(collection.GetValue("date").AttemptedValue),
                    Albums = albumRepository.GetAll().Where(composition => albums.Contains(composition.Id)).ToList()
                };

                if (!performerRepository.UpdateEntity(performer.Id, performer))
                {
                    throw new InvalidOperationException("Error during performer editing");
                }

                return RedirectToAction("Search", "Performers");
            }
            catch
            {
                ViewBag.Error = "Error during performer editing";
                return RedirectToAction("Edit", "Performers");
            }
        }

        // GET: Performer/Delete/5
        public ActionResult Delete(int id)
        {
            Performer performer = performerRepository.GetEntity(id);
            if (performer != null)
            {
                return View(performer);
            }
            return RedirectToAction("Search", "Performers");
        }

        // POST: Performer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Performer performer = performerRepository.GetEntity(id);
                if (performer != null)
                {
                    performerRepository.RemovePerformerWithChildItems(performer);
                }
                return RedirectToAction("Search", "Performers");
            }
            catch
            {
                ViewBag.Error = "Error during performer deletion";
                return RedirectToAction("Search", "Performers");
            }
        }

        public override ActionResult SearchByStartPart(string searchPart)
        {
            var instances = performerRepository.GetAll().Where(performer => performer.Name.StartsWith(searchPart));
            return View("SearchResults", instances);
        }
    }
}
