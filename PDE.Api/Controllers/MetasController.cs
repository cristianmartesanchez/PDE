using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDE.Models.Dto;
using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MetasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Metas
        [HttpGet]
        public async Task<IEnumerable<MetasDto>> GetMetas()
        {
            var metas = await _unitOfWork.Metas.GetAll();
            return _mapper.Map<IEnumerable<MetasDto>>(metas);
        }

        // GET: api/Metas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetasDto>> GetMetas(int id)
        {
            var meta = await _unitOfWork.Metas.GetById(id);

            if (meta == null)
            {
                return NotFound();
            }

            return _mapper.Map<MetasDto>(meta);
        }

        // PUT: api/Metas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetas(int id, MetasDto meta)
        {
            if (id != meta.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Metas.Update(_mapper.Map<Metas>(meta));

            try
            {
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetasExists(id))
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

        // POST: api/Metas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetasDto>> PostMetas(MetasDto meta)
        {
            await _unitOfWork.Metas.Add(_mapper.Map<Metas>(meta));
            await _unitOfWork.Save();

            return CreatedAtAction("GetMetas", new { id = meta.Id }, meta);
        }

        // DELETE: api/Metas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetas(int id)
        {
            var metas = await _unitOfWork.Metas.GetById(id);
            if (metas == null)
            {
                return NotFound();
            }

            _unitOfWork.Metas.Remove(metas);
            await _unitOfWork.Save();

            return NoContent();
        }

        private bool MetasExists(int id)
        {
            return _unitOfWork.Metas.GetById(id) != null;
        }
    }
}
