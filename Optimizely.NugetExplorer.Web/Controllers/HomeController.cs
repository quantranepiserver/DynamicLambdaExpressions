using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Optimizely.NugetExplorer.Domain;
using Optimizely.NugetExplorer.Repository;
using Optimizely.NugetExplorer.Web.Models;

namespace Optimizely.NugetExplorer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(
            string name,
            string version,
            bool? internalOnly,
            DotnetFlavor? dotnetFlavor,
            int? totalDownload,
            string tag)
        {
            var repository = new DefaultNugetPackageRepository();
            var searchQuery = new NugetPackageQuery
            {
                Name = name,
                Version = version,
                InternalOnly = internalOnly,
                NetFlavor = dotnetFlavor,
                TotalDownload = totalDownload,
                Tag = tag
            };

            var nugets = repository.Search(searchQuery);
            ViewBag.SearchQuery = searchQuery;

            return View(nugets);
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
    }
}
