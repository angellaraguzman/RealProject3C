namespace Proyecto3C.DTOs
{
    public class ContactoDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public List<ClienteDTO> Clientes { get; set; }
    }
}
