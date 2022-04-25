#nullable disable
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
    public class MiembrosController : Controller
    {
        //private readonly DBPDEContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public MiembrosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Miembros
        public async Task<IActionResult> Index()
        {
            var data = await _unitOfWork.Miembros.GetMiembros().ToListAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarPadron(string cedula)
        {
            //var cargoActualId = null;

            var cargos = await _unitOfWork.CargosTerritoriales.GetCargosTerritoriales().ToListAsync();
            ViewBag.Cargos = new SelectList(cargos, "Id", "Cargo.Descripcion");

            var estadoCivils = _unitOfWork.EstadoCivil.GetAll();
            ViewBag.EstadoCivil = new SelectList(estadoCivils, "Id", "Descripcion");

            var sexo = _unitOfWork.Sexo.GetAll();
            ViewBag.Sexo = new SelectList(sexo, "Id", "Descripcion");

            var data = _unitOfWork.Padron.GetPadron(cedula);
            return PartialView("partial/_createForm", data);
        }

        //// GET: Miembros/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var miembro = await _context.Miembros
        //        .Include(m => m.Referido)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (miembro == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(miembro);
        //}

        // GET: Miembros/Create
        public async Task<IActionResult> CreateAsync()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Miembro miembro)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Miembros.Add(miembro);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return PartialView("partial/_createForm", miembro);
        }

        //// GET: Miembros/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var miembro = await _context.Miembros.FindAsync(id);
        //    if (miembro == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ReferidoId"] = new SelectList(_context.Miembros, "Id", "Apellidos", miembro.ReferidoId);
        //    return View(miembro);
        //}

        //// POST: Miembros/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,Cedula,FechaNacimiento,Sexo,Celular,ReferidoId,CargoId")] Miembro miembro)
        //{
        //    if (id != miembro.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(miembro);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MiembroExists(miembro.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ReferidoId"] = new SelectList(_context.Miembros, "Id", "Apellidos", miembro.ReferidoId);
        //    return View(miembro);
        //}

        //// GET: Miembros/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var miembro = await _context.Miembros
        //        .Include(m => m.Referido)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (miembro == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(miembro);
        //}

        //// POST: Miembros/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var miembro = await _context.Miembros.FindAsync(id);
        //    _context.Miembros.Remove(miembro);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool MiembroExists(int id)
        //{
        //    return _context.Miembros.Any(e => e.Id == id);
        //}
    }
}
