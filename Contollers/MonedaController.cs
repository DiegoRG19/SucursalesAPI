using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QualaAPI.Models;

namespace QualaAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly TestDbContext _context;

        public MonedaController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonedaPru>>> GetMonedas()
        {
            return await _context.MonedaPrus.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MonedaPru>> GetMoneda(int id)
        {
            var moneda = await _context.MonedaPrus.FindAsync(id);

            if(moneda == null)
            {
                return NotFound();
            }
            return moneda;
        }

        [HttpPost]
        public async Task<ActionResult<MonedaPru>> SendMoneda(MonedaPru moneda)
        {
            _context.MonedaPrus.Add(moneda);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMoneda(MonedaPru moneda, int id)
        {
            if(id != moneda.IdMoneda)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMoneda(int id)
        {
            var moneda = await _context.MonedaPrus.FindAsync(id);

            if(moneda == null)
            {
                return NotFound();
            }

            _context.MonedaPrus.Remove(moneda);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
