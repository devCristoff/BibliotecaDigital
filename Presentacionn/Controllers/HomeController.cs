using BibliotecaDigital.Core.Domain.Entities;
using BibliotecaDigital.Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentacionn.Models;
using System.Diagnostics;

namespace Presentacionn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }
        [HttpGet]
        // Acción para mostrar el formulario de agregar libro
        public IActionResult Create()
        {
            return View();
        }

        // Acción para manejar el envío del formulario de agregar libro
        // Acción para manejar el envío del formulario de agregar libro
        // Acción para manejar el envío del formulario de agregar libro
        // Acción para manejar el envío del formulario de agregar libro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Verificar si Autor y Gender están inicializados
                    if (book.Autor == null)
                    {
                        // Puedes buscar el Autor por Id o manejarlo de alguna manera
                        book.Autor = await _context.Autors.FindAsync(book.AutorId);
                    }
                    if (book.Gender == null)
                    {
                        // Puedes buscar el Gender por Id o manejarlo de alguna manera
                        book.Gender = await _context.Genders.FindAsync(book.GenderId);
                    }

                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocurrió un error al agregar el libro: " + ex.Message);
                }
            }
            return View(book);
        }



        // Acción para mostrar el formulario de eliminar libro
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["Authors"] = _context.Autors.ToList();
            ViewData["Genders"] = _context.Genders.ToList();
            return View(book);
        }

        // Acción para manejar el envío del formulario de eliminar libro
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }



    }
}
