using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDE.Models.Dto;
using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EstructurasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstructurasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Estructuras
        [HttpGet]
        public async Task<IEnumerable<EstructuraDto>> GetEstructuras()
        {
            var estructuras = await _unitOfWork.Estructura.GetAll();
            return _mapper.Map<IEnumerable<EstructuraDto>>(estructuras);
        }

        // GET: api/Estructuras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstructuraDto>> GetEstructura(int id)
        {
            var estructura = await _unitOfWork.Estructura.GetById(id);

            if (estructura == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<EstructuraDto>(estructura);

            return data;
        }

        // PUT: api/Estructuras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstructura(int id, EstructuraDto estructura)
        {
            if (id != estructura.Id)
            {
                return BadRequest();
            }
            var data = _mapper.Map<Estructura>(estructura);
            _unitOfWork.Estructura.Update(data);

            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EstructuraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Estructuras
        [HttpPost]
        public async Task<ActionResult<Estructura>> PostEstructura(EstructuraDto estructura)
        {
            var data = _mapper.Map<Estructura>(estructura);
            await _unitOfWork.Estructura.Add(data);
            await _unitOfWork.Save();

            return CreatedAtAction("GetEstructura", new { id = estructura.Id }, estructura);
        }

        // DELETE: api/Estructuras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstructura(int id)
        {
            var estructura = await _unitOfWork.Estructura.GetById(id);
            if (estructura == null)
            {
                return NotFound();
            }

            _unitOfWork.Estructura.Remove(estructura);
            await _unitOfWork.Save();

            return NoContent();
        }

        private async Task<bool> EstructuraExists(int id)
        {
            return (await _unitOfWork.Estructura.GetById(id)) != null;
        }
    }
}
