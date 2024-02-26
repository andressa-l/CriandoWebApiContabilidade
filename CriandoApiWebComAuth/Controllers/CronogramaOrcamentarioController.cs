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
    public class CronogramaOrcamentarioController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public CronogramaOrcamentarioController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/CronogramaOrcamentario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CronogramaOrcamentario>>> GetCronogramaOrcamentarios()
        {
          if (_context.CronogramaOrcamentarios == null)
          {
              return NotFound();
          }
            return await _context.CronogramaOrcamentarios.ToListAsync();
        }

        // GET: api/CronogramaOrcamentario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CronogramaOrcamentario>> GetCronogramaOrcamentario(int id)
        {
          if (_context.CronogramaOrcamentarios == null)
          {
              return NotFound();
          }
            var cronogramaOrcamentario = await _context.CronogramaOrcamentarios.FindAsync(id);

            if (cronogramaOrcamentario == null)
            {
                return NotFound();
            }

            return cronogramaOrcamentario;
        }

        // PUT: api/CronogramaOrcamentario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCronogramaOrcamentario(int id, CronogramaOrcamentario cronogramaOrcamentario)
        {
            if (id != cronogramaOrcamentario.IdCronogramaOrcamentario)
            {
                return BadRequest();
            }

            _context.Entry(cronogramaOrcamentario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CronogramaOrcamentarioExists(id))
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

        // POST: api/CronogramaOrcamentario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CronogramaOrcamentario>> PostCronogramaOrcamentario(CronogramaOrcamentario cronogramaOrcamentario)
        {
          if (_context.CronogramaOrcamentarios == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.CronogramaOrcamentarios'  is null.");
          }
            _context.CronogramaOrcamentarios.Add(cronogramaOrcamentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCronogramaOrcamentario", new { id = cronogramaOrcamentario.IdCronogramaOrcamentario }, cronogramaOrcamentario);
        }

        // DELETE: api/CronogramaOrcamentario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCronogramaOrcamentario(int id)
        {
            if (_context.CronogramaOrcamentarios == null)
            {
                return NotFound();
            }
            var cronogramaOrcamentario = await _context.CronogramaOrcamentarios.FindAsync(id);
            if (cronogramaOrcamentario == null)
            {
                return NotFound();
            }

            _context.CronogramaOrcamentarios.Remove(cronogramaOrcamentario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CronogramaOrcamentarioExists(int id)
        {
            return (_context.CronogramaOrcamentarios?.Any(e => e.IdCronogramaOrcamentario == id)).GetValueOrDefault();
        }
    }
}
