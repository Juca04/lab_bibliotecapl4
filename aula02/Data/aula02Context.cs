using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aula02.Controllers;

namespace aula02.Data
{
    public class aula02Context : DbContext
    {
        public aula02Context (DbContextOptions<aula02Context> options)
            : base(options)
        {
        }

        public DbSet<aula02.Controllers.Category> Category { get; set; } = default!;
    }
}
