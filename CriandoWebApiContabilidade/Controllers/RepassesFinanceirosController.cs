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
    public class RepassesFinanceirosController : ControllerBase
    {
        private readonly db_contabilidade_3tecnosContext _context;

        public RepassesFinanceirosController(db_contabilidade_3tecnosContext context)
        {
            _context = context;
        }

        // GET: api/RepassesFinanceiros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepassesFinanceiro>>> GetRepassesFinanceiros()
        {
          if (_context.RepassesFinanceiros == null)
          {
              return NotFound();
          }
            return await _context.RepassesFinanceiros.ToListAsync();
        }

        // GET: api/RepassesFinanceiros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepassesFinanceiro>> GetRepassesFinanceiro(int id)
        {
          if (_context.RepassesFinanceiros == null)
          {
              return NotFound();
          }
            var repassesFinanceiro = await _context.RepassesFinanceiros.FindAsync(id);

            if (repassesFinanceiro == null)
            {
                return NotFound();
            }

            return repassesFinanceiro;
        }

        // PUT: api/RepassesFinanceiros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepassesFinanceiro(int id, RepassesFinanceiro repassesFinanceiro)
        {
            if (id != repassesFinanceiro.IdRepasses)
            {
                return BadRequest();
            }

            _context.Entry(repassesFinanceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepassesFinanceiroExists(id))
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

        // POST: api/RepassesFinanceiros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RepassesFinanceiro>> PostRepassesFinanceiro(RepassesFinanceiro repassesFinanceiro)
        {
          if (_context.RepassesFinanceiros == null)
          {
              return Problem("Entity set 'db_contabilidade_3tecnosContext.RepassesFinanceiros'  is null.");
          }
            _context.RepassesFinanceiros.Add(repassesFinanceiro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepassesFinanceiroExists(repassesFinanceiro.IdRepasses))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRepassesFinanceiro", new { id = repassesFinanceiro.IdRepasses }, repassesFinanceiro);
        }

        // DELETE: api/RepassesFinanceiros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepassesFinanceiro(int id)
        {
            if (_context.RepassesFinanceiros == null)
            {
                return NotFound();
            }
            var repassesFinanceiro = await _context.RepassesFinanceiros.FindAsync(id);
            if (repassesFinanceiro == null)
            {
                return NotFound();
            }

            _context.RepassesFinanceiros.Remove(repassesFinanceiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepassesFinanceiroExists(int id)
        {
            return (_context.RepassesFinanceiros?.Any(e => e.IdRepasses == id)).GetValueOrDefault();
        }
    }
}
