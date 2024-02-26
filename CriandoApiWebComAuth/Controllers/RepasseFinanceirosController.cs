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
    public class RepasseFinanceirosController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public RepasseFinanceirosController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/RepasseFinanceiros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepasseFinanceiro>>> GetRepasseFinanceiros()
        {
          if (_context.RepasseFinanceiros == null)
          {
              return NotFound();
          }
            return await _context.RepasseFinanceiros.ToListAsync();
        }

        // GET: api/RepasseFinanceiros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepasseFinanceiro>> GetRepasseFinanceiro(int id)
        {
          if (_context.RepasseFinanceiros == null)
          {
              return NotFound();
          }
            var repasseFinanceiro = await _context.RepasseFinanceiros.FindAsync(id);

            if (repasseFinanceiro == null)
            {
                return NotFound();
            }

            return repasseFinanceiro;
        }

        // PUT: api/RepasseFinanceiros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepasseFinanceiro(int id, RepasseFinanceiro repasseFinanceiro)
        {
            if (id != repasseFinanceiro.IdRepasseFinanceiro)
            {
                return BadRequest();
            }

            _context.Entry(repasseFinanceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepasseFinanceiroExists(id))
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

        // POST: api/RepasseFinanceiros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RepasseFinanceiro>> PostRepasseFinanceiro(RepasseFinanceiro repasseFinanceiro)
        {
          if (_context.RepasseFinanceiros == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.RepasseFinanceiros'  is null.");
          }
            _context.RepasseFinanceiros.Add(repasseFinanceiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepasseFinanceiro", new { id = repasseFinanceiro.IdRepasseFinanceiro }, repasseFinanceiro);
        }

        // DELETE: api/RepasseFinanceiros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepasseFinanceiro(int id)
        {
            if (_context.RepasseFinanceiros == null)
            {
                return NotFound();
            }
            var repasseFinanceiro = await _context.RepasseFinanceiros.FindAsync(id);
            if (repasseFinanceiro == null)
            {
                return NotFound();
            }

            _context.RepasseFinanceiros.Remove(repasseFinanceiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepasseFinanceiroExists(int id)
        {
            return (_context.RepasseFinanceiros?.Any(e => e.IdRepasseFinanceiro == id)).GetValueOrDefault();
        }
    }
}
