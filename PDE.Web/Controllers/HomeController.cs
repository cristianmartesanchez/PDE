using Microsoft.AspNetCore.Mvc;
using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Web.Models;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace PDE.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
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