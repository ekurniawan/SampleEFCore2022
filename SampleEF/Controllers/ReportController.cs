using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using SampleEF.Data.Dal;

namespace SampleEF.Controllers
{
    public class ReportController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ISamurai _samurai;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportController(IWebHostEnvironment webHostEnvironment, ISamurai samurai,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _samurai = samurai;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetSamurai()
        {
            var samurais = await _samurai.GetAll();
            WebReport web = new WebReport();
            web.Mode = WebReportMode.Preview;
            //web.Toolbar.ShowPrint = false;
            //web.Toolbar.Show = false;
           
            

            //web.Report.RegisterData(samurais, "Samurais");

            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\SamuraiList.frx";
            web.Report.Load(path);

            var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = _configuration.GetConnectionString("SamuraiConnection");
            var conn = mssqlDataConnection.ConnectionString;
            web.Report.SetParameterValue("CONN", conn);

            /*web.Report.Prepare();
            Stream stream = new MemoryStream();
            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;
            
            return File(stream, "application/zip", "report.pdf");*/

           
            

            return View(web);

        }
    }
}
