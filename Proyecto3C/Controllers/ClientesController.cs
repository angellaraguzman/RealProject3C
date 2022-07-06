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
    public class ClientesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<List<Cliente>> GetAllClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .Include(clienteDb => clienteDb.xClientesContactos)
                .ThenInclude(clientecontactoDb => clientecontactoDb.Contacto)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null)
            {
                return BadRequest("Cliente not found");
            }
            return _mapper.Map<ClienteDTO>(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<ActionResult> CreateCliente(ClienteCreacionDTO clienteCreacion)
        {
            if ((int)clienteCreacion.TipoPersona < 1 || (int)clienteCreacion.TipoPersona > 2) 
            {
                return BadRequest("Ingresaste un tipo de persona que no es válido");
            }

            var existeClienteMismoNombre = await _context.Clientes.AnyAsync(x => x.NombreCompleto == clienteCreacion.NombreCompleto);
            if (existeClienteMismoNombre)
            {
                return BadRequest("Ya existe ese nombre");
            }
            var cliente = _mapper.Map<Cliente>(clienteCreacion);
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok();
        }
        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditCliente(ClienteCreacionDTO clienteCreacionDTO, int id)
        {
            var clienteExist = await _context.Clientes.AnyAsync(x => x.Id == id);
            if (!clienteExist)
            {
                return BadRequest("El cliente que buscas no existe");
            }
            var cliente = _mapper.Map<Cliente>(clienteCreacionDTO);
            cliente.Id = id;

            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var clienteExist = await _context.Clientes.AnyAsync(x => x.Id == id);

            if (!clienteExist)
            {
                return BadRequest("El cliente que buscas no existe");
            }

            _context.Remove(new Cliente() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
