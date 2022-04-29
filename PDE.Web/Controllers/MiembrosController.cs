using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PDE.DataAccess;
using PDE.Models.Entities;
using PDE.Models.Interfaces;
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

        async void DropDown()
        {
            var str = HttpContext.Session.GetString("Usuario");
            var user = JsonConvert.DeserializeObject<Miembro>(str);

            var cargos = _unitOfWork.CargosTerritoriales.GetCargosBySupervisor(user.CargoId);
            ViewBag.Cargos = new SelectList(cargos, "Id", "Cargo.Descripcion");

            ViewBag.EstadoCivil = new SelectList(await _unitOfWork.EstadoCivil.GetAll(), "Id", "Descripcion");

            ViewBag.Localidad = new SelectList(await _unitOfWork.Localidad.GetAll(),"Id","Nombre");

            ViewBag.Sexo = new SelectList(await _unitOfWork.Sexo.GetAll(), "Id", "Descripcion");

        }

        [HttpGet]
        public JsonResult GetCargosByLocalidad(int localidadId)
        {
            var data =  _unitOfWork.CargosTerritoriales.GetCargosByLocalidad(localidadId);
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> GetSupervisorByCargo(int cargoId)
        {
            var data = await _unitOfWork.Miembros.GetSupervisorByCargo(cargoId);
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

                if(! _unitOfWork.Miembros.MiembroExists(miembro.Cedula))
                {
                    var str = HttpContext.Session.GetString("Usuario");
                    var user = JsonConvert.DeserializeObject<Miembro>(str);
                 
                    _unitOfWork.Miembros.Add(miembro);
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

            var miembro = await  _unitOfWork.Miembros.GetById(id.Value);
            if (miembro == null)
            {
                return NotFound();
            }


            ViewData["Cargos"] = new SelectList(await _unitOfWork.Cargo.GetAll(), "Id", "Descripcion",miembro.CargoId);
            ViewData["EstadoCivil"] = new SelectList(await _unitOfWork.EstadoCivil.GetAll(), "Id", "Descripcion", miembro.EstadoCivilId);
            ViewData["Sexo"] = new SelectList(await _unitOfWork.Sexo.GetAll(), "Id", "Descripcion", miembro.SexoId);

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

                    miembro.SupervisorId = user.Id;
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
            ViewData["Cargos"] = new SelectList(await _unitOfWork.Cargo.GetAll(), "Id", "Descripcion", miembro.CargoId);
            ViewData["EstadoCivil"] = new SelectList(await _unitOfWork.EstadoCivil.GetAll(), "Id", "Descripcion", miembro.EstadoCivilId);
            ViewData["Sexo"] = new SelectList(await _unitOfWork.Sexo.GetAll(), "Id", "Descripcion", miembro.SexoId);
            return View(miembro);
        }



        private async Task<bool> MiembroExists(int id)
        {
            return (await _unitOfWork.Miembros.GetAll()).Any(e => e.Id == id);
        }
    }
}
