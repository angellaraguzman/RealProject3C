using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto3C.Data;
using Proyecto3C.DTOs;
using Proyecto3C.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto3C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<ContactoController>
        [HttpGet]
        public async Task<List<Contacto>> GetAllContactos()
        {
            return await _context.Contactos.ToListAsync();
        }

        // GET api/<ContactoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactoDTO>> GetContacto(int id)
        {
            var contacto = await _context.Contactos
                .Include(clienteDb => clienteDb.xClientesContactos)
                .ThenInclude(clienteContactoDb => clienteContactoDb.Cliente).FirstOrDefaultAsync(x => x.Id == id);
            if (contacto == null)
            {
                return BadRequest("Cliente no existe");
            }

            contacto.xClientesContactos = contacto.xClientesContactos.OrderBy(x => x.Orden).ToList();
            return _mapper.Map<ContactoDTO>(contacto);
        }

        // POST api/<ContactoController>
        [HttpPost]
        public async Task<ActionResult> Post(ContactoCreacionDTO contactoCreacion)
        {
            if (contactoCreacion.ClientesId == null)
            {
                return BadRequest("No se puede crear un libro sin autores");
            }
            var contactos = await _context.Clientes
                .Where(clienteDb => contactoCreacion.ClientesId.Contains(clienteDb.Id))
                .Select(x => x.Id)
                .ToListAsync();
           
            if (contactoCreacion.ClientesId.Count != contactos.Count)
            {
                return BadRequest("No existe uno de los Clientes ingresados");
            }
            var contacto = _mapper.Map<Contacto>(contactoCreacion);

            if (contacto.xClientesContactos != null)
            {
                for (int i = 0; i < contacto.xClientesContactos.Count; i++)
                {
                    contacto.xClientesContactos[i].Orden = i;
                }
            }
            _context.Add(contacto);
            await _context.SaveChangesAsync();
            return Ok();

        }


        // PUT api/<ContactoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditContacto(Contacto contacto, int id)
        {
            if (contacto.Id != id)
            {
                return BadRequest("El id del cliente no coincide con el Id seleccionado");
            }
            var contactoExist = await _context.Contactos.AnyAsync(x => x.Id == id);
            if (!contactoExist)
            {
                return BadRequest("El cliente que buscas no existe");
            }
            _context.Update(contacto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ContactoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContacto(int id)
        {
            var contactoExist = await _context.Contactos.AnyAsync(x => x.Id == id);

            if (!contactoExist)
            {
                return BadRequest("El cliente que buscas no existe");
            }

            _context.Remove(new Contacto() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
