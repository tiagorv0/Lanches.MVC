using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Lanches.MVC.Areas.Admin.FastReportUtils;
using Lanches.MVC.Areas.Admin.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLanchesReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly RelatorioLanchesServico _relatorioService;
        private WebReport _webReport;
        private MsSqlDataConnection _mssqlDataConnection;

        public AdminLanchesReportController(IWebHostEnvironment webHostEnv, RelatorioLanchesServico relatorioService)
        {
            _webHostEnv = webHostEnv;
            _relatorioService = relatorioService;
            _webReport = new WebReport();
            _mssqlDataConnection = new MsSqlDataConnection();
        }

        [Route("LanchesCategoriaReport")]
        public async Task<IActionResult> LanchesCategoriaReport()
        {
            await InputInformationOnPDFAsync();

            return View(_webReport);
        }

        [Route("LanchesCategoriaPDF")]
        public async Task<IActionResult> LanchesCategoriaPDF()
        {
            await InputInformationOnPDFAsync();

            _webReport.Report.Prepare();

            var stream = new MemoryStream();
            _webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return new FileStreamResult(stream, "application/pdf");
        }

        private async Task InputInformationOnPDFAsync()
        {
            _webReport.Report.Dictionary.AddChild(_mssqlDataConnection);

            _webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "LanchesCategoria.frx"));

            var lanches = HelperFastReport.GetTable(await _relatorioService.GetLanchesReport(), "LanchesReport");
            var categorias = HelperFastReport.GetTable(await _relatorioService.GetCategoriasReport(), "CategoriasReport");

            _webReport.Report.RegisterData(lanches, "LanchesReport");
            _webReport.Report.RegisterData(categorias, "CategoriasReport");
        }

    }
}
