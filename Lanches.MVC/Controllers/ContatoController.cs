using Microsoft.AspNetCore.Mvc;

namespace Lanches.MVC.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
