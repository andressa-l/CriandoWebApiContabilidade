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
    public class DestinoRepassesController : ControllerBase
    {
        private readonly db_contabilidade_3tecnosContext _context;

        public DestinoRepassesController(db_contabilidade_3tecnosContext context)
        {
            _context = context;
        }

        // GET: api/DestinoRepasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DestinoRepasse>>> GetDestinoRepasses()
        {
          if (_context.DestinoRepasses == null)
          {
              return NotFound();
          }
            return await _context.DestinoRepasses.ToListAsync();
        }

        // GET: api/DestinoRepasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DestinoRepasse>> GetDestinoRepasse(int id)
        {
          if (_context.DestinoRepasses == null)
          {
              return NotFound();
          }
            var destinoRepasse = await _context.DestinoRepasses.FindAsync(id);

            if (destinoRepasse == null)
            {
                return NotFound();
            }

            return destinoRepasse;
        }

        // PUT: api/DestinoRepasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestinoRepasse(int id, DestinoRepasse destinoRepasse)
        {
            if (id != destinoRepasse.IdDestino)
            {
                return BadRequest();
            }

            _context.Entry(destinoRepasse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinoRepasseExists(id))
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

        // POST: api/DestinoRepasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DestinoRepasse>> PostDestinoRepasse(DestinoRepasse destinoRepasse)
        {
          if (_context.DestinoRepasses == null)
          {
              return Problem("Entity set 'db_contabilidade_3tecnosContext.DestinoRepasses'  is null.");
          }
            _context.DestinoRepasses.Add(destinoRepasse);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DestinoRepasseExists(destinoRepasse.IdDestino))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDestinoRepasse", new { id = destinoRepasse.IdDestino }, destinoRepasse);
        }

        // DELETE: api/DestinoRepasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestinoRepasse(int id)
        {
            if (_context.DestinoRepasses == null)
            {
                return NotFound();
            }
            var destinoRepasse = await _context.DestinoRepasses.FindAsync(id);
            if (destinoRepasse == null)
            {
                return NotFound();
            }

            _context.DestinoRepasses.Remove(destinoRepasse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DestinoRepasseExists(int id)
        {
            return (_context.DestinoRepasses?.Any(e => e.IdDestino == id)).GetValueOrDefault();
        }
    }
}
