using Microsoft.AspNetCore.Mvc;
using MvcApiCaller.Api;
using MvcApiCaller.Models;
using System.Diagnostics;

namespace MvcApiCaller.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Hämta någon specifik endpoint så som users, posts, carts, orders o.s.v.
        public async Task<IActionResult> Index()
        {
            ApiModel? apiModel = await new ApiCaller().MakeCall("users");

            return View(apiModel);
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