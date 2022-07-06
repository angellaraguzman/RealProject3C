using Proyecto3C.Enum;

namespace Proyecto3C.DTOs
{
    public class ClienteCreacionDTO
    {
        public TipoPersona TipoPersona { get; set; }
        public string NombreCompleto { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public string Domicilio { get; set; }
    }
}
