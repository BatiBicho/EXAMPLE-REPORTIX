using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using TRADE24.Models;
using Reportix.Engine;
using Reportix.Engine.Data;
using Reportix.Engine.Rendering;

namespace TRADE24.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GeneralData()
        {
            ViewData["Module"] = Resources.General.GeneralDataIndex;
            ViewData["Title"] = Resources.General.GeneralDataIndex;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DownloadPdf(CancellationToken cancellationToken)
        {
            var reportPath = Path.Combine(
                _environment.ContentRootPath,
                "Reportes",
                "GeneralData",
                "GeneralDataProfile.rptx");

            var executor = new DbConnectionReportDataSourceExecutor(
                source => new SqlConnection(source.ConnectionString));
            var report = ReportixReport.Open(reportPath, dataSourceExecutor: executor);
            await report.LoadDataAsync(cancellationToken);

            using var result = await report.RenderAsync(
                RenderFormat.Pdf,
                cancellationToken);

            using var buffer = new MemoryStream();
            await result.Content.CopyToAsync(buffer, cancellationToken);

            return File(buffer.ToArray(), result.ContentType, "GeneralDataProfile.pdf");
        }
    }
}
