using Microsoft.AspNetCore.Mvc;

namespace Praecepta.UI.Controllers
{
    public class DocsGeneratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DocsGenerator()
        {
            return View();
        }
        public IActionResult DocsHistorial()
        {
            return View();
        }
    }
}
