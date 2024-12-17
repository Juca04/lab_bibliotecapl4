using System.Diagnostics;
using lab_biblioteca.Models;
using Microsoft.AspNetCore.Mvc;


namespace lab_biblioteca.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }
    }
}
