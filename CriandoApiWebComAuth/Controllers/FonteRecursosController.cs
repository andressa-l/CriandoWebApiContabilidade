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
    public class FonteRecursosController : ControllerBase
    {
        private readonly ContabilidadeFinancas_dbContext _context;

        public FonteRecursosController(ContabilidadeFinancas_dbContext context)
        {
            _context = context;
        }

        // GET: api/FonteRecursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FonteRecurso>>> GetFonteRecursos()
        {
          if (_context.FonteRecursos == null)
          {
              return NotFound();
          }
            return await _context.FonteRecursos.ToListAsync();
        }

        // GET: api/FonteRecursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FonteRecurso>> GetFonteRecurso(int id)
        {
          if (_context.FonteRecursos == null)
          {
              return NotFound();
          }
            var fonteRecurso = await _context.FonteRecursos.FindAsync(id);

            if (fonteRecurso == null)
            {
                return NotFound();
            }

            return fonteRecurso;
        }

        // PUT: api/FonteRecursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFonteRecurso(int id, FonteRecurso fonteRecurso)
        {
            if (id != fonteRecurso.IdFonteRecursos)
            {
                return BadRequest();
            }

            _context.Entry(fonteRecurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FonteRecursoExists(id))
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

        // POST: api/FonteRecursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FonteRecurso>> PostFonteRecurso(FonteRecurso fonteRecurso)
        {
          if (_context.FonteRecursos == null)
          {
              return Problem("Entity set 'ContabilidadeFinancas_dbContext.FonteRecursos'  is null.");
          }
            _context.FonteRecursos.Add(fonteRecurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFonteRecurso", new { id = fonteRecurso.IdFonteRecursos }, fonteRecurso);
        }

        // DELETE: api/FonteRecursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFonteRecurso(int id)
        {
            if (_context.FonteRecursos == null)
            {
                return NotFound();
            }
            var fonteRecurso = await _context.FonteRecursos.FindAsync(id);
            if (fonteRecurso == null)
            {
                return NotFound();
            }

            _context.FonteRecursos.Remove(fonteRecurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FonteRecursoExists(int id)
        {
            return (_context.FonteRecursos?.Any(e => e.IdFonteRecursos == id)).GetValueOrDefault();
        }
    }
}
