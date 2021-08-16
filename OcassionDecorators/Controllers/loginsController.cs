using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OcassionDecorators.Data;
using OcassionDecorators.Models;

namespace OcassionDecorators.Controllers
{
    public class loginsController : Controller
    {
        private readonly OcassionDecoratorsContext _context;

        public loginsController(OcassionDecoratorsContext context)
        {
            _context = context;
        }

        // GET: logins
        public async Task<IActionResult> Index()
        {
            return View(await _context.login.ToListAsync());
        }

        // GET: logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.login
                .FirstOrDefaultAsync(m => m.id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: logins/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult InCorrect()
        {
            return View();

        }

        public IActionResult Correct()
        {
            return View();
        }


        // POST: logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Email,Password")] login login)
        {
            if (login.Email.Equals("Ocassion@gmail.com") && login.Password.Equals("12345"))
            {
                return RedirectToAction(nameof(Correct));

            }
            else {
                return RedirectToAction(nameof(InCorrect));
            }

        }

        // GET: logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Email,Password")] login login)
        {
            if (id != login.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!loginExists(login.id))
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
            return View(login);
        }

        // GET: logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.login
                .FirstOrDefaultAsync(m => m.id == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var login = await _context.login.FindAsync(id);
            _context.login.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool loginExists(int id)
        {
            return _context.login.Any(e => e.id == id);
        }
    }
}
