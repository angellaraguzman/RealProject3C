using Microsoft.EntityFrameworkCore;
using Proyecto3C.Entities;

namespace Proyecto3C.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<xClienteContacto>()
                .HasKey(cl => new { cl.ClienteId, cl.ContactoId });
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<xClienteContacto> xClientesContactos { get; set; }
    }
}
