using System;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace MusicLibrary.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreRepository genreRepository;

        public GenresController(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        // GET: Genres
        public ActionResult Index()
        {
            return View();
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
            Genre genre = genreRepository.GetEntity(id);
            if (genre != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            Genre genre = genreRepository.GetEntity(id);
            if (genre != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
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
                    throw new InvalidOperationException("Error during genre creation");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            Genre genre = genreRepository.GetEntity(id);
            if (genre != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Genres/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
