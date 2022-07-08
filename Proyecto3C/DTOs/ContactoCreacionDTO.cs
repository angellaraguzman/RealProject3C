using System.ComponentModel.DataAnnotations;

namespace Proyecto3C.DTOs
{
    public class ContactoCreacionDTO
    {
        [Required(ErrorMessage = "El campo Nombre Completo es requerido")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "El campo Nombre Completo es requerido")]
        [EmailAddress]
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public List<int> ClientesId { get; set; }

    }
}
