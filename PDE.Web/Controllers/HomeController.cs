using Microsoft.AspNetCore.Mvc;
using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Web.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDE.Models.Service;
using System.Linq;

namespace PDE.Web.Controllers
{
    public class HomeController : Controller
    {

        public string UrlBase = $"api/Miembros/";
        private IMiembroService _miembroService;
        private IProvinciaService _provinciaService;
        private ICargoService _cargoService;
        private IMetasService _metasService;

        public HomeController(IMiembroService miembroService, IProvinciaService provinciaService, 
            ICargoService cargoService, IMetasService metasService)
        {
            _miembroService = miembroService;
            _provinciaService = provinciaService;
            _cargoService = cargoService;
            _metasService = metasService;
        }

        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");

            var miembros = await _miembroService.GetAll(UrlBase, token.Value);
            var provincias = await _provinciaService.GetAll($"{UrlBase}GetProvincias", token.Value);

            ViewBag.Provincias = new SelectList(provincias, "Id", "Descripcion");
            double pleno = miembros.Count(a => a.EstructuraId == 1);
            double pais = miembros.Count(a => a.EstructuraId == 2);
            double exterior = miembros.Count(a => a.EstructuraId == 3);

            ViewBag.Totales = new
            {
                TotalPleno = pleno,
                PorcientoPleno = (pleno * 100) / 10000,
                TotalPais = pais,
                PorcientoPais = (pais * 100) / 10000,
                TotalExterior = exterior,
                PorcientoExterior = (exterior * 100) / 10000
            };

            return View();
        }


        private async Task<bool> MiembroExists(string username)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            string url = UrlBase + $"GetMiembroByCedula/{username}";
            return (await _miembroService.Get(url, token.Value)) != null;
        }

        [HttpGet]
        public async Task<IActionResult> GetMiembros(string cedula = "", int estructuraId = 0, int cargoId = 0, int provinciaId = 0)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var data = await _miembroService.GetAll(UrlBase, token.Value);

            if (!string.IsNullOrEmpty(cedula))
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

            return PartialView("partial/_tableMiembro", data);
        }

        [HttpGet]
        public async Task<JsonResult> GetCargosByEstructura(int estructuraId)
        {
            var token = User.Claims.FirstOrDefault(a => a.Type == "Token");
            var data = await _cargoService.GetAll($"api/Cargos/GetCargosByEstructura/{estructuraId}",token.Value);
            return Json(data.DistinctBy(a => a.Id));
        }

    }
}