using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICarro.Data;
using Models;

namespace APICarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly APICarroContext _context;

        public CarrosController(APICarroContext context)
        {
            _context = context;
        }

        // GET: api/Carroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarro()
        {
            if (_context.Carro == null)
            {
                return NotFound();
            }
            return await _context.Carro.ToListAsync();
        }

        // GET: api/Carroes/5
        [HttpGet("{placa}")]
        public async Task<ActionResult<Carro>> GetCarro(string placa)
        {
            if (_context.Carro == null)
            {
                return NotFound();
            }
            var carro = await _context.Carro.FindAsync(placa);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        // PUT: api/Carroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{placa}")]
        public async Task<IActionResult> PutCarro(string placa, Carro carro)
        {
            if (placa == carro.Placa)
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(placa))
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

        // POST: api/Carroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
            if (_context.Carro == null)
            {
                return Problem("Entity set 'APICarroContext.Carro'  is null.");
            }
            _context.Carro.Add(carro);

            await _context.SaveChangesAsync();
            return carro;
        }

        // DELETE: api/Carroes/5
        [HttpDelete("{placa}")]
        public async Task<IActionResult> DeleteCarro(string placa)
        {
            if (_context.Carro == null)
            {
                return NotFound();
            }
            var carro = await _context.Carro.FindAsync(placa);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carro.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(string placa)
        {
            return (_context.Carro?.Any(e => e.Placa == placa)).GetValueOrDefault();
        }
    }
}
