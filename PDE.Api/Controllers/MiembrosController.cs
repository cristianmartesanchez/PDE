using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDE.Models.Dto;
using PDE.Models.Entities;
using PDE.Models.Interfaces;

namespace PDE.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MiembrosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MiembrosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Miembros
        [HttpGet]
        public async Task<IEnumerable<MiembroDto>> GetMiembros()
        {
            return await _unitOfWork.Miembros.GetMiembros().ToListAsync();
        }

        [HttpGet("GetProvincias")]
        public async Task<IEnumerable<ProvinciaDto>> GetProvincias()
        {
            var provincias = await _unitOfWork.Provincia.GetAll();
            return _mapper.Map<IEnumerable<ProvinciaDto>>(provincias);
        }

        [HttpGet("GetMiembrosBySupervisor/{supervisorId}")]
        public async Task<IEnumerable<MiembroDto>> GetMiembros(int supervisorId)
        {
            var data = await _unitOfWork.Miembros.GetMiembrosBySupervisor(supervisorId).ToListAsync();
            return data;
        }

        [HttpGet("GetSupervisorByCargo/{CargoId}/{LocalidadId}")]
        public async Task<IEnumerable<MiembroDto>> GetSupervisorByCargo(int CargoId, int LocalidadId)
        {
            var data = await _unitOfWork.Miembros.GetSupervisorByCargo(CargoId, LocalidadId);
            return data;
        }

        // GET: api/Miembros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiembroDto>> GetMiembro(int id)
        {
            var miembro = await _unitOfWork.Miembros.GetMiembros().FirstOrDefaultAsync(a => a.Id == id);

            if (miembro == null)
            {
                return NotFound();
            }

            return miembro;
        }

        // GET: api/Miembros/5
        [HttpGet("GetMiembroByCedula/{cedula}")]
        public async Task<ActionResult<MiembroDto>> GetMiembro(string cedula)
        {
            var miembro = await _unitOfWork.Miembros.GetMiembroByCedula(cedula);

            if (miembro == null)
            {
                return NotFound();
            }

            return miembro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiembro(int id, MiembroDto miembro)
        {
            if (id != miembro.Id)
            {
                return BadRequest();
            }
            var data = _mapper.Map<Miembro>(miembro);
            _unitOfWork.Miembros.Update(data);
            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MiembroExists(id))
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


        [HttpPost]
        public async Task<ActionResult<MiembroDto>> PostMiembro(MiembroDto miembro)
        {
            try
            {
                var data = _mapper.Map<Miembro>(miembro);
                await _unitOfWork.Miembros.Add(data);
                await _unitOfWork.Save();
                var nuevoMiembro = _mapper.Map<MiembroDto>(data);
                return CreatedAtAction("GetMiembro", new { id = nuevoMiembro.Id }, nuevoMiembro);
            }
            catch (Exception ex)
            {

                throw;
            }

           
        }

        // DELETE: api/Miembros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiembro(int id)
        {
            var miembro = await _unitOfWork.Miembros.GetById(id);
            if (miembro == null)
            {
                return NotFound();
            }

            _unitOfWork.Miembros.Remove(miembro);
            await _unitOfWork.Save();

            return NoContent();
        }

        private async Task<bool> MiembroExists(int id)
        {
            return (await _unitOfWork.Miembros.GetAll()).Any(e => e.Id == id);
        }
    }
}
