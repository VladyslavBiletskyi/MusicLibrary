using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace MusicLibrary.Controllers
{
    public class CompositionsController : Controller
    {
        private readonly ICompositionRepository compositionRepository;
        private readonly IAlbumRepository albumRepository;
        private readonly IGenreRepository genreRepository;

        public CompositionsController(ICompositionRepository compositionRepository, IAlbumRepository albumRepository, IGenreRepository genreRepository)
        {
            this.compositionRepository = compositionRepository;
            this.albumRepository = albumRepository;
            this.genreRepository = genreRepository;
        }

        // GET: Compositions
        [Route("")]
        public ActionResult Search()
        {
            return View();
        }

        // GET: Compositions/Details/5
        public ActionResult Details(int id)
        {
            Composition composition = compositionRepository.GetEntity(id);
            if (composition != null)
            {
                return View(composition);
            }
            return RedirectToAction("Search", "Compositions");
        }

        // GET: Compositions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compositions/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int[] albums = (int[])collection.GetValue("albums").RawValue;
                var composition = new Composition
                {
                    Name = collection.GetValue("name").AttemptedValue,
                    Albums = albumRepository.GetAll().Where(album => albums.Contains(album.Id)).ToList(),
                    Genre = genreRepository.GetEntity(int.Parse(collection.GetValue("genre").AttemptedValue)),
                    Text = collection.GetValue("text").AttemptedValue
                };
                compositionRepository.AddEntity(composition);
                return RedirectToAction("Search", "Compositions");
            }
            catch
            {
                ViewBag.Error = "Error during composition creation";
                return RedirectToAction("Search", "Compositions");
            }
        }

        // GET: Compositions/Edit/5
        public ActionResult Edit(int id)
        {
            Composition composition = compositionRepository.GetEntity(id);
            if (composition != null)
            {
                return View(composition);
            }
            return RedirectToAction("Search", "Compositions");
        }

        // POST: Compositions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Composition composition = compositionRepository.GetEntity(id);
                if (composition != null)
                {
                    int[] albums = (int[])collection.GetValue("albums").RawValue;
                    composition.Name = collection.GetValue("name").AttemptedValue;
                    composition.Albums = albumRepository.GetAll().Where(album => albums.Contains(album.Id)).ToList();
                    composition.Genre = genreRepository.GetEntity(int.Parse(collection.GetValue("genre").AttemptedValue));
                    composition.Text = collection.GetValue("text").AttemptedValue;
                }
                return RedirectToAction("Search", "Compositions");
            }
            catch
            {
                ViewBag.Error = "Error during composition editing";
                return RedirectToAction("Search", "Compositions");
            }
        }

        // GET: Compositions/Delete/5
        public ActionResult Delete(int id)
        {
            Composition composition = compositionRepository.GetEntity(id);
            if (composition != null)
            {
                return View(composition);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Compositions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Composition composition = compositionRepository.GetEntity(id);
                if (composition != null)
                {
                    if (!compositionRepository.RemoveEntity(composition.Id))
                    {
                        throw new InvalidOperationException("Error during composition deletion");
                    }
                }
                return RedirectToAction("Search", "Compositions");
            }
            catch
            {
                ViewBag.Error = "Error during composition deletion";
                return RedirectToAction("Search", "Compositions");
            }
        }
    }
}
