#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDE.DataAccess;
using PDE.Models.Dto;
using PDE.Models.Entities.Padron;
using PDE.Models.Interfaces;

namespace PDE.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PadronController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PadronController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("GetByCedula/{cedula}")]
        public async Task<IActionResult>  GetByCedula(string cedula)
        {
            var data = await _unitOfWork.Padron.GetPadron(cedula);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

      

    }
}
