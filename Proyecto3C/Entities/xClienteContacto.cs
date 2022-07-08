namespace Proyecto3C.Entities
{
    public class xClienteContacto
    {
        //Clase intermedia que une las tablas de cliente y contacto por medio de 2 clases foraneas
        public int ClienteId { get; set; }
        public int ContactoId { get; set; }
        public int Orden { get; set; }
        public Cliente Cliente { get; set; }
        public Contacto Contacto { get; set; }
    }
}
