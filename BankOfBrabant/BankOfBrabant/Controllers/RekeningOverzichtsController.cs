using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankOfBrabant.Models;

namespace BankOfBrabant.Controllers
{
    public class RekeningOverzichtsController : Controller
    {
        private readonly BankOfBrabantContext _context;

        public RekeningOverzichtsController(BankOfBrabantContext context)
        {
            _context = context;
        }

        // GET: RekeningOverzichts
        public async Task<IActionResult> Index()
        {
            return View(await _context.RekeningOverzicht.ToListAsync());
        }

        // GET: RekeningOverzichts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rekeningOverzicht = await _context.RekeningOverzicht
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rekeningOverzicht == null)
            {
                return NotFound();
            }

            return View(rekeningOverzicht);
        }

        // GET: RekeningOverzichts/Create
        public IActionResult Create()
        {
           return View();
        }

        // POST: RekeningOverzichts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rekeningnummer,Naam,Rentepercentage,Saldo,TypeRekening,ID")] RekeningOverzicht rekeningOverzicht)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rekeningOverzicht);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rekeningOverzicht);
        }

        // GET: RekeningOverzichts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rekeningOverzicht = await _context.RekeningOverzicht.FindAsync(id);
            if (rekeningOverzicht == null)
            {
                return NotFound();
            }
            return View(rekeningOverzicht);
        }

        // POST: RekeningOverzichts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rekeningnummer,Naam,Rentepercentage,Saldo,TypeRekening,ID")] RekeningOverzicht rekeningOverzicht)
        {
            if (id != rekeningOverzicht.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rekeningOverzicht);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RekeningOverzichtExists(rekeningOverzicht.ID))
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
            return View(rekeningOverzicht);
        }

        // GET: RekeningOverzichts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rekeningOverzicht = await _context.RekeningOverzicht
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rekeningOverzicht == null)
            {
                return NotFound();
            }

            return View(rekeningOverzicht);
        }

        // POST: RekeningOverzichts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rekeningOverzicht = await _context.RekeningOverzicht.FindAsync(id);
            _context.RekeningOverzicht.Remove(rekeningOverzicht);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RekeningOverzichtExists(int id)
        {
            return _context.RekeningOverzicht.Any(e => e.ID == id);
        }
    }
}
