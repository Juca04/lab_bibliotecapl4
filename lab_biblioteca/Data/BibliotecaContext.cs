using lab_biblioteca.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab_biblioteca.Data
{
    public class BibliotecaContext : IdentityDbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }
        public DbSet<lab_biblioteca.Models.Emprestimo> Emprestimo { get; set; } = default!;
    }
}
