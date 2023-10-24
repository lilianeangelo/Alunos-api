using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alunos;
using Data;

namespace Alunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunosContext _context;

        public AlunoController(AlunosContext context)
        {
            _context = context;
        }

        // GET: api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alunosclass>>> GetAlunos()
        {
          if (_context.Alunos == null)
          {
              return NotFound();
          }
            return await _context.Alunos.ToListAsync();
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alunosclass>> GetAlunos(int id)
        {
          if (_context.Alunos == null)
          {
              return NotFound();
          }
            var alunos = await _context.Alunos.FindAsync(id);

            if (alunos == null)
            {
                return NotFound();
            }

            return alunos;
        }

        // PUT: api/Aluno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlunos(int id, Alunosclass alunos)
        {
            if (id != alunos.Id)
            {
                return BadRequest();
            }

            _context.Entry(alunos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunosExists(id))
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

        // POST: api/Aluno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alunosclass>> PostAlunos(Alunosclass alunos)
        {
          if (_context.Alunos == null)
          {
              return Problem("Entity set 'AlunosContext.Alunos'  is null.");
          }
            _context.Alunos.Add(alunos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlunos", new { id = alunos.Id }, alunos);
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlunos(int id)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }
            var alunos = await _context.Alunos.FindAsync(id);
            if (alunos == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(alunos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunosExists(int id)
        {
            return (_context.Alunos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
