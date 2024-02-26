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
    public class OrigemRepassesController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public OrigemRepassesController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/OrigemRepasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrigemRepasse>>> GetOrigemRepasses()
        {
          if (_context.OrigemRepasses == null)
          {
              return NotFound();
          }
            return await _context.OrigemRepasses.ToListAsync();
        }

        // GET: api/OrigemRepasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrigemRepasse>> GetOrigemRepasse(int id)
        {
          if (_context.OrigemRepasses == null)
          {
              return NotFound();
          }
            var origemRepasse = await _context.OrigemRepasses.FindAsync(id);

            if (origemRepasse == null)
            {
                return NotFound();
            }

            return origemRepasse;
        }

        // PUT: api/OrigemRepasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrigemRepasse(int id, OrigemRepasse origemRepasse)
        {
            if (id != origemRepasse.IdOrigemRepasse)
            {
                return BadRequest();
            }

            _context.Entry(origemRepasse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrigemRepasseExists(id))
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

        // POST: api/OrigemRepasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrigemRepasse>> PostOrigemRepasse(OrigemRepasse origemRepasse)
        {
          if (_context.OrigemRepasses == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.OrigemRepasses'  is null.");
          }
            _context.OrigemRepasses.Add(origemRepasse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrigemRepasse", new { id = origemRepasse.IdOrigemRepasse }, origemRepasse);
        }

        // DELETE: api/OrigemRepasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrigemRepasse(int id)
        {
            if (_context.OrigemRepasses == null)
            {
                return NotFound();
            }
            var origemRepasse = await _context.OrigemRepasses.FindAsync(id);
            if (origemRepasse == null)
            {
                return NotFound();
            }

            _context.OrigemRepasses.Remove(origemRepasse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrigemRepasseExists(int id)
        {
            return (_context.OrigemRepasses?.Any(e => e.IdOrigemRepasse == id)).GetValueOrDefault();
        }
    }
}
