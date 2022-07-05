namespace Proyecto3C.Entities
{
    public class Contacto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public List<xClienteContacto> xClientesContactos { get; set; }
    }
}
