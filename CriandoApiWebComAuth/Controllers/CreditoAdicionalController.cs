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
    public class CreditoAdicionalController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public CreditoAdicionalController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/CreditoAdicional
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditoAdicional>>> GetCreditoAdicionals()
        {
          if (_context.CreditoAdicionals == null)
          {
              return NotFound();
          }
            return await _context.CreditoAdicionals.ToListAsync();
        }

        // GET: api/CreditoAdicional/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditoAdicional>> GetCreditoAdicional(int id)
        {
          if (_context.CreditoAdicionals == null)
          {
              return NotFound();
          }
            var creditoAdicional = await _context.CreditoAdicionals.FindAsync(id);

            if (creditoAdicional == null)
            {
                return NotFound();
            }

            return creditoAdicional;
        }

        // PUT: api/CreditoAdicional/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditoAdicional(int id, CreditoAdicional creditoAdicional)
        {
            if (id != creditoAdicional.IdCreditoAdicional)
            {
                return BadRequest();
            }

            _context.Entry(creditoAdicional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditoAdicionalExists(id))
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

        // POST: api/CreditoAdicional
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreditoAdicional>> PostCreditoAdicional(CreditoAdicional creditoAdicional)
        {
          if (_context.CreditoAdicionals == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.CreditoAdicionals'  is null.");
          }
            _context.CreditoAdicionals.Add(creditoAdicional);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreditoAdicional", new { id = creditoAdicional.IdCreditoAdicional }, creditoAdicional);
        }

        // DELETE: api/CreditoAdicional/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditoAdicional(int id)
        {
            if (_context.CreditoAdicionals == null)
            {
                return NotFound();
            }
            var creditoAdicional = await _context.CreditoAdicionals.FindAsync(id);
            if (creditoAdicional == null)
            {
                return NotFound();
            }

            _context.CreditoAdicionals.Remove(creditoAdicional);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreditoAdicionalExists(int id)
        {
            return (_context.CreditoAdicionals?.Any(e => e.IdCreditoAdicional == id)).GetValueOrDefault();
        }
    }
}
