using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NOV26.Protofolio.web.Data;
using NOV26.Protofolio.web.Models;

namespace NOV26.Protofolio.web.Controllers
{
    public class SelectListModel
    {
        public string Name { get; set; }
    }
    public class ServiceModelsController : Controller
    {
        private readonly NOV26ProtofoliowebContext _context;

        public List<SelectListModel> Icons;

        public ServiceModelsController(NOV26ProtofoliowebContext context)
        {
            _context = context;
            Icons = new List<SelectListModel> {
                new SelectListModel() { Name = "flaticon-analysis" },
                new SelectListModel(){Name="flaticon-flasks" },
                new SelectListModel() {Name="flaticon-ideas" } };


            var icons2 = new List<object> { new { Name = "flaticon-analysis" },
                                        new {Name="flaticon-flasks" },
                                        new {Name="flaticon-ideas" } };


        }

        // GET: ServiceModels
        public async Task<IActionResult> Index()
        {
            return _context.ServiceModel != null ?
                        View(await _context.ServiceModel.ToListAsync()) :
                        Problem("Entity set 'NOV26ProtofoliowebContext.ServiceModel'  is null.");
        }

        // GET: ServiceModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceModel == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.ServiceModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // GET: ServiceModels/Create
        public IActionResult Create()
        {

            ViewData["Icons"] = new SelectList(Icons.ToList(), "Name", "Name");
            return View();
        }

        // POST: ServiceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Icon,Description")] ServiceModel serviceModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Icons"] = new SelectList(Icons);
            return View(serviceModel);
        }

        // GET: ServiceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceModel == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.ServiceModel.FindAsync(id);
            if (serviceModel == null)
            {
                return NotFound();
            }
            ViewData["Icons"] = new SelectList(Icons.ToList(), "Name", "Name");
            return View(serviceModel);
        }

        // POST: ServiceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Icon,Description")] ServiceModel serviceModel)
        {
            if (id != serviceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceModelExists(serviceModel.Id))
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
            //collection
            string[] Icons = new string[] {

                "flaticon-analysis",
                "flaticon-flasks",
                "flaticon-ideas" };


            //collection convert to select list

            var selectList = new SelectList(Icons);
            //setting data in view bag
            ViewData["Icons"] = Icons;
            return View(serviceModel);
        }

        // GET: ServiceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceModel == null)
            {
                return NotFound();
            }

            var serviceModel = await _context.ServiceModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(serviceModel);
        }

        // POST: ServiceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceModel == null)
            {
                return Problem("Entity set 'NOV26ProtofoliowebContext.ServiceModel'  is null.");
            }
            var serviceModel = await _context.ServiceModel.FindAsync(id);
            if (serviceModel != null)
            {
                _context.ServiceModel.Remove(serviceModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceModelExists(int id)
        {
            return (_context.ServiceModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
