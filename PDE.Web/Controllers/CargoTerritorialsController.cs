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

        private readonly IUnitOfWork _unitWork;

        public CargoTerritorialsController(IUnitOfWork unitWork)
        {
            _unitWork = unitWork;
        }

        // GET: CargoTerritorials
        public async Task<IActionResult> Index()
        {
            var data = await _unitWork.CargosTerritoriales.GetCargoTerritoriales().ToListAsync();
            return View(data);
        }

        public async Task DropDown(int cargoId = 0, int localidadId = 0, int supervisorId = 0, int estructuraId = 0)
        {
            ViewBag.CargoId = new SelectList(await _unitWork.Cargo.GetAll(), "Id", "Descripcion",cargoId);
            ViewBag.LocalidadId = new SelectList(await _unitWork.Localidad.GetAll(), "Id", "Nombre", localidadId);
            ViewBag.SupervisorId = new SelectList(await _unitWork.Cargo.GetAll(), "Id", "Descripcion", supervisorId);
            ViewBag.EstructuraId = new SelectList(await _unitWork.Estructura.GetAll(),"Id","Descripcion", estructuraId);
        }

        // GET: CargoTerritorials/Create
        public async Task<IActionResult> Create()
        {
            await DropDown();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CargoTerritorial cargoTerritorial)
        {
            if (ModelState.IsValid)
            {
                await _unitWork.CargosTerritoriales.Add(cargoTerritorial);
                await _unitWork.Save();
                return RedirectToAction(nameof(Index));
            }

            await DropDown();
            return View(cargoTerritorial);
        }

        // GET: CargoTerritorials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoTerritorial = await _unitWork.CargosTerritoriales.GetById(id.Value);
            if (cargoTerritorial == null)
            {
                return NotFound();
            }
            await DropDown(cargoTerritorial.CargoId, cargoTerritorial.LocalidadId, cargoTerritorial.CargoSupervisorId.Value, cargoTerritorial.EstructuraId);
            return View(cargoTerritorial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CargoTerritorial cargoTerritorial)
        {
            if (id != cargoTerritorial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitWork.CargosTerritoriales.Update(cargoTerritorial);
                    await _unitWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CargoTerritorialExists(cargoTerritorial.Id))
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
            await DropDown(cargoTerritorial.CargoId, cargoTerritorial.LocalidadId, cargoTerritorial.CargoSupervisorId.Value, cargoTerritorial.EstructuraId);
            return View(cargoTerritorial);
        }


        // POST: CargoTerritorials/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargoTerritorial = await _unitWork.CargosTerritoriales.GetById(id);
            _unitWork.CargosTerritoriales.Remove(cargoTerritorial);
            await _unitWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CargoTerritorialExists(int id)
        {
            return (await _unitWork.CargosTerritoriales.GetAll()).Any(e => e.Id == id);
        }
    }
}
