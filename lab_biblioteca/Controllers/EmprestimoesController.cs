using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_biblioteca.Data;
using lab_biblioteca.Models;

namespace lab_biblioteca.Controllers
{
    public class EmprestimoesController : Controller
    {
        private readonly Data.BibliotecaContext _context;

        public EmprestimoesController(Data.BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Emprestimoes
        public async Task<IActionResult> Index()
        {
            var bibliotecaContext = _context.Emprestimo.Include(e => e.IdLivroNavigation).Include(e => e.IdUsuarioNavigation);
            return View(await bibliotecaContext.ToListAsync());
        }

        // GET: Emprestimoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .Include(e => e.IdLivroNavigation)
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimoes/Create
        public IActionResult Create()
        {
            ViewData["IdLivro"] = new SelectList(_context.Set<Livro>(), "Id", "Id");
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "Id", "Id");
            return View();
        }

        // POST: Emprestimoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdLivro,DataRequisicao,DataDevolucao,DataLimite")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLivro"] = new SelectList(_context.Set<Livro>(), "Id", "Id", emprestimo.IdLivro);
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", emprestimo.IdUsuario);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["IdLivro"] = new SelectList(_context.Set<Livro>(), "Id", "Id", emprestimo.IdLivro);
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", emprestimo.IdUsuario);
            return View(emprestimo);
        }

        // POST: Emprestimoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,IdLivro,DataRequisicao,DataDevolucao,DataLimite")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLivro"] = new SelectList(_context.Set<Livro>(), "Id", "Id", emprestimo.IdLivro);
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "Id", "Id", emprestimo.IdUsuario);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .Include(e => e.IdLivroNavigation)
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo != null)
            {
                _context.Emprestimo.Remove(emprestimo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimo.Any(e => e.Id == id);
        }
    }
}
