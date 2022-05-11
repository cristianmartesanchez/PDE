#nullable disable
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
using PDE.Persistence;

namespace PDE.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CargosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Cargos
        [HttpGet]
        public async Task<IEnumerable<Cargo>> GetCargos()
        {
            return await _unitOfWork.Cargo.GetAll();
        }


        [HttpGet("GetCargosByEstructura/{estructuraId}")]
        public async Task<IEnumerable<Cargo>> GetCargosByEstructura(int estructuraId)
        {
            var data = (await _unitOfWork.Cargo.GetCargosByEstructura(estructuraId)).DistinctBy(a => a.Id);
            return data;
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
            var cargo = await _unitOfWork.Cargo.GetById(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        // PUT: api/Cargos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo(int id, Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Cargo.Update(cargo);

            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CargoExists(id))
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

        // POST: api/Cargos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cargo>> PostCargo(Cargo cargo)
        {
            await _unitOfWork.Cargo.Add(cargo);
            await _unitOfWork.Save();

            return CreatedAtAction("GetCargo", new { id = cargo.Id }, cargo);
        }

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var cargo = await _unitOfWork.Cargo.GetById(id);
            if (cargo == null)
            {
                return NotFound();
            }

            _unitOfWork.Cargo.Remove(cargo);
            await _unitOfWork.Save();

            return NoContent();
        }

        private async Task<bool> CargoExists(int id)
        {
            return (await _unitOfWork.Cargo.GetAll()).Any(e => e.Id == id);
        }
    }
}
