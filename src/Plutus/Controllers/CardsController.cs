using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plutus.Data;
using Plutus.Models;

namespace Plutus.Controllers
{
    public class CardsController : Controller
    {
        private readonly PlutusContext _context;

        public CardsController(PlutusContext context)
        {
            _context = context;    
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var card = await _context.Cards
                .Include(c=>c.Website)
                .Include(c=>c.UsedBy)
                .Include(c=>c.MonthlyRecords)
                    .ThenInclude(m=>m.DailyRecords).SingleOrDefaultAsync(m => m.ID == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,APR,BankName,CardName,CreditLimit,DueDay,WebsiteID")] Card card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.SingleOrDefaultAsync(m => m.ID == id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,APR,BankName,CardName,CreditLimit,DueDay,WebsiteID")] Card card)
        {
            if (id != card.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(card);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.SingleOrDefaultAsync(m => m.ID == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Cards.SingleOrDefaultAsync(m => m.ID == id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.ID == id);
        }

        public async Task<IActionResult> Dashboard(int currentMonth) {
                       
            bool isPaid = _context.MonthlyRecords.Where(m=>m.Month == currentMonth).All(m => m.IsPaid);
            var cards = _context.Cards.Include(c => c.MonthlyRecords).ThenInclude(m => m.DailyRecords);
            int cardsPaid = _context.Cards.Where(c=>c.MonthlyRecords.FirstOrDefault(m=>m.Month == currentMonth).IsPaid).Count();

            ViewBag.Month = DateTime.Now.ToString("MMMM yyyy");
            ViewBag.Clear = String.Format("Monthly Payment Status: {0}", isPaid ? "Clear (No Payments Pending)" : "Payments Pending");
            ViewBag.CardsPaid = String.Format("Cards Paid: {0}/{1}", cardsPaid, cards.Count());

            return View(await cards.ToListAsync());
        }
    }
}
