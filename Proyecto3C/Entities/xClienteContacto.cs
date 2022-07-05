namespace Proyecto3C.Entities
{
    public class xClienteContacto
    {
        public int ClienteId { get; set; }
        public int ContactoId { get; set; }
        public int Orden { get; set; }
        public Cliente Cliente { get; set; }
        public Contacto Contacto { get; set; }
    }
}
