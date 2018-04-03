using System;
using System.Collections.Generic;
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
                return View("Details", performer);
            }
            return RedirectToAction("Search", "Performers");
        }

        [HttpPost]
        public ActionResult GetAllPerformersOption()
        {
            return PartialView("AllPerformersList", performerRepository.GetAll().ToList());
        }

        // POST: Performer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var image = Request.Files["image"];
            byte[] imageData = null;
            if (image != null)
            {
                using (System.IO.BinaryReader br = new System.IO.BinaryReader(image.InputStream))
                {
                    imageData = br.ReadBytes(image.ContentLength);
                }
            }
            try
            {
                var performer = new Performer
                {
                    Name = collection.GetValue("name").AttemptedValue,
                    DateOfBirth = DateTime.Parse(collection.GetValue("dateOfBirth").AttemptedValue),
                    Image = imageData
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
                return View("Edit", performer);
            }
            return RedirectToAction("Search", "Performers");
        }

        // POST: Performer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var image = Request.Files["image"];
            byte[] imageData = null;
            if (image != null)
            {
                using (System.IO.BinaryReader br = new System.IO.BinaryReader(image.InputStream))
                {
                    imageData = br.ReadBytes(image.ContentLength);
                }
            }
            try
            {
                var performer = new Performer
                {
                    Name = collection.GetValue("name").AttemptedValue,
                    DateOfBirth = DateTime.Parse(collection.GetValue("dateOfBirth").AttemptedValue),
                    Albums = new List<Album>(),
                    Image = imageData
                };

                if (!performerRepository.UpdateEntity(id, performer))
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
                return View("Delete", performer);
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
