using BECrudAngular_NETCore.Services;
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
    public class TraduccionController : ControllerBase
    {
        private readonly TraduccionService _service;

        public TraduccionController(TraduccionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTraducciones(string lang)
        {
            var traducciones = await _service.GetTraduccionesPorIdioma(lang);
            if (traducciones == null || !traducciones.Any())
            {
                return NotFound(new { mensaje = "No se encontraron traducciones para el idioma especificado." });
            }

            return Ok(traducciones);
        }

        //// GET: api/<TraduccionController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<TraduccionController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

    }
}
