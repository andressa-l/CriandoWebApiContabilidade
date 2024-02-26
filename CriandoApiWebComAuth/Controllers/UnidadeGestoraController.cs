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
    public class UnidadeGestoraController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public UnidadeGestoraController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/UnidadeGestora
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeGestora>>> GetUnidadeGestoras()
        {
          if (_context.UnidadeGestoras == null)
          {
              return NotFound();
          }
            return await _context.UnidadeGestoras.ToListAsync();
        }

        // GET: api/UnidadeGestora/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeGestora>> GetUnidadeGestora(int id)
        {
          if (_context.UnidadeGestoras == null)
          {
              return NotFound();
          }
            var unidadeGestora = await _context.UnidadeGestoras.FindAsync(id);

            if (unidadeGestora == null)
            {
                return NotFound();
            }

            return unidadeGestora;
        }

        // PUT: api/UnidadeGestora/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadeGestora(int id, UnidadeGestora unidadeGestora)
        {
            if (id != unidadeGestora.IdUnidadeGestora)
            {
                return BadRequest();
            }

            _context.Entry(unidadeGestora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadeGestoraExists(id))
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

        // POST: api/UnidadeGestora
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnidadeGestora>> PostUnidadeGestora(UnidadeGestora unidadeGestora)
        {
          if (_context.UnidadeGestoras == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.UnidadeGestoras'  is null.");
          }
            _context.UnidadeGestoras.Add(unidadeGestora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadeGestora", new { id = unidadeGestora.IdUnidadeGestora }, unidadeGestora);
        }

        // DELETE: api/UnidadeGestora/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadeGestora(int id)
        {
            if (_context.UnidadeGestoras == null)
            {
                return NotFound();
            }
            var unidadeGestora = await _context.UnidadeGestoras.FindAsync(id);
            if (unidadeGestora == null)
            {
                return NotFound();
            }

            _context.UnidadeGestoras.Remove(unidadeGestora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadeGestoraExists(int id)
        {
            return (_context.UnidadeGestoras?.Any(e => e.IdUnidadeGestora == id)).GetValueOrDefault();
        }
    }
}
