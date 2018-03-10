using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace MusicLibrary.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumRepository albumRepository;
        private readonly ICompositionRepository compositionRepository;
        private readonly IPerformerRepository performerRepository;

        public AlbumsController(IAlbumRepository albumRepository, ICompositionRepository compositionRepository, IPerformerRepository performerRepository)
        {
            this.albumRepository = albumRepository;
            this.compositionRepository = compositionRepository;
            this.performerRepository = performerRepository;
        }

        // GET: Album
        public ActionResult Search()
        {
            return View();
        }

        // GET: Album/Details/5
        public ActionResult Details(int id)
        {
            Album album = albumRepository.GetEntity(id);
            if (album != null)
            {
                return View(album);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int[] compositions = (int[]) collection.GetValue("compositions").RawValue;
                var album = new Album
                {
                    Name = collection.GetValue("name").AttemptedValue,
                    DateOfCreation = DateTime.Parse(collection.GetValue("date").AttemptedValue),
                    Compositions = compositionRepository.GetAll().Where(composition => compositions.Contains(composition.Id)).ToList(),
                    Performer = performerRepository.GetEntity(int.Parse(collection.GetValue("performer").AttemptedValue))
                };

                if (!albumRepository.AddEntity(album))
                {
                    throw new InvalidOperationException("Error during album creation");
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            Album album = albumRepository.GetEntity(id);
            if (album != null)
            {
                return View(album);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Album/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                int[] compositions = (int[])collection.GetValue("compositions").RawValue;
                var album = new Album
                {
                    Name = collection.GetValue("name").AttemptedValue,
                    DateOfCreation = DateTime.Parse(collection.GetValue("date").AttemptedValue),
                    Compositions = compositionRepository.GetAll().Where(composition => compositions.Contains(composition.Id)).ToList(),
                    Performer = performerRepository.GetEntity(int.Parse(collection.GetValue("performer").AttemptedValue))
                };

                if (!albumRepository.UpdateEntity(id, album))
                {
                    throw new InvalidOperationException("Error during album update");
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            Album album = albumRepository.GetEntity(id);
            if (album != null)
            {
                return View(album);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Album/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Album album = albumRepository.GetEntity(id);
                if (album == null)
                {
                    return View();
                }
                if (!albumRepository.RemoveEntity(album))
                {
                    throw new InvalidOperationException("Error during album deletion");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
