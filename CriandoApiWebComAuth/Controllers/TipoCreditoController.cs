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
    public class TipoCreditoController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public TipoCreditoController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/TipoCredito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCredito>>> GetTipoCreditos()
        {
          if (_context.TipoCreditos == null)
          {
              return NotFound();
          }
            return await _context.TipoCreditos.ToListAsync();
        }

        // GET: api/TipoCredito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCredito>> GetTipoCredito(int id)
        {
          if (_context.TipoCreditos == null)
          {
              return NotFound();
          }
            var tipoCredito = await _context.TipoCreditos.FindAsync(id);

            if (tipoCredito == null)
            {
                return NotFound();
            }

            return tipoCredito;
        }

        // PUT: api/TipoCredito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCredito(int id, TipoCredito tipoCredito)
        {
            if (id != tipoCredito.IdTipoCredito)
            {
                return BadRequest();
            }

            _context.Entry(tipoCredito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCreditoExists(id))
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

        // POST: api/TipoCredito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoCredito>> PostTipoCredito(TipoCredito tipoCredito)
        {
          if (_context.TipoCreditos == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.TipoCreditos'  is null.");
          }
            _context.TipoCreditos.Add(tipoCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCredito", new { id = tipoCredito.IdTipoCredito }, tipoCredito);
        }

        // DELETE: api/TipoCredito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoCredito(int id)
        {
            if (_context.TipoCreditos == null)
            {
                return NotFound();
            }
            var tipoCredito = await _context.TipoCreditos.FindAsync(id);
            if (tipoCredito == null)
            {
                return NotFound();
            }

            _context.TipoCreditos.Remove(tipoCredito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoCreditoExists(int id)
        {
            return (_context.TipoCreditos?.Any(e => e.IdTipoCredito == id)).GetValueOrDefault();
        }
    }
}
