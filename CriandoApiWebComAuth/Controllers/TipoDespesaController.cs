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
    public class TipoDespesaController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public TipoDespesaController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/TipoDespesa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDespesa>>> GetTipoDespesas()
        {
          if (_context.TipoDespesas == null)
          {
              return NotFound();
          }
            return await _context.TipoDespesas.ToListAsync();
        }

        // GET: api/TipoDespesa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDespesa>> GetTipoDespesa(int id)
        {
          if (_context.TipoDespesas == null)
          {
              return NotFound();
          }
            var tipoDespesa = await _context.TipoDespesas.FindAsync(id);

            if (tipoDespesa == null)
            {
                return NotFound();
            }

            return tipoDespesa;
        }

        // PUT: api/TipoDespesa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDespesa(int id, TipoDespesa tipoDespesa)
        {
            if (id != tipoDespesa.IdTipoDespesa)
            {
                return BadRequest();
            }

            _context.Entry(tipoDespesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDespesaExists(id))
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

        // POST: api/TipoDespesa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDespesa>> PostTipoDespesa(TipoDespesa tipoDespesa)
        {
          if (_context.TipoDespesas == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.TipoDespesas'  is null.");
          }
            _context.TipoDespesas.Add(tipoDespesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDespesa", new { id = tipoDespesa.IdTipoDespesa }, tipoDespesa);
        }

        // DELETE: api/TipoDespesa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDespesa(int id)
        {
            if (_context.TipoDespesas == null)
            {
                return NotFound();
            }
            var tipoDespesa = await _context.TipoDespesas.FindAsync(id);
            if (tipoDespesa == null)
            {
                return NotFound();
            }

            _context.TipoDespesas.Remove(tipoDespesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDespesaExists(int id)
        {
            return (_context.TipoDespesas?.Any(e => e.IdTipoDespesa == id)).GetValueOrDefault();
        }
    }
}
