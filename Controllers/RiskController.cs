using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Risk.Models;

namespace Risk4.Controllers
{
    public class RiskController : Controller
    {
        private readonly RiskContext _context;

        public RiskController(RiskContext context)
        {
            _context = context;
        }

        // GET: Risk
        public async Task<IActionResult> Index()
        {
            return View(await _context.RiskAssessments.ToListAsync());
        }

        // GET: Risk/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riskAssessment = await _context.RiskAssessments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (riskAssessment == null)
            {
                return NotFound();
            }

            return View(riskAssessment);
        }

        // GET: Risk/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Risk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Latitude,Longitude")] RiskAssessment riskAssessment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(riskAssessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(riskAssessment);
        }

        // GET: Risk/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riskAssessment = await _context.RiskAssessments.FindAsync(id);
            if (riskAssessment == null)
            {
                return NotFound();
            }
            return View(riskAssessment);
        }

        // POST: Risk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Latitude,Longitude")] RiskAssessment riskAssessment)
        {
            if (id != riskAssessment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(riskAssessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiskAssessmentExists(riskAssessment.Id))
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
            return View(riskAssessment);
        }

        // GET: Risk/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riskAssessment = await _context.RiskAssessments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (riskAssessment == null)
            {
                return NotFound();
            }

            return View(riskAssessment);
        }

        // POST: Risk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var riskAssessment = await _context.RiskAssessments.FindAsync(id);
            _context.RiskAssessments.Remove(riskAssessment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiskAssessmentExists(int id)
        {
            return _context.RiskAssessments.Any(e => e.Id == id);
        }
    }
}
