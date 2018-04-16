using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspCoreApp.Models;

namespace AspCoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            var vm = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(vm);
        }
    }
}
