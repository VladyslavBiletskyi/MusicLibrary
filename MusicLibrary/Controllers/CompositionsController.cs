using System.Web.Mvc;
using Domain.Entities;
using Domain.Interfaces;

namespace MusicLibrary.Controllers
{
    public class CompositionsController : Controller
    {
        private readonly ICompositionRepository compositionRepository;

        public CompositionsController(ICompositionRepository compositionRepository)
        {
            this.compositionRepository = compositionRepository;
        }

        // GET: Compositions
        public ActionResult Index()
        {
            return View();
        }

        // GET: Compositions/Details/5
        public ActionResult Details(int id)
        {
            Composition composition = compositionRepository.GetEntity(id);
            if (composition != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
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
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compositions/Edit/5
        public ActionResult Edit(int id)
        {
            Composition composition = compositionRepository.GetEntity(id);
            if (composition != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Compositions/Edit/5
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

        // GET: Compositions/Delete/5
        public ActionResult Delete(int id)
        {
            Composition composition = compositionRepository.GetEntity(id);
            if (composition != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Compositions/Delete/5
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
