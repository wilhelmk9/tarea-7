using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarea_7.Models;

namespace tarea_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSangreController : ControllerBase
    {
        private readonly EscuelaDbContext _context;

        public TipoSangreController(EscuelaDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoSangres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoSangre>>> GetTiposSangre()
        {
          if (_context.TiposSangre == null)
          {
              return NotFound();
          }
            return await _context.TiposSangre.ToListAsync();
        }

        // GET: api/TipoSangres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoSangre>> GetTipoSangre(int id)
        {
          if (_context.TiposSangre == null)
          {
              return NotFound();
          }
            var tipoSangre = await _context.TiposSangre.FindAsync(id);

            if (tipoSangre == null)
            {
                return NotFound();
            }

            return tipoSangre;
        }

        // PUT: api/TipoSangres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoSangre(int id, TipoSangre tipoSangre)
        {
            if (id != tipoSangre.IdTipoSangre)
            {
                return BadRequest();
            }

            _context.Entry(tipoSangre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoSangreExists(id))
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

        // POST: api/TipoSangres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoSangre>> PostTipoSangre(TipoSangre tipoSangre)
        {
          if (_context.TiposSangre == null)
          {
              return Problem("Entity set 'EscuelaDbContext.TiposSangre'  is null.");
          }
            _context.TiposSangre.Add(tipoSangre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoSangre", new { id = tipoSangre.IdTipoSangre }, tipoSangre);
        }

        // DELETE: api/TipoSangres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoSangre(int id)
        {
            if (_context.TiposSangre == null)
            {
                return NotFound();
            }
            var tipoSangre = await _context.TiposSangre.FindAsync(id);
            if (tipoSangre == null)
            {
                return NotFound();
            }

            _context.TiposSangre.Remove(tipoSangre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoSangreExists(int id)
        {
            return (_context.TiposSangre?.Any(e => e.IdTipoSangre == id)).GetValueOrDefault();
        }
    }
}
