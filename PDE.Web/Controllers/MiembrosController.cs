using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PDE.DataAccess;
using PDE.DataAccess.Service;
using PDE.Models.Dto;
using PDE.Models.Entities;
using PDE.Models.Entities.Identity;
using PDE.Models.Interfaces;
using PDE.Models.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDE.Web.Controllers
{
    public class MiembrosController : Controller
    {

        public string UrlBase = $"api/Miembros/";
        private IMiembroService _miembroService;
        private ICargosTerritorialesService _cargosTerritoriales;
        private ILocalidadService _localidadService;
        private IPadronService _padronService;
        private IAuthenticateService _authenticateService;

        public MiembrosController(IMiembroService miembroService, 
            ICargosTerritorialesService cargosTerritoriales, ILocalidadService localidadService,
            IPadronService padronService, IAuthenticateService authenticateService)
        {
            _miembroService = miembroService;
            _cargosTerritoriales = cargosTerritoriales;
            _localidadService = localidadService;
            _padronService = padronService;
            _authenticateService = authenticateService;
        }

        // GET: Miembros
        public async Task<IActionResult> Index()
        {

            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var userId = User.Claims.FirstOrDefault(a => a.Type == "MiembroId");

            var data = await _miembroService.GetAll($"{UrlBase}GetMiembrosBySupervisor/{userId.Value}", token.Value);

            return View(data);
        }

        async void DropDown(int cargoId = 0, int localidadId = 0)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var cargo = User.Claims.FirstOrDefault(a => a.Type == "CargoId");

            var cargos = await _cargosTerritoriales.GetAll($"api/CargoTerritorials/GetCargosBySupervisor/{cargo.Value}",token.Value);
            ViewBag.Cargos = new SelectList(cargos, "CargoId", "Cargo.Descripcion", cargoId);

            var localidad = await _localidadService.GetAll($"api/Localidad/", token.Value);
            ViewBag.Localidades = new SelectList(localidad, "Id","Nombre", localidadId);

        }

        [HttpGet]
        public async Task<JsonResult> GetCargosByLocalidad(int localidadId)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            string url = $"api/CargoTerritorials/GetCargosByLocalidad/{localidadId}";
            var data = await _cargosTerritoriales.GetAll(url, token.Value);            
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetSupervisorByCargo(int CargoId, int LocalidadId)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var url = $"{UrlBase}GetSupervisorByCargo/{CargoId}/{LocalidadId}";
            var data = await _miembroService.GetAll(url, token.Value);

            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarPadron(string cedula)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            DropDown();
            var data = await _miembroService.Get($"api/Padron/GetByCedula/{cedula}", token.Value);
            return PartialView("partial/_createForm", data);
        }

        // GET: Miembros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            if (id == null)
            {
                return NotFound();
            }
            var url = $"{UrlBase}{id.Value}";
            var miembro = await _miembroService.Get(url, token.Value);

            if (miembro == null)
            {
                return NotFound();
            }

            return View(miembro);
        }

        // GET: Miembros/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MiembroDto miembro)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            if (ModelState.IsValid)
            {
                miembro.SupervisorId = miembro.SupervisorId == 0 ? null : miembro.SupervisorId;

                var data = await _cargosTerritoriales.GetAll("api/CargoTerritorials/", token.Value);
                var estructura = data.FirstOrDefault(a => a.CargoId == miembro.CargoId 
                && a.LocalidadId == miembro.LocalidadId);

                var exists = await _miembroService.Get($"{UrlBase}GetMiembroByCedula/{miembro.Cedula}", token.Value);
                if (exists == null)
                {

                    miembro.EstructuraId = estructura.EstructuraId;

                   var nuevoMiembro = await _miembroService.Post(UrlBase,miembro, token.Value);

                    if(nuevoMiembro != null)
                    {
                        var newUser = new RegisterModel
                        {
                            UserName = nuevoMiembro.Cedula,
                            Celular = nuevoMiembro.Celular,
                            Cedula = nuevoMiembro.Cedula,
                            MiembroId = nuevoMiembro.Id,
                            CargoId = nuevoMiembro.CargoId,
                            Nombres = nuevoMiembro.Nombres,
                            Apellidos = nuevoMiembro.Apellidos
                        };

                        await _authenticateService.Post("api/Authenticate/register", newUser);
                    }


                    return RedirectToAction(nameof(Index));
                }

            }
            DropDown();
            return PartialView("partial/_createForm", miembro);
        }

        // GET: Miembros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await _miembroService.Get($"{UrlBase}{id.Value}", token.Value);
            if (miembro == null)
            {
                return NotFound();
            }            

            DropDown(miembro.CargoId,miembro.LocalidadId);
            return View(miembro);
        }

        // POST: Miembros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MiembroDto miembro)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            if (id != miembro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var data = await _cargosTerritoriales.GetAll("api/CargoTerritorials/", token.Value);
                    var estructura = data.FirstOrDefault(a => a.CargoId == miembro.CargoId
                    && a.LocalidadId == miembro.LocalidadId);
                    miembro.EstructuraId = estructura.EstructuraId;

                    await _miembroService.Put($"{UrlBase}{id}",miembro, token.Value);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MiembroExists(miembro.Id))
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
            DropDown(miembro.CargoId,miembro.LocalidadId);
            return View(miembro);
        }



        private async Task<bool> MiembroExists(int id)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var miembro = await _miembroService.Get($"{UrlBase}{id}", token.Value);
            return miembro != null;
        }
    }
}
