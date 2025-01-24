using BECrudAngular_NETCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BECrudAngular_NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ContactoController(AplicationDbContext context)
        {
            _context = context;
        }
        // POST api/<ContactoController>
        [HttpPost]
        public async Task<IActionResult> GuardarContacto([FromBody] Contacto contacto)
        {
            try
            {
                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return Ok(contacto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
