using Microsoft.AspNetCore.Mvc;

namespace lab_biblioteca.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult LoginBibliotecario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginBibliotecario(string username, string password)
        {
            // Adicionar lógica de autenticação
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LoginLeitor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginLeitor(string username, string password)
        {
            // Adicionar lógica de autenticação
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LoginAdministrador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAdministrador(string username, string password)
        {
            // Adicionar lógica de autenticação
            return RedirectToAction("Index", "Home");
        }
    }
}
