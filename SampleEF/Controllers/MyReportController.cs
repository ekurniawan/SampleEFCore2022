using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using SampleEF.Data.Dal;

namespace SampleEF.Controllers
{
    public class MyReportController : Controller
    {
        private readonly ISamurai _samurai;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public MyReportController(IWebHostEnvironment webHostEnvironement,
            IConfiguration configuration,ISamurai samurai)
        {
            _samurai = samurai;
            _webHostEnvironment = webHostEnvironement;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetReportSamurai()
        {
            //var samurais = await _samurai.GetAll();
            //var results = samurais.Where(s => s.Name.Contains("Kamado")).ToList();
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\SamuraiReport.frx";
            web.Report.Load(path);

            //web.Report.RegisterData(results, "Samurais");

            /*var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = _configursation.GetConnectionString("SamuraiConnection");
            var conn = mssqlDataConnection.ConnectionString;
            web.Report.SetParameterValue("CONN", conn);*/

            web.Report.SetParameterValue("QuoteText", "deathdd");
            return View(web);
        }

        public IActionResult GetReportPdf()
        {
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\SamuraiReport.frx";
            web.Report.Load(path);

            //var samurais = await _samurai.GetAll();
            //web.Report.RegisterData(samurais, "Samurais");


            web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", "report.pdf");
        }
    }
}
