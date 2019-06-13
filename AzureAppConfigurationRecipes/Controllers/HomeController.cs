using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using AzureAppConfigurationRecipes.Models;

using Microsoft.FeatureManagement;

namespace AzureAppConfigurationRecipes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Feature(Features.Beta)]
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
