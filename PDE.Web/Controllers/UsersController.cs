using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PDE.Models.Entities.Identity;
using PDE.Models.Service;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace PDE.Web.Controllers
{
    public class UsersController : Controller
    {

        private IAuthenticateService _authenticateService;

        public UsersController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel usuario)
        {
            var token = await _authenticateService.Login($"api/Authenticate/login/", usuario);

            if (token != null)
            {

                var strUser = JsonConvert.DeserializeObject<RegisterModel>(token.user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, strUser.UserName),
                    new Claim(ClaimTypes.UserData, token.user),
                    new Claim("Token", token.token),
                    new Claim("MiembroId", strUser.MiembroId.ToString()),
                    new Claim("CargoId", strUser.CargoId.ToString()),
                    new Claim("FullName",$"{strUser.Nombres} {strUser.Apellidos}")
                };

                var claimsIdentity = new ClaimsIdentity(
                    authClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    IsPersistent = usuario.IsPersistent                    
                };

               await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

               return RedirectToAction("Index","Home");
            }

            return View(usuario);
        }


        [HttpGet]
        public async Task<IActionResult> Logon()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


    }
}
