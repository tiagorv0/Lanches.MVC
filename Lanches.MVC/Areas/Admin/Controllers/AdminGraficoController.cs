using Lanches.MVC.Areas.Admin.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficosVendasServico _graficoVendas;

        public AdminGraficoController(GraficosVendasServico graficoVendas)
        {
            _graficoVendas = graficoVendas ?? throw new ArgumentNullException(nameof(graficoVendas));
        }

        public JsonResult VendasLanches(int dias)
        {
            var lanchesTotais = _graficoVendas.GetVendasLanches(dias);
            return Json(lanchesTotais);
        }

        public IActionResult VendasMensal()
        {

            return View();
        }

        public IActionResult VendasSemanal()
        {

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
