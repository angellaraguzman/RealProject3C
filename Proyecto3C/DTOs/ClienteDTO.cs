namespace Proyecto3C.DTOs
{
    public class ClienteDTO
    {

        
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public List<ContactoDTO> Contactos { get; set; }
       
    }
}
