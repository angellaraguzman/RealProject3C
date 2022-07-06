using AutoMapper;
using Proyecto3C.DTOs;
using Proyecto3C.Entities;

namespace Proyecto3C.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Cliente, ClienteCreacionDTO>().ReverseMap();
            CreateMap<Contacto, ContactoCreacionDTO>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>().ForMember(clienteDTO => clienteDTO.Contactos, options => options.MapFrom(MapClientesDTOContactos)).ReverseMap();

            CreateMap<ContactoCreacionDTO, Contacto>().ForMember(contacto => contacto.xClientesContactos, options => options.MapFrom(MapClientesContactos)).ReverseMap();
            CreateMap<Contacto, ContactoDTO>().ForMember(contactoDTO => contactoDTO.Clientes, options => options.MapFrom(MapContactosDTOClientes)).ReverseMap();

        }
        private List<ContactoDTO> MapClientesDTOContactos(Cliente cliente, ClienteDTO clienteDTO)
        {
            var result = new List<ContactoDTO>();
            if (cliente.xClientesContactos == null)
            {
                return result;
            }
            foreach (var clienteContacto in cliente.xClientesContactos)
            {
                result.Add(new ContactoDTO()
                {
                    Id = clienteContacto.ContactoId,
                    NombreCompleto = clienteContacto.Contacto.NombreCompleto,
                    Correo = clienteContacto.Contacto.Correo,
                    Telefono = clienteContacto.Contacto.Telefono
                } );
            }
            return result;
        }

        private List<ClienteDTO> MapContactosDTOClientes(Contacto contacto, ContactoDTO contactoDTO)
        {
            var result = new List<ClienteDTO>();
            if (contacto.xClientesContactos == null)
            {
                return result;
            }
            foreach (var clienteContacto in contacto.xClientesContactos)
            {
                result.Add(new ClienteDTO()
                {
                    Id = clienteContacto.ClienteId,
                    NombreCompleto = clienteContacto.Cliente.NombreCompleto
                } );
            }
            return result;
        }

        private List<xClienteContacto> MapClientesContactos(ContactoCreacionDTO contactoCreacion, Contacto contacto)
        {
            var result = new List<xClienteContacto>();
            if (contactoCreacion.ClientesId == null)
            {
                return result;
            }
            foreach (var clienteid in contactoCreacion.ClientesId)
            {
                result.Add(new xClienteContacto() { ClienteId = clienteid });
            }
            return result;
        }
    }
}
