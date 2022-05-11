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
    public class CargoTerritorialsController : Controller
    {

        private ICargosTerritorialesService _cargosTerritorialesService;
        private ICargoService _cargoService;
        private ILocalidadService _localidadService;
        private IEstructuraService _elestructuraService;

        private string UrlBase = "api/CargoTerritorials/";
        public CargoTerritorialsController(ICargosTerritorialesService cargosTerritorialesService,
            ICargoService cargoService, ILocalidadService localidadService, IEstructuraService estructuraService)
        {
            _cargosTerritorialesService = cargosTerritorialesService;
            _cargoService = cargoService;
            _localidadService = localidadService;
            _elestructuraService = estructuraService;
        }

        // GET: CargoTerritorials
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var data = await _cargosTerritorialesService.GetAll(UrlBase, token.Value);
            return View(data);
        }

        public async Task DropDown(int cargoId = 0, int localidadId = 0, int supervisorId = 0, int estructuraId = 0)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var cargos = await _cargoService.GetAll("api/Cargos",token.Value);
            ViewBag.CargoId = new SelectList(cargos, "Id", "Descripcion",cargoId);
            var localidades = await _localidadService.GetAll("api/Localidad",token.Value);
            ViewBag.LocalidadId = new SelectList(localidades, "Id", "Nombre", localidadId);
            ViewBag.SupervisorId = new SelectList(cargos, "Id", "Descripcion", supervisorId);
            var estructura = await _elestructuraService.GetAll("api/Estructuras", token.Value);
            ViewBag.EstructuraId = new SelectList(estructura, "Id","Descripcion", estructuraId);
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
                var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
                await _cargosTerritorialesService.Post(UrlBase,cargoTerritorial, token.Value);

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

            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var cargoTerritorial = await _cargosTerritorialesService.Get($"{UrlBase}{id.Value}",token.Value);
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
                    var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
                    await _cargosTerritorialesService.Put($"{UrlBase}{id}", cargoTerritorial, token.Value);

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
        [HttpPost("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            await _cargosTerritorialesService.Delete($"{UrlBase}{id}",token.Value);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CargoTerritorialExists(int id)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var cargoTerritorial = await _cargosTerritorialesService.Get($"{UrlBase}{id}", token.Value);
            return cargoTerritorial != null;
        }
    }
}
