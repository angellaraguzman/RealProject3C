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
             CreateMap<ContactoCreacionDTO, Contacto>().ForMember(contacto => contacto.xClientesContactos, options => options.MapFrom(MapClientesContactos)).ReverseMap();

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
