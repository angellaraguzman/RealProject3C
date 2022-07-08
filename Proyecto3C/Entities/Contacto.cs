using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Proyecto3C.Entities
{
    public class Contacto
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="El campo Nombre Completo es requerido")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "El campo Nombre Completo es requerido")]
        [EmailAddress]
        public string Correo { get; set; }
        public string Telefono { get; set; }
        [JsonIgnore]
        public List<xClienteContacto> xClientesContactos { get; set; }
    }
}
