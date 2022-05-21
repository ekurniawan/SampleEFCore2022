using FastReport.Data;
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
            var samurais = await _samurai.GetAll();
            WebReport web = new WebReport();
            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\SamuraiReport.frx";
            web.Report.Load(path);
            web.Report.RegisterData(samurais, "Samurais");

            /*var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = _configuration.GetConnectionString("SamuraiConnection");
            var conn = mssqlDataConnection.ConnectionString;
            web.Report.SetParameterValue("CONN", conn);*/

            return View(web);
        }
    }
}
