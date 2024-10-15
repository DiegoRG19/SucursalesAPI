using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QualaAPI.Models;

namespace QualaAPI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly TestDbContext _context;

        public SucursalesController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SucursalesPru>>> GetSucursales()
        {
            return await _context.SucursalesPrus.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalesPru>> GetSucursal(int id)
        {
            var sucursal = await _context.SucursalesPrus.FindAsync(id);
            
            if(sucursal == null)
            {
                return NotFound();
            }

            return sucursal;
        }

        [HttpPost]
        public async Task<ActionResult<SucursalesPru>> SendSucursal(SucursalesPru sucursal)
        {
            DateTime fechaCrea = DateTime.Now;
            sucursal.FechaCreacion = fechaCrea;
            _context.SucursalesPrus.Add(sucursal);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSucursal(SucursalesPru sucursal, int id)
        {
            if(id != sucursal.Codigo)
            {
                return BadRequest();
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var sucursal = await _context.SucursalesPrus.FindAsync(id);

            if(sucursal == null)
            {
                return NotFound();
            }
            _context.Remove(sucursal);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
