using FastReport.Data;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;

namespace SampleEF.Controllers
{
    public class MyReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public MyReportController(IWebHostEnvironment webHostEnvironement,
            IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironement;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetReportSamurai()
        {
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\SamuraiReport.frx";
            web.Report.Load(path);

            var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = _configuration.GetConnectionString("SamuraiConnection");
            var conn = mssqlDataConnection.ConnectionString;
            web.Report.SetParameterValue("CONN", conn);

            return View(web);
        }
    }
}
