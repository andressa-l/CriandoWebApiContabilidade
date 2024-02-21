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
    public class CreditosAdicionaisController : ControllerBase
    {
        private readonly db_contabilidade_3tecnosContext _context;

        public CreditosAdicionaisController(db_contabilidade_3tecnosContext context)
        {
            _context = context;
        }

        // GET: api/CreditosAdicionais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditosAdicionai>>> GetCreditosAdicionais()
        {
          if (_context.CreditosAdicionais == null)
          {
              return NotFound();
          }
            return await _context.CreditosAdicionais.ToListAsync();
        }

        // GET: api/CreditosAdicionais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditosAdicionai>> GetCreditosAdicionai(int id)
        {
          if (_context.CreditosAdicionais == null)
          {
              return NotFound();
          }
            var creditosAdicionai = await _context.CreditosAdicionais.FindAsync(id);

            if (creditosAdicionai == null)
            {
                return NotFound();
            }

            return creditosAdicionai;
        }

        // PUT: api/CreditosAdicionais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditosAdicionai(int id, CreditosAdicionai creditosAdicionai)
        {
            if (id != creditosAdicionai.IdCreditosAdicionais)
            {
                return BadRequest();
            }

            _context.Entry(creditosAdicionai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditosAdicionaiExists(id))
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

        // POST: api/CreditosAdicionais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreditosAdicionai>> PostCreditosAdicionai(CreditosAdicionai creditosAdicionai)
        {
          if (_context.CreditosAdicionais == null)
          {
              return Problem("Entity set 'db_contabilidade_3tecnosContext.CreditosAdicionais'  is null.");
          }
            _context.CreditosAdicionais.Add(creditosAdicionai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreditosAdicionai", new { id = creditosAdicionai.IdCreditosAdicionais }, creditosAdicionai);
        }

        // DELETE: api/CreditosAdicionais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditosAdicionai(int id)
        {
            if (_context.CreditosAdicionais == null)
            {
                return NotFound();
            }
            var creditosAdicionai = await _context.CreditosAdicionais.FindAsync(id);
            if (creditosAdicionai == null)
            {
                return NotFound();
            }

            _context.CreditosAdicionais.Remove(creditosAdicionai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreditosAdicionaiExists(int id)
        {
            return (_context.CreditosAdicionais?.Any(e => e.IdCreditosAdicionais == id)).GetValueOrDefault();
        }
    }
}
