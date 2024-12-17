using Microsoft.AspNetCore.Identity;

namespace lab_biblioteca.Models
{
    public class Administrador : IdentityUser
    {
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Contactos { get; set; }
    }
}
