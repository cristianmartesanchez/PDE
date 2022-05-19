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
    public class CargosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CargosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: api/Cargos
        [HttpGet]
        public async Task<IEnumerable<CargoDto>> GetCargos()
        {
            return _mapper.Map<IEnumerable<CargoDto>>(await _unitOfWork.Cargo.GetAll());
        }


        [HttpGet("GetCargosByEstructura/{estructuraId}")]
        public async Task<IEnumerable<CargoDto>> GetCargosByEstructura(int estructuraId)
        {
            var data = (await _unitOfWork.Cargo.GetCargosByEstructura(estructuraId)).DistinctBy(a => a.Id);
            return _mapper.Map<IEnumerable<CargoDto>>(data);
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CargoDto>> GetCargo(int id)
        {
            var cargo = await _unitOfWork.Cargo.GetById(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return _mapper.Map<CargoDto>(cargo);
        }

        // PUT: api/Cargos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo(int id, CargoDto cargo)
        {
            if (id != cargo.Id)
            {
                return BadRequest();
            }
            var data = _mapper.Map<Cargo>(cargo);
            _unitOfWork.Cargo.Update(data);

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
        public async Task<ActionResult<CargoDto>> PostCargo(CargoDto cargo)
        {
            var data = _mapper.Map<Cargo>(cargo);
            await _unitOfWork.Cargo.Add(data);
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
