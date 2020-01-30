using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaBox_Data.Entities;

namespace PizzaBox_Web.Controllers
{
    public class OurPizzasController : Controller
    {
        private readonly PizzaDbContext _context;

        //private readonly IOurPizzaRepository<PizzaBox_Lib.Models.OurPizzas> _repository;

        public OurPizzasController(PizzaDbContext context)
        {
            _context = context;
        }

        // GET: OurPizzas
        public async Task<IActionResult> Index()
        {
            return View(await _context.OurPizzas.ToListAsync());
        }

        // GET: OurPizzas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourPizzas = await _context.OurPizzas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourPizzas == null)
            {
                return NotFound();
            }

            return View(ourPizzas);
        }

        // GET: OurPizzas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OurPizzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PizzaName,Price")] OurPizzas ourPizzas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ourPizzas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourPizzas);
        }

        // GET: OurPizzas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourPizzas = await _context.OurPizzas.FindAsync(id);
            if (ourPizzas == null)
            {
                return NotFound();
            }
            return View(ourPizzas);
        }

        // POST: OurPizzas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PizzaName,Price")] OurPizzas ourPizzas)
        {
            if (id != ourPizzas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ourPizzas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurPizzasExists(ourPizzas.Id))
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
            return View(ourPizzas);
        }

        // GET: OurPizzas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourPizzas = await _context.OurPizzas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourPizzas == null)
            {
                return NotFound();
            }

            return View(ourPizzas);
        }

        // POST: OurPizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ourPizzas = await _context.OurPizzas.FindAsync(id);
            _context.OurPizzas.Remove(ourPizzas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurPizzasExists(int id)
        {
            return _context.OurPizzas.Any(e => e.Id == id);
        }
    }
}
