using Proyecto3C.Enum;
using System.ComponentModel.DataAnnotations;

namespace Proyecto3C.DTOs
{
    public class ClienteCreacionDTO
    {
        //Campos necesarios para la creación de cliente por POST
        [Required(ErrorMessage = "El campo TipoPersona Completo es requerido")]
        public TipoPersona TipoPersona { get; set; }
        public string NombreCompleto { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public string Domicilio { get; set; }
    }
}
