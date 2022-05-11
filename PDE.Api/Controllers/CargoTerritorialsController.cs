
using PDE.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDE.DataAccess;
using PDE.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PDE.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace PDE.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoTerritorialsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CargoTerritorialsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CargoTerritorials
        [HttpGet]
        public async Task<IEnumerable<CargoTerritorial>> GetCargosTerritoriales()
        {
            return await _unitOfWork.CargosTerritoriales.GetCargoTerritoriales().ToListAsync();
        }

        [HttpGet("GetCargosBySupervisor/{supervisorId}")]
        public async Task<IEnumerable<CargoTerritorial>> GetCargosBySupervisor(int supervisorId)
        {
            var cargosTerritoriales = await _unitOfWork.CargosTerritoriales.GetCargosBySupervisor(supervisorId).ToListAsync();
            return cargosTerritoriales;
        }

        [HttpGet("GetCargosByLocalidad/{localidadId}")]
        public async Task<IEnumerable<CargoTerritorial>> GetCargosByLocalidad(int localidadId)
        {
            var cargosTerritoriales = await _unitOfWork.CargosTerritoriales.GetCargosByLocalidad(localidadId);
            return cargosTerritoriales;
        }

        // GET: api/CargoTerritorials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CargoTerritorial>> GetCargoTerritorial(int id)
        {
            var cargoTerritorial = await _unitOfWork.CargosTerritoriales.GetById(id);

            if (cargoTerritorial == null)
            {
                return NotFound();
            }

            return cargoTerritorial;
        }

        // PUT: api/CargoTerritorials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargoTerritorial(CargoTerritorial cargoTerritorial)
        {

            _unitOfWork.CargosTerritoriales.Update(cargoTerritorial);
            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CargoTerritorialExists(cargoTerritorial.Id))
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

        // POST: api/CargoTerritorials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CargoTerritorial>> PostCargoTerritorial(CargoTerritorial cargoTerritorial)
        {
            await _unitOfWork.CargosTerritoriales.Add(cargoTerritorial);
            await _unitOfWork.Save();

            return CreatedAtAction("GetCargoTerritorial", new { id = cargoTerritorial.Id }, cargoTerritorial);
        }

        // DELETE: api/CargoTerritorials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoTerritorial(int id)
        {
            var cargoTerritorial = await _unitOfWork.CargosTerritoriales.GetById(id);
            if (cargoTerritorial == null)
            {
                return NotFound();
            }

            _unitOfWork.CargosTerritoriales.Remove(cargoTerritorial);
            await _unitOfWork.Save();

            return NoContent();
        }

        private async Task<bool> CargoTerritorialExists(int id)
        {
            return (await _unitOfWork.CargosTerritoriales.GetAll()).Any(e => e.Id == id);
        }
    }
}
