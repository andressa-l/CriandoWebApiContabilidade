using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CriandoWebApiContabilidade.Models;

namespace CriandoWebApiContabilidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DotacaoOrcamentariaController : ControllerBase
    {
        private readonly db_contabilidade_3tecnosContext _context;

        public DotacaoOrcamentariaController(db_contabilidade_3tecnosContext context)
        {
            _context = context;
        }

        // GET: api/DotacaoOrcamentaria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DotacaoOrcamentarium>>> GetDotacaoOrcamentaria()
        {
          if (_context.DotacaoOrcamentaria == null)
          {
              return NotFound();
          }
            return await _context.DotacaoOrcamentaria.ToListAsync();
        }

        // GET: api/DotacaoOrcamentaria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DotacaoOrcamentarium>> GetDotacaoOrcamentarium(int id)
        {
          if (_context.DotacaoOrcamentaria == null)
          {
              return NotFound();
          }
            var dotacaoOrcamentarium = await _context.DotacaoOrcamentaria.FindAsync(id);

            if (dotacaoOrcamentarium == null)
            {
                return NotFound();
            }

            return dotacaoOrcamentarium;
        }

        // PUT: api/DotacaoOrcamentaria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDotacaoOrcamentarium(int id, DotacaoOrcamentarium dotacaoOrcamentarium)
        {
            if (id != dotacaoOrcamentarium.IdDotacaoOrcamentaria)
            {
                return BadRequest();
            }

            _context.Entry(dotacaoOrcamentarium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DotacaoOrcamentariumExists(id))
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

        // POST: api/DotacaoOrcamentaria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DotacaoOrcamentarium>> PostDotacaoOrcamentarium(DotacaoOrcamentarium dotacaoOrcamentarium)
        {
          if (_context.DotacaoOrcamentaria == null)
          {
              return Problem("Entity set 'db_contabilidade_3tecnosContext.DotacaoOrcamentaria'  is null.");
          }
            _context.DotacaoOrcamentaria.Add(dotacaoOrcamentarium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDotacaoOrcamentarium", new { id = dotacaoOrcamentarium.IdDotacaoOrcamentaria }, dotacaoOrcamentarium);
        }

        // DELETE: api/DotacaoOrcamentaria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDotacaoOrcamentarium(int id)
        {
            if (_context.DotacaoOrcamentaria == null)
            {
                return NotFound();
            }
            var dotacaoOrcamentarium = await _context.DotacaoOrcamentaria.FindAsync(id);
            if (dotacaoOrcamentarium == null)
            {
                return NotFound();
            }

            _context.DotacaoOrcamentaria.Remove(dotacaoOrcamentarium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DotacaoOrcamentariumExists(int id)
        {
            return (_context.DotacaoOrcamentaria?.Any(e => e.IdDotacaoOrcamentaria == id)).GetValueOrDefault();
        }
    }
}
