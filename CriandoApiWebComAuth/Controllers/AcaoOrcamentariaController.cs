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
    public class AcaoOrcamentariaController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public AcaoOrcamentariaController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/AcaoOrcamentaria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcaoOrcamentarium>>> GetAcaoOrcamentaria()
        {
          if (_context.AcaoOrcamentaria == null)
          {
              return NotFound();
          }
            return await _context.AcaoOrcamentaria.ToListAsync();
        }

        // GET: api/AcaoOrcamentaria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcaoOrcamentarium>> GetAcaoOrcamentarium(int id)
        {
          if (_context.AcaoOrcamentaria == null)
          {
              return NotFound();
          }
            var acaoOrcamentarium = await _context.AcaoOrcamentaria.FindAsync(id);

            if (acaoOrcamentarium == null)
            {
                return NotFound();
            }

            return acaoOrcamentarium;
        }

        // PUT: api/AcaoOrcamentaria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcaoOrcamentarium(int id, AcaoOrcamentarium acaoOrcamentarium)
        {
            if (id != acaoOrcamentarium.IdAcaoOrcamentaria)
            {
                return BadRequest();
            }

            _context.Entry(acaoOrcamentarium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcaoOrcamentariumExists(id))
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

        // POST: api/AcaoOrcamentaria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcaoOrcamentarium>> PostAcaoOrcamentarium(AcaoOrcamentarium acaoOrcamentarium)
        {
          if (_context.AcaoOrcamentaria == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.AcaoOrcamentaria'  is null.");
          }
            _context.AcaoOrcamentaria.Add(acaoOrcamentarium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcaoOrcamentarium", new { id = acaoOrcamentarium.IdAcaoOrcamentaria }, acaoOrcamentarium);
        }

        // DELETE: api/AcaoOrcamentaria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcaoOrcamentarium(int id)
        {
            if (_context.AcaoOrcamentaria == null)
            {
                return NotFound();
            }
            var acaoOrcamentarium = await _context.AcaoOrcamentaria.FindAsync(id);
            if (acaoOrcamentarium == null)
            {
                return NotFound();
            }

            _context.AcaoOrcamentaria.Remove(acaoOrcamentarium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcaoOrcamentariumExists(int id)
        {
            return (_context.AcaoOrcamentaria?.Any(e => e.IdAcaoOrcamentaria == id)).GetValueOrDefault();
        }
    }
}
