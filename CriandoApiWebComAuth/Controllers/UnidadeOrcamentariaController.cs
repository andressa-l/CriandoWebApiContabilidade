using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CriandoApiWebComAuth.Context;
using CriandoApiWebComAuth.Models;

namespace CriandoApiWebComAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeOrcamentariaController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public UnidadeOrcamentariaController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/UnidadeOrcamentaria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeOrcamentarium>>> GetUnidadeOrcamentaria()
        {
          if (_context.UnidadeOrcamentaria == null)
          {
              return NotFound();
          }
            return await _context.UnidadeOrcamentaria.ToListAsync();
        }

        // GET: api/UnidadeOrcamentaria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeOrcamentarium>> GetUnidadeOrcamentarium(int id)
        {
          if (_context.UnidadeOrcamentaria == null)
          {
              return NotFound();
          }
            var unidadeOrcamentarium = await _context.UnidadeOrcamentaria.FindAsync(id);

            if (unidadeOrcamentarium == null)
            {
                return NotFound();
            }

            return unidadeOrcamentarium;
        }

        // PUT: api/UnidadeOrcamentaria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadeOrcamentarium(int id, UnidadeOrcamentarium unidadeOrcamentarium)
        {
            if (id != unidadeOrcamentarium.IdUnidadeOrcamentaria)
            {
                return BadRequest();
            }

            _context.Entry(unidadeOrcamentarium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadeOrcamentariumExists(id))
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

        // POST: api/UnidadeOrcamentaria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnidadeOrcamentarium>> PostUnidadeOrcamentarium(UnidadeOrcamentarium unidadeOrcamentarium)
        {
          if (_context.UnidadeOrcamentaria == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.UnidadeOrcamentaria'  is null.");
          }
            _context.UnidadeOrcamentaria.Add(unidadeOrcamentarium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadeOrcamentarium", new { id = unidadeOrcamentarium.IdUnidadeOrcamentaria }, unidadeOrcamentarium);
        }

        // DELETE: api/UnidadeOrcamentaria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadeOrcamentarium(int id)
        {
            if (_context.UnidadeOrcamentaria == null)
            {
                return NotFound();
            }
            var unidadeOrcamentarium = await _context.UnidadeOrcamentaria.FindAsync(id);
            if (unidadeOrcamentarium == null)
            {
                return NotFound();
            }

            _context.UnidadeOrcamentaria.Remove(unidadeOrcamentarium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadeOrcamentariumExists(int id)
        {
            return (_context.UnidadeOrcamentaria?.Any(e => e.IdUnidadeOrcamentaria == id)).GetValueOrDefault();
        }
    }
}
