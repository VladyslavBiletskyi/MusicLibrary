using System.Web.Mvc;

namespace MusicLibrary.Controllers
{
    public abstract class BaseCrudController : Controller
    {
        [Route("")]
        public virtual ActionResult Search()
        {
            return View();
        }

        public abstract ActionResult SearchByStartPart(string searchPart);

        public virtual ActionResult Create()
        {
            return View();
        }
    }
}