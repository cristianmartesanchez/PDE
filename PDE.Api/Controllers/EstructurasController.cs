using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public EstructurasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Estructuras
        [HttpGet]
        public async Task<IEnumerable<Estructura>> GetEstructuras()
        {
            return await _unitOfWork.Estructura.GetAll();
        }

        // GET: api/Estructuras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estructura>> GetEstructura(int id)
        {
            var estructura = await _unitOfWork.Estructura.GetById(id);

            if (estructura == null)
            {
                return NotFound();
            }

            return estructura;
        }

        // PUT: api/Estructuras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstructura(int id, Estructura estructura)
        {
            if (id != estructura.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Estructura.Update(estructura);

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
        public async Task<ActionResult<Estructura>> PostEstructura(Estructura estructura)
        {
            await _unitOfWork.Estructura.Add(estructura);
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
