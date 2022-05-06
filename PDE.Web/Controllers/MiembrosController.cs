using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PDE.DataAccess;
using PDE.DataAccess.Service;
using PDE.Models.Entities;
using PDE.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDE.Web.Controllers
{
    public class MiembrosController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public MiembrosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Miembros
        public async Task<IActionResult> Index()
        {
            var str = HttpContext.Session.GetString("Usuario");
            var user = JsonConvert.DeserializeObject<Miembro>(str);

            var data =  _unitOfWork.Miembros.GetMiembrosBySupervisor(user.Id);
            return View(data);
        }

        async void DropDown(int cargoId = 0, int estadoCivilId = 0, int localidadId = 0, int sexoId = 0)
        {
            var str = HttpContext.Session.GetString("Usuario");
            var user = JsonConvert.DeserializeObject<Miembro>(str);

            var cargos = _unitOfWork.CargosTerritoriales.GetCargosBySupervisor(user.CargoId);
            ViewBag.Cargos = new SelectList(cargos, "CargoId", "Cargo.Descripcion", cargoId);

            //ViewBag.EstadoCivil = new SelectList(await _unitOfWork.EstadoCivil.GetAll(), "Id", "Descripcion", estadoCivilId);
            var localidad = await _unitOfWork.Localidad.GetAll();
            ViewBag.Localidad = new SelectList(localidad, "Id","Nombre", localidadId);

            //ViewBag.Sexo = new SelectList(await _unitOfWork.Sexo.GetAll(), "Id", "Descripcion", sexoId);

        }

        [HttpGet]
        public JsonResult GetCargosByLocalidad(int localidadId)
        {
            var data =  _unitOfWork.CargosTerritoriales.GetCargosByLocalidad(localidadId);
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetSupervisorByCargo(int CargoId, int LocalidadId)
        {
            var data = await _unitOfWork.Miembros.GetSupervisorByCargo(CargoId,LocalidadId);
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarPadron(string cedula)
        {
            DropDown();

            var data = await _unitOfWork.Padron.GetPadron(cedula);
            return PartialView("partial/_createForm", data);
        }

        // GET: Miembros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await _unitOfWork.Miembros.GetById(id.Value);

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
        public async Task<IActionResult> Create(Miembro miembro)
        {
            
            if (ModelState.IsValid)
            {
                var estructura = _unitOfWork.CargosTerritoriales.GetCargoTerritoriales()
                    .FirstOrDefault(a => a.CargoId == miembro.CargoId && a.LocalidadId == miembro.LocalidadId);

                if (! _unitOfWork.Miembros.MiembroExists(miembro.Cedula))
                {
                    var str = HttpContext.Session.GetString("Usuario");
                    var user = JsonConvert.DeserializeObject<Miembro>(str);

                    miembro.EstructuraId = estructura.EstructuraId;
                    await _unitOfWork.Miembros.Add(miembro);
                    await _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }

            }
            DropDown();
            return PartialView("partial/_createForm", miembro);
        }

        // GET: Miembros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miembro = await  _unitOfWork.Miembros.GetMiembros().FirstOrDefaultAsync(a => a.Id == id.Value);
            if (miembro == null)
            {
                return NotFound();
            }            

            DropDown(miembro.CargoId, miembro.EstadoCivilId.Value,miembro.LocalidadId ,miembro.SexoId.Value);
            return View(miembro);
        }

        // POST: Miembros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Miembro miembro)
        {
            if (id != miembro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var str = HttpContext.Session.GetString("Usuario");
                    var user = JsonConvert.DeserializeObject<Miembro>(str);

                    var estructura = _unitOfWork.CargosTerritoriales.GetCargoTerritoriales()
                    .FirstOrDefault(a => a.CargoId == miembro.CargoId && a.LocalidadId == miembro.LocalidadId);
                    miembro.EstructuraId = estructura.EstructuraId;

                    _unitOfWork.Miembros.Update(miembro);
                    await _unitOfWork.Save();
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
            DropDown(miembro.CargoId, miembro.EstadoCivilId.Value, 0, miembro.SexoId.Value);
            return View(miembro);
        }



        private async Task<bool> MiembroExists(int id)
        {
            return (await _unitOfWork.Miembros.GetAll()).Any(e => e.Id == id);
        }
    }
}
