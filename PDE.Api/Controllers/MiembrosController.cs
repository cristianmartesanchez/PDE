using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDE.DataAccess;
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

        public MiembrosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Miembros
        [HttpGet]
        public async Task<IEnumerable<Miembro>> GetMiembros()
        {
            return await _unitOfWork.Miembros.GetMiembros().ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("GetProvincias")]
        public async Task<IEnumerable<Provincia>> GetProvincias()
        {
            return await _unitOfWork.Provincia.GetAll();
        }

        [HttpGet("GetMiembrosBySupervisor/{supervisorId}")]
        public async Task<IEnumerable<Miembro>> GetMiembros(int supervisorId)
        {
            var data = await _unitOfWork.Miembros.GetMiembrosBySupervisor(supervisorId).ToListAsync();
            return data;
        }

        [HttpGet("GetSupervisorByCargo/{CargoId}/{LocalidadId}")]
        public async Task<IEnumerable<Miembro>> GetSupervisorByCargo(int CargoId, int LocalidadId)
        {
            var data = await _unitOfWork.Miembros.GetSupervisorByCargo(CargoId, LocalidadId);
            return data;
        }

        // GET: api/Miembros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Miembro>> GetMiembro(int id)
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
        public async Task<ActionResult<Miembro>> GetMiembro(string cedula)
        {
            var miembro = await _unitOfWork.Miembros.GetMiembroByCedula(cedula);

            if (miembro == null)
            {
                return NotFound();
            }

            return miembro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiembro(int id, Miembro miembro)
        {
            if (id != miembro.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Miembros.Update(miembro);
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
        public async Task<ActionResult<Miembro>> PostMiembro(Miembro miembro)
        {
            await _unitOfWork.Miembros.Add(miembro);
            await _unitOfWork.Save();

            return CreatedAtAction("GetMiembro", new { id = miembro.Id }, miembro);
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
