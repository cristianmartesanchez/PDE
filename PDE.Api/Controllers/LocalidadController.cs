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
using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocalidadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        // GET: api/Localidad
        [HttpGet]
        public async Task<IEnumerable<LocalidadDto>> GetLocalidads()
        {
            var localidades = await _unitOfWork.Localidad.GetAll();
            var data = _mapper.Map<IEnumerable<LocalidadDto>>(localidades);
            return data;
        }

        // GET: api/Localidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalidadDto>> GetLocalidad(int id)
        {
            var localidad = await _unitOfWork.Localidad.GetById(id);

            if (localidad == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<LocalidadDto>(localidad);
            return data;
        }

        // PUT: api/Localidad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidad(int id, LocalidadDto localidad)
        {
            if (id != localidad.Id)
            {
                return BadRequest();
            }
            var data = _mapper.Map<Localidad>(localidad);
            _unitOfWork.Localidad.Update(data);

            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LocalidadExists(id))
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

        // POST: api/Localidad
        [HttpPost]
        public async Task<ActionResult<LocalidadDto>> PostLocalidad(LocalidadDto localidad)
        {
            var data = _mapper.Map<Localidad>(localidad);
            await _unitOfWork.Localidad.Add(data);
            await _unitOfWork.Save();

            return CreatedAtAction("GetLocalidad", new { id = localidad.Id }, localidad);
        }

        // DELETE: api/Localidad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidad(int id)
        {
            var localidad = await _unitOfWork.Localidad.GetById(id);
            if (localidad == null)
            {
                return NotFound();
            }

            _unitOfWork.Localidad.Remove(localidad);
            await _unitOfWork.Save();

            return NoContent();
        }

        private async Task<bool> LocalidadExists(int id)
        {
            return (await _unitOfWork.Localidad.GetAll()).Any(e => e.Id == id);
        }
    }
}
