using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CriandoApiWebComAuth.Models;
using CriandoApiWebComAuth.Context;

namespace CriandoApiWebComAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaEconomicaController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public CategoriaEconomicaController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaEconomica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaEconomica>>> GetCategoriaEconomicas()
        {
            if (_context.CategoriaEconomicas == null)
            {
                return NotFound();
            }
            return await _context.CategoriaEconomicas.ToListAsync();
        }

        // GET: api/CategoriaEconomica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEconomica>> GetCategoriaEconomica(int id)
        {
            if (_context.CategoriaEconomicas == null)
            {
                return NotFound();
            }
            var categoriaEconomica = await _context.CategoriaEconomicas.FindAsync(id);

            if (categoriaEconomica == null)
            {
                return NotFound();
            }

            return categoriaEconomica;
        }

        // PUT: api/CategoriaEconomica/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaEconomica(int id, CategoriaEconomica categoriaEconomica)
        {
            if (id != categoriaEconomica.IdCategoriaEconomica)
            {
                return BadRequest();
            }

            _context.Entry(categoriaEconomica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaEconomicaExists(id))
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

        // POST: api/CategoriaEconomica
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaEconomica>> PostCategoriaEconomica(CategoriaEconomica categoriaEconomica)
        {
            if (_context.CategoriaEconomicas == null)
            {
                return Problem("Entity set 'ContabilidadeFinancas_dbContext.CategoriaEconomicas'  is null.");
            }
            _context.CategoriaEconomicas.Add(categoriaEconomica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaEconomica", new { id = categoriaEconomica.IdCategoriaEconomica }, categoriaEconomica);
        }

        // DELETE: api/CategoriaEconomica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaEconomica(int id)
        {
            if (_context.CategoriaEconomicas == null)
            {
                return NotFound();
            }
            var categoriaEconomica = await _context.CategoriaEconomicas.FindAsync(id);
            if (categoriaEconomica == null)
            {
                return NotFound();
            }

            _context.CategoriaEconomicas.Remove(categoriaEconomica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaEconomicaExists(int id)
        {
            return (_context.CategoriaEconomicas?.Any(e => e.IdCategoriaEconomica == id)).GetValueOrDefault();
        }
    }
}
