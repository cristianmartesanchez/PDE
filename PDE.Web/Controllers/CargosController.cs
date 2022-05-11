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
using PDE.Models.Service;

namespace PDE.Web.Controllers
{
    public class CargosController : Controller
    {
        private ICargoService _cargoService;
        private string urlBase = "api/Cargos/";
        public CargosController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        // GET: Cargos
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var cargos = await _cargoService.GetAll(urlBase,token.Value); 
            return View(cargos);
        }

        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var cargo = await _cargoService.Get($"{urlBase}{id.Value}",token.Value);
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
                var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
                await _cargoService.Post($"{urlBase}",cargo,token.Value);

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

            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var cargo = await _cargoService.Get($"{urlBase}{id.Value}",token.Value);
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
                    var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
                    await _cargoService.Put($"{urlBase}{id}", cargo, token.Value);
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


        // POST: Cargos/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var cargo = await _cargoService.Get($"{urlBase}{id}", token.Value);
            await _cargoService.Delete($"{urlBase}{id}", token.Value);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CargoExists(int id)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var cargo = await _cargoService.GetAll($"{urlBase}", token.Value);

            return cargo.Any(a => a.Id == id);
        }
    }
}
