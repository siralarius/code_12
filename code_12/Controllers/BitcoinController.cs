using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using code_12.Models;

namespace code_12.Controllers
{
    public class BitcoinController : Controller
    {
        private readonly SymbolContext _context;

        public BitcoinController(SymbolContext context)
        {
            _context = context;
        }

        // GET: Bitcoin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bitcoin.ToListAsync());
        }

        // GET: Bitcoin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitcoin = await _context.Bitcoin
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bitcoin == null)
            {
                return NotFound();
            }

            return View(bitcoin);
        }

        // GET: Bitcoin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bitcoin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,highest,lowest,high,low,reading")] Bitcoin bitcoin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bitcoin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bitcoin);
        }

        public void Create2(float ihighest, float ilowest, float ihigh, float ilow, DateTime ireading){
            Bitcoin a = new Bitcoin(ihighest, ilowest, ihigh, ilow, ireading);
            _context.Add(a);
            _context.SaveChangesAsync();
        }

        // GET: Bitcoin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitcoin = await _context.Bitcoin.SingleOrDefaultAsync(m => m.ID == id);
            if (bitcoin == null)
            {
                return NotFound();
            }
            return View(bitcoin);
        }

        // POST: Bitcoin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,highest,lowest,high,low,reading")] Bitcoin bitcoin)
        {
            if (id != bitcoin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bitcoin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BitcoinExists(bitcoin.ID))
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
            return View(bitcoin);
        }

        // GET: Bitcoin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bitcoin = await _context.Bitcoin
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bitcoin == null)
            {
                return NotFound();
            }

            return View(bitcoin);
        }

        // POST: Bitcoin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bitcoin = await _context.Bitcoin.SingleOrDefaultAsync(m => m.ID == id);
            _context.Bitcoin.Remove(bitcoin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BitcoinExists(int id)
        {
            return _context.Bitcoin.Any(e => e.ID == id);
        }
    }
}
