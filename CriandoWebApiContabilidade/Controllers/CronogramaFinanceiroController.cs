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
    public class CronogramaFinanceiroController : ControllerBase
    {
        private readonly db_contabilidade_3tecnosContext _context;

        public CronogramaFinanceiroController(db_contabilidade_3tecnosContext context)
        {
            _context = context;
        }

        // GET: api/CronogramaFinanceiro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CronogramaFinanceiro>>> GetCronogramaFinanceiros()
        {
          if (_context.CronogramaFinanceiros == null)
          {
              return NotFound();
          }
            return await _context.CronogramaFinanceiros.ToListAsync();
        }

        // GET: api/CronogramaFinanceiro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CronogramaFinanceiro>> GetCronogramaFinanceiro(int id)
        {
          if (_context.CronogramaFinanceiros == null)
          {
              return NotFound();
          }
            var cronogramaFinanceiro = await _context.CronogramaFinanceiros.FindAsync(id);

            if (cronogramaFinanceiro == null)
            {
                return NotFound();
            }

            return cronogramaFinanceiro;
        }

        // PUT: api/CronogramaFinanceiro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCronogramaFinanceiro(int id, CronogramaFinanceiro cronogramaFinanceiro)
        {
            if (id != cronogramaFinanceiro.IdCronogramaFinanceiro)
            {
                return BadRequest();
            }

            _context.Entry(cronogramaFinanceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CronogramaFinanceiroExists(id))
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

        // POST: api/CronogramaFinanceiro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CronogramaFinanceiro>> PostCronogramaFinanceiro(CronogramaFinanceiro cronogramaFinanceiro)
        {
          if (_context.CronogramaFinanceiros == null)
          {
              return Problem("Entity set 'db_contabilidade_3tecnosContext.CronogramaFinanceiros'  is null.");
          }
            _context.CronogramaFinanceiros.Add(cronogramaFinanceiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCronogramaFinanceiro", new { id = cronogramaFinanceiro.IdCronogramaFinanceiro }, cronogramaFinanceiro);
        }

        // DELETE: api/CronogramaFinanceiro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCronogramaFinanceiro(int id)
        {
            if (_context.CronogramaFinanceiros == null)
            {
                return NotFound();
            }
            var cronogramaFinanceiro = await _context.CronogramaFinanceiros.FindAsync(id);
            if (cronogramaFinanceiro == null)
            {
                return NotFound();
            }

            _context.CronogramaFinanceiros.Remove(cronogramaFinanceiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CronogramaFinanceiroExists(int id)
        {
            return (_context.CronogramaFinanceiros?.Any(e => e.IdCronogramaFinanceiro == id)).GetValueOrDefault();
        }
    }
}
