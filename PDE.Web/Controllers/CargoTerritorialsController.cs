using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDE.DataAccess;
using PDE.Models.Entities;
using PDE.Models.Interfaces;

namespace PDE.Web.Controllers
{
    public class CargoTerritorialsController : Controller
    {
        private readonly DBPDEContext _context;

        private readonly IUnitOfWork _unitWork;

        public CargoTerritorialsController(DBPDEContext context, IUnitOfWork unitWork)
        {
            _context = context;
            _unitWork = unitWork;
        }

        // GET: CargoTerritorials
        public async Task<IActionResult> Index()
        {
            var data = _unitWork.CargosTerritoriales.GetCargosTerritoriales();
            return View(await data.ToListAsync());
        }

        // GET: CargoTerritorials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoTerritorial = await _context.CargoTerritorials
                .Include(c => c.Cargo)
                .Include(c => c.Localidad)
                .Include(c => c.Supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargoTerritorial == null)
            {
                return NotFound();
            }

            return View(cargoTerritorial);
        }

        // GET: CargoTerritorials/Create
        public IActionResult Create()
        {
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Descripcion");
            ViewData["LocalidadId"] = new SelectList(_context.Localidads, "Id", "Nombre");
            ViewData["SupervisorId"] = new SelectList(_context.Cargos, "Id", "Descripcion");
            return View();
        }

        // POST: CargoTerritorials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CargoTerritorial cargoTerritorial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargoTerritorial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Descripcion", cargoTerritorial.CargoId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidads, "Id", "Nombre", cargoTerritorial.LocalidadId);
            ViewData["SupervisorId"] = new SelectList(_context.Cargos, "Id", "Descripcion", cargoTerritorial.SupervisorId);
            return View(cargoTerritorial);
        }

        // GET: CargoTerritorials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoTerritorial = await _context.CargoTerritorials.FindAsync(id);
            if (cargoTerritorial == null)
            {
                return NotFound();
            }
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Descripcion", cargoTerritorial.CargoId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidads, "Id", "Nombre", cargoTerritorial.LocalidadId);
            ViewData["SupervisorId"] = new SelectList(_context.Cargos, "Id", "Descripcion", cargoTerritorial.SupervisorId);
            return View(cargoTerritorial);
        }

        // POST: CargoTerritorials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CargoId,SupervisorId,LocalidadId")] CargoTerritorial cargoTerritorial)
        {
            if (id != cargoTerritorial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargoTerritorial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoTerritorialExists(cargoTerritorial.Id))
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
            ViewData["CargoId"] = new SelectList(_context.Cargos, "Id", "Descripcion", cargoTerritorial.CargoId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidads, "Id", "Nombre", cargoTerritorial.LocalidadId);
            ViewData["SupervisorId"] = new SelectList(_context.Cargos, "Id", "Descripcion", cargoTerritorial.SupervisorId);
            return View(cargoTerritorial);
        }

        // GET: CargoTerritorials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoTerritorial = await _context.CargoTerritorials
                .Include(c => c.Cargo)
                .Include(c => c.Localidad)
                .Include(c => c.Supervisor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargoTerritorial == null)
            {
                return NotFound();
            }

            return View(cargoTerritorial);
        }

        // POST: CargoTerritorials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargoTerritorial = await _context.CargoTerritorials.FindAsync(id);
            _context.CargoTerritorials.Remove(cargoTerritorial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoTerritorialExists(int id)
        {
            return _context.CargoTerritorials.Any(e => e.Id == id);
        }
    }
}
