using System.Web.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace MusicLibrary.Controllers
{
    public class PerformersController : Controller
    {
        private readonly IPerformerRepository performerRepository;

        public PerformersController(IPerformerRepository performerRepository)
        {
            this.performerRepository = performerRepository;
        }

        // GET: Performer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Performer/Details/5
        public ActionResult Details(int id)
        {
            Performer performer = performerRepository.GetEntity(id);
            if (performer != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Performer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Performer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Performer/Edit/5
        public ActionResult Edit(int id)
        {
            Performer performer = performerRepository.GetEntity(id);
            if (performer != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Performer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Performer/Delete/5
        public ActionResult Delete(int id)
        {
            Performer performer = performerRepository.GetEntity(id);
            if (performer != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Performer/Delete/5
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
