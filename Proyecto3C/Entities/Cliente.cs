namespace Proyecto3C.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string TipoPersona { get; set; }
        public string NombreCompleto { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public string Domicilio { get; set; }

        public List<xClienteContacto> xClientesContactos { get; set; }
    }
}
