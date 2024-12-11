using aula02.Controllers;

namespace aula02.Data
{

    public class DbInitializer
    {
        private aula02Context _context;
        public DbInitializer(aula02Context context)
        {
            _context = context;
        }
        public void Run()
        {
            _context.Database.EnsureCreated();
            if (_context.Category.Any()) {
                return;
            }
            var categorias = new Category[]
            {
                new Category{Name="Programming", Description="Algorithms and programming area courses"}
                new Category { Name="Administration", Description="Public administration and business management courses"},
                new Category{ Name="Communication", Description="Business and institutional communication courses"}
};

            _context.Category.AddRange(categorias);
            //foreach(var c in categorias)
            //{
            //    _context.Category.Add(c);
            //    //_context.Add(c); // has the same result
            //}

            _context.SaveChanges();
        }
    }
}
