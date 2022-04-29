#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDE.DataAccess;
using PDE.Models.Entities.Padron;
using PDE.Models.Interfaces;

namespace PDE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadronController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public PadronController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        [HttpGet("GetByCedula/{cedula}")]
        public async Task<IActionResult>  GetByCedula(string cedula)
        {
            var data = await _unitOfWork.Padron.GetPadron(cedula);

            if (data == null)
            {
                return NotFound(cedula);
            }

            return Ok(data);
        }

      

        //private bool PadronExists(string id)
        //{
        //    return _context.Padrons.Any(e => e.Cedula == id);
        //}
    }
}
