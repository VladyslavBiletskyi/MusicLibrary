using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace MusicLibrary.Controllers
{
    public class GenresController : BaseCrudController
    {
        private readonly IGenreRepository genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public override ActionResult SearchByStartPart(string searchPart)
        {
            var instances = genreRepository.GetAll().Where(genre => genre.Name.StartsWith(searchPart));
            return View("SearchResults", instances);
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
            Genre genre = genreRepository.GetEntity(id);
            if (genre != null)
            {
                return View(genre);
            }
            return RedirectToAction("Search", "Genres");
        }

        // POST: Genres/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var genre = new Genre
                {
                    Description = collection.GetValue("description").AttemptedValue,
                    Name = collection.GetValue("name").AttemptedValue
                };

                if (!genreRepository.AddEntity(genre))
                {
                    throw new InvalidOperationException("Error during genre creation");
                }

                return RedirectToAction("Search", "Genres");
            }
            catch
            {
                ViewBag.Error = "Error during genre creation";
                return RedirectToAction("Search", "Genres");
            }
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            Genre genre = genreRepository.GetEntity(id);
            if (genre != null)
            {
                return View(genre);
            }
            return RedirectToAction("Search", "Genres");
        }

        // POST: Genres/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var genre = new Genre
                {
                    Description = collection.GetValue("description").AttemptedValue,
                    Name = collection.GetValue("name").AttemptedValue
                };

                if (!genreRepository.UpdateEntity(id, genre))
                {
                    throw new InvalidOperationException("Error during genre editing");
                }

                return RedirectToAction("Search", "Genres");
            }
            catch
            {
                ViewBag.Error = "Error during genre editing";
                return RedirectToAction("Search", "Genres");
            }
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            Genre genre = genreRepository.GetEntity(id);
            if (genre != null)
            {
                return View(genre);
            }
            return RedirectToAction("Search", "Genres");
        }

        // POST: Genres/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Genre genre = genreRepository.GetEntity(id);
                if (genre != null)
                {
                    if (!genreRepository.RemoveEntity(genre.Id))
                    {
                        throw new InvalidOperationException("Error during genre deletion");
                    }
                }
                return RedirectToAction("Search", "Genres");
            }
            catch
            {
                ViewBag.Error = "Error during genre creation";
                return RedirectToAction("Search", "Genres");
            }
        }
    }
}
