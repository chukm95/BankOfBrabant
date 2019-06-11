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
    public class AccountHoldersController : Controller
    {
        private readonly BankOfBrabantContext _context;

        public AccountHoldersController(BankOfBrabantContext context)
        {
            _context = context;
        }

        // GET: AccountHolders
        public async Task<IActionResult> Index()
        {
            var bankOfBrabantContext = _context.AccountHolder.Include(a => a.Account).Include(a => a.Client);
            return View(await bankOfBrabantContext.ToListAsync());
        }

        // GET: AccountHolders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHolder = await _context.AccountHolder
                .Include(a => a.Account)
                .Include(a => a.Client)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accountHolder == null)
            {
                return NotFound();
            }

            return View(accountHolder);
        }

        // GET: AccountHolders/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "ID", "ID");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
            return View();
        }

        // POST: AccountHolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClientID,AccountId,HolderType")] AccountHolder accountHolder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountHolder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "ID", "ID", accountHolder.AccountId);
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID", accountHolder.ClientID);
            return View(accountHolder);
        }

        // GET: AccountHolders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHolder = await _context.AccountHolder.FindAsync(id);
            if (accountHolder == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "ID", "ID", accountHolder.AccountId);
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID", accountHolder.ClientID);
            return View(accountHolder);
        }

        // POST: AccountHolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ClientID,AccountId,HolderType")] AccountHolder accountHolder)
        {
            if (id != accountHolder.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountHolder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountHolderExists(accountHolder.ID))
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
            ViewData["AccountId"] = new SelectList(_context.Account, "ID", "ID", accountHolder.AccountId);
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID", accountHolder.ClientID);
            return View(accountHolder);
        }

        // GET: AccountHolders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountHolder = await _context.AccountHolder
                .Include(a => a.Account)
                .Include(a => a.Client)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accountHolder == null)
            {
                return NotFound();
            }

            return View(accountHolder);
        }

        // POST: AccountHolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountHolder = await _context.AccountHolder.FindAsync(id);
            _context.AccountHolder.Remove(accountHolder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountHolderExists(int id)
        {
            return _context.AccountHolder.Any(e => e.ID == id);
        }
    }
}
