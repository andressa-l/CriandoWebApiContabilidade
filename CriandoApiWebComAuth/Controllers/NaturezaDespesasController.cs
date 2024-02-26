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
    public class NaturezaDespesasController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public NaturezaDespesasController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/NaturezaDespesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NaturezaDespesa>>> GetNaturezaDespesas()
        {
          if (_context.NaturezaDespesas == null)
          {
              return NotFound();
          }
            return await _context.NaturezaDespesas.ToListAsync();
        }

        // GET: api/NaturezaDespesas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NaturezaDespesa>> GetNaturezaDespesa(int id)
        {
          if (_context.NaturezaDespesas == null)
          {
              return NotFound();
          }
            var naturezaDespesa = await _context.NaturezaDespesas.FindAsync(id);

            if (naturezaDespesa == null)
            {
                return NotFound();
            }

            return naturezaDespesa;
        }

        // PUT: api/NaturezaDespesas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNaturezaDespesa(int id, NaturezaDespesa naturezaDespesa)
        {
            if (id != naturezaDespesa.IdNaturezaDespesa)
            {
                return BadRequest();
            }

            _context.Entry(naturezaDespesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaturezaDespesaExists(id))
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

        // POST: api/NaturezaDespesas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NaturezaDespesa>> PostNaturezaDespesa(NaturezaDespesa naturezaDespesa)
        {
          if (_context.NaturezaDespesas == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.NaturezaDespesas'  is null.");
          }
            _context.NaturezaDespesas.Add(naturezaDespesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNaturezaDespesa", new { id = naturezaDespesa.IdNaturezaDespesa }, naturezaDespesa);
        }

        // DELETE: api/NaturezaDespesas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNaturezaDespesa(int id)
        {
            if (_context.NaturezaDespesas == null)
            {
                return NotFound();
            }
            var naturezaDespesa = await _context.NaturezaDespesas.FindAsync(id);
            if (naturezaDespesa == null)
            {
                return NotFound();
            }

            _context.NaturezaDespesas.Remove(naturezaDespesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NaturezaDespesaExists(int id)
        {
            return (_context.NaturezaDespesas?.Any(e => e.IdNaturezaDespesa == id)).GetValueOrDefault();
        }
    }
}
