using Microsoft.AspNetCore.Mvc;
using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Web.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PDE.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Provincias = new SelectList(await _unitOfWork.Provincia.GetAll(), "Id", "Descripcion");
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            
            if(await MiembroExists(usuario.Cedula))
            {
                var user = await _unitOfWork.Miembros.GetMiembroByCedula(usuario.Cedula);
                var str = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("Usuario", str);

                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> GetMiembros(string cedula = "", int estructuraId = 0, int cargoId = 0, int provinciaId = 0)
        {
            var data = _unitOfWork.Miembros.GetMiembros();

            if(!string.IsNullOrEmpty(cedula))
            {
                data = data.Where(a => a.Cedula == cedula);
            }
            else if(estructuraId != 0)
            {
                data = data.Where(a => a.EstructuraId == estructuraId);

                if(cargoId != 0)
                {
                    data = data.Where(a => a.CargoId == cargoId);
                }
            }
            else if(provinciaId != 0)
            {
                data = data.Where(a => a.Municipio.ProvinciaId == provinciaId);
            }

            return PartialView("partial/_tableMiembro", await data.ToListAsync());
        }

        [HttpGet]
        public async Task<JsonResult> GetCargosByEstructura(int estructuraId)
        {
            var data = (await _unitOfWork.Cargo.GetCargosByEstructura(estructuraId)).DistinctBy(a => a.Id);
            return Json(data);
        }

        private async Task<bool> MiembroExists(string cedula)
        {
            return (await _unitOfWork.Miembros.GetAll()).Any(e => e.Cedula == cedula);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}