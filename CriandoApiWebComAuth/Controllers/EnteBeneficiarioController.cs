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
    public class EnteBeneficiarioController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public EnteBeneficiarioController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/EnteBeneficiario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnteBeneficiario>>> GetEnteBeneficiarios()
        {
          if (_context.EnteBeneficiarios == null)
          {
              return NotFound();
          }
            return await _context.EnteBeneficiarios.ToListAsync();
        }

        // GET: api/EnteBeneficiario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnteBeneficiario>> GetEnteBeneficiario(int id)
        {
          if (_context.EnteBeneficiarios == null)
          {
              return NotFound();
          }
            var enteBeneficiario = await _context.EnteBeneficiarios.FindAsync(id);

            if (enteBeneficiario == null)
            {
                return NotFound();
            }

            return enteBeneficiario;
        }

        // PUT: api/EnteBeneficiario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnteBeneficiario(int id, EnteBeneficiario enteBeneficiario)
        {
            if (id != enteBeneficiario.IdEnteBeneficiario)
            {
                return BadRequest();
            }

            _context.Entry(enteBeneficiario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnteBeneficiarioExists(id))
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

        // POST: api/EnteBeneficiario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnteBeneficiario>> PostEnteBeneficiario(EnteBeneficiario enteBeneficiario)
        {
          if (_context.EnteBeneficiarios == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.EnteBeneficiarios'  is null.");
          }
            _context.EnteBeneficiarios.Add(enteBeneficiario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnteBeneficiario", new { id = enteBeneficiario.IdEnteBeneficiario }, enteBeneficiario);
        }

        // DELETE: api/EnteBeneficiario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnteBeneficiario(int id)
        {
            if (_context.EnteBeneficiarios == null)
            {
                return NotFound();
            }
            var enteBeneficiario = await _context.EnteBeneficiarios.FindAsync(id);
            if (enteBeneficiario == null)
            {
                return NotFound();
            }

            _context.EnteBeneficiarios.Remove(enteBeneficiario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnteBeneficiarioExists(int id)
        {
            return (_context.EnteBeneficiarios?.Any(e => e.IdEnteBeneficiario == id)).GetValueOrDefault();
        }
    }
}
