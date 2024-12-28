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

    //[Route("home")]
    //public class HomeController : Controller
    //{
    //    [HttpGet("")]
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}
