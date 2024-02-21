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
    public class EntesController : ControllerBase
    {
        private readonly db_contabilidade_3tecnosContext _context;

        public EntesController(db_contabilidade_3tecnosContext context)
        {
            _context = context;
        }

        // GET: api/Entes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ente>>> GetEntes()
        {
          if (_context.Entes == null)
          {
              return NotFound();
          }
            return await _context.Entes.ToListAsync();
        }

        // GET: api/Entes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ente>> GetEnte(int id)
        {
          if (_context.Entes == null)
          {
              return NotFound();
          }
            var ente = await _context.Entes.FindAsync(id);

            if (ente == null)
            {
                return NotFound();
            }

            return ente;
        }

        // PUT: api/Entes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnte(int id, Ente ente)
        {
            if (id != ente.EnteId)
            {
                return BadRequest();
            }

            _context.Entry(ente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnteExists(id))
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

        // POST: api/Entes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ente>> PostEnte(Ente ente)
        {
          if (_context.Entes == null)
          {
              return Problem("Entity set 'db_contabilidade_3tecnosContext.Entes'  is null.");
          }
            _context.Entes.Add(ente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnte", new { id = ente.EnteId }, ente);
        }

        // DELETE: api/Entes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnte(int id)
        {
            if (_context.Entes == null)
            {
                return NotFound();
            }
            var ente = await _context.Entes.FindAsync(id);
            if (ente == null)
            {
                return NotFound();
            }

            _context.Entes.Remove(ente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnteExists(int id)
        {
            return (_context.Entes?.Any(e => e.EnteId == id)).GetValueOrDefault();
        }
    }
}
