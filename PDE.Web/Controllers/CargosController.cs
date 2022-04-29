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
    public class CargosController : Controller
    {
        private readonly IUnitOfWork _unitWork;

        public CargosController(IUnitOfWork unitWork)
        {
            _unitWork = unitWork;
        }

        // GET: Cargos
        public async Task<IActionResult> Index()
        {
           
            return View(await _unitWork.Cargo.GetAll());
        }

        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _unitWork.Cargo.GetById(id.Value);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // GET: Cargos/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                await _unitWork.Cargo.Add(cargo);
                await _unitWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cargo);
        }

        // GET: Cargos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _unitWork.Cargo.GetById(id.Value);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitWork.Cargo.Update(cargo);
                    await _unitWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CargoExists(cargo.Id))
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
            return View(cargo);
        }

        // GET: Cargos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _unitWork.Cargo.GetById(id.Value);
            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargo = await _unitWork.Cargo.GetById(id);
            _unitWork.Cargo.Remove(cargo);
            await _unitWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CargoExists(int id)
        {
            var cargos = await _unitWork.Cargo.GetAll();

            return cargos.Any(a => a.Id == id);
        }
    }
}
