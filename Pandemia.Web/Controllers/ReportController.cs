using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Pandemic.Web.Data;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Models;

namespace Pandemic.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly DataContext _context;

        public ReportController(DataContext context)
        {
            _context = context;
        }

        // GET: ReportEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Report.Include(r => r.User).Include(r => r.ReportDetails).Select(r => new ReportViewModel()
            {
                Id = r.Id,
                City = r.City.Name,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Document = r.Document,

            }).ToListAsync());
        }


        // GET: ReportEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntity = await _context.Report
                 .Include(r => r.ReportDetails).ThenInclude(rd => rd.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportEntity == null)
            {
                return NotFound();
            }

            return View(reportEntity);
        }
        // GET: ReportEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Document,SourceLatitude,SourceLongitude,TargetLatitude,TargetLongitude")] ReportEntity reportEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportEntity);
        }

        // GET: ReportEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntity = await _context.Report.FindAsync(id);
            if (reportEntity == null)
            {
                return NotFound();
            }
            return View(reportEntity);
        }

        // POST: ReportEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Document,SourceLatitude,SourceLongitude,TargetLatitude,TargetLongitude")] ReportEntity reportEntity)
        {
            if (id != reportEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportEntityExists(reportEntity.Id))
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
            return View(reportEntity);
        }

        // GET: ReportEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportEntity = await _context.Report
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportEntity == null)
            {
                return NotFound();
            }

            return View(reportEntity);
        }

        // POST: ReportEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportEntity = await _context.Report.FindAsync(id);
            _context.Report.Remove(reportEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportEntityExists(int id)
        {
            return _context.Report.Any(e => e.Id == id);
        }
    }
}
