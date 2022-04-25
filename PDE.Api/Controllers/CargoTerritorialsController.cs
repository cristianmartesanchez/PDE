#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDE.DataAccess;
using PDE.Models.Entities;

namespace PDE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoTerritorialsController : ControllerBase
    {
        private readonly DBPDEContext _context;

        public CargoTerritorialsController(DBPDEContext context)
        {
            _context = context;
        }

        // GET: api/CargoTerritorials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CargoTerritorial>>> GetCargoTerritorials()
        {
            return await _context.CargoTerritorials.ToListAsync();
        }

        // GET: api/CargoTerritorials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CargoTerritorial>> GetCargoTerritorial(int id)
        {
            var cargoTerritorial = await _context.CargoTerritorials.FindAsync(id);

            if (cargoTerritorial == null)
            {
                return NotFound();
            }

            return cargoTerritorial;
        }

        // PUT: api/CargoTerritorials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargoTerritorial(int id, CargoTerritorial cargoTerritorial)
        {
            if (id != cargoTerritorial.Id)
            {
                return BadRequest();
            }

            _context.Entry(cargoTerritorial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoTerritorialExists(id))
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
            _context.CargoTerritorials.Add(cargoTerritorial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCargoTerritorial", new { id = cargoTerritorial.Id }, cargoTerritorial);
        }

        // DELETE: api/CargoTerritorials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoTerritorial(int id)
        {
            var cargoTerritorial = await _context.CargoTerritorials.FindAsync(id);
            if (cargoTerritorial == null)
            {
                return NotFound();
            }

            _context.CargoTerritorials.Remove(cargoTerritorial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargoTerritorialExists(int id)
        {
            return _context.CargoTerritorials.Any(e => e.Id == id);
        }
    }
}
