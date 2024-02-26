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
    public class DestinoRepassesController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public DestinoRepassesController(ContabilidadeFinancas_dbContext context)
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
            if (id != destinoRepasse.IdDestinoRepasse)
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
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.DestinoRepasses'  is null.");
          }
            _context.DestinoRepasses.Add(destinoRepasse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDestinoRepasse", new { id = destinoRepasse.IdDestinoRepasse }, destinoRepasse);
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
            return (_context.DestinoRepasses?.Any(e => e.IdDestinoRepasse == id)).GetValueOrDefault();
        }
    }
}
