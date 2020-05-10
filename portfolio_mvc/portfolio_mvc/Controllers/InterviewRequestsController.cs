using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using portfolio_mvc.Models;

namespace portfolio_mvc.Controllers
{
    public class InterviewRequestsController : Controller
    {
        private readonly PortfolioContext _context;

        public InterviewRequestsController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: InterviewRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.InterviewRequests.ToListAsync());
        }

        // GET: InterviewRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interviewRequest = await _context.InterviewRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interviewRequest == null)
            {
                return NotFound();
            }

            return View(interviewRequest);
        }

        // GET: InterviewRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InterviewRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,Location")] InterviewRequest interviewRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interviewRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interviewRequest);
        }

        // GET: InterviewRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interviewRequest = await _context.InterviewRequests.FindAsync(id);
            if (interviewRequest == null)
            {
                return NotFound();
            }
            return View(interviewRequest);
        }

        // POST: InterviewRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,Location")] InterviewRequest interviewRequest)
        {
            if (id != interviewRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interviewRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterviewRequestExists(interviewRequest.Id))
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
            return View(interviewRequest);
        }

        // GET: InterviewRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interviewRequest = await _context.InterviewRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (interviewRequest == null)
            {
                return NotFound();
            }

            return View(interviewRequest);
        }

        // POST: InterviewRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interviewRequest = await _context.InterviewRequests.FindAsync(id);
            _context.InterviewRequests.Remove(interviewRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterviewRequestExists(int id)
        {
            return _context.InterviewRequests.Any(e => e.Id == id);
        }
    }
}
