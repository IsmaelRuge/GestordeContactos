using ContactosRepositorios;
using GestordeContactos.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestordeContactos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly IContactoRepositorio _contactoRepositorio;

        public ContactosController(IContactoRepositorio contactoRepositorio)
        {
            _contactoRepositorio = contactoRepositorio;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contacto contacto)
        {
            if (contacto == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(contacto.Nombre))
                ModelState.AddModelError("Nombre", "Hace falta el Nombre");

            if (string.IsNullOrEmpty(contacto.Apellido))
                ModelState.AddModelError("Apellido", "Hace falta el Apellido");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactoRepositorio.InsertarContacto(contacto);

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contacto contacto)
        {
            if (contacto == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(contacto.Nombre))
                ModelState.AddModelError("Nombre", "Hace falta el Nombre");

            if (string.IsNullOrEmpty(contacto.Apellido))
                ModelState.AddModelError("Apellido", "Hace falta el Apellido");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactoRepositorio.ActualizarContacto(contacto);

            return NoContent();
        }


        [HttpGet]
        public async Task<IEnumerable<Contacto>> Get()
        {
            return await _contactoRepositorio.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Contacto> Get(int id)
        {
            return await _contactoRepositorio.GetDetalles(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _contactoRepositorio.EliminarContacto(id);
        }  
    }
}
