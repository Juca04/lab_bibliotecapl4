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
            // Adicionar l�gica de autentica��o
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
            // Adicionar l�gica de autentica��o
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
            // Adicionar l�gica de autentica��o
            return RedirectToAction("Index", "Home");
        }
       // using Microsoft.AspNetCore.Mvc;

        [HttpPost]
        public IActionResult RegisterLeitor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterLeitor(string nome, string username, string password, string morada, string contactos)
        {
            if (ModelState.IsValid)
            {
                var leitor = new Leitor
                {
                    UserName = username,
                    Email = username,
                    Nome = nome,
                    Morada = morada,
                    Contactos = contactos
                };

                var result = await _userManager.CreateAsync(leitor, password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult RegisterAdministrador()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdministrador(string nome, string username, string password, string morada, string contactos)
        {
            if (ModelState.IsValid)
            {
                var admin = new Administrador
                {
                    UserName = username,
                    Email = username,
                    Nome = nome,
                    Morada = morada,
                    Contactos = contactos
                };

                var result = await _userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }


        [HttpPost]
        public IActionResult RegisterBibliotecario(string nome, string username, string password, string morada, string contactos)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterBibliotecario(string nome, string username, string password, string morada, string contactos)
        {
            if (ModelState.IsValid)
            {
                var bibliotecario = new Bibliotecario
                {
                    UserName = username,
                    Email = username, // Pode ser ajustado dependendo do login desejado
                    Nome = nome,
                    Morada = morada,
                    Contactos = contactos
                };

                var result = await _userManager.CreateAsync(bibliotecario, password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }

    }
}
