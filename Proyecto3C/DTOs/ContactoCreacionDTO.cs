namespace Proyecto3C.DTOs
{
    public class ContactoCreacionDTO
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public List<int> ClientesId { get; set; }

    }
}
