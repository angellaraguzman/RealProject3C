using AutoMapper;
using Proyecto3C.Controllers;
using Proyecto3C.Entities;

namespace Proyecto3C.test.PruebasUnitarias
{
    [TestClass]
    public class ClientesTest:DBTest
    {
        [TestMethod]
        public async Task ObtenerTodosLosClientes()
        {
            //Preparacion
            //Generar un nombre aleatorio
            var nombredbTest = Guid.NewGuid().ToString();
            //Contexto en memoria
            var context = ContruirContext(nombredbTest);
            var mapper = ConfigureAutoMapper();

            context.Clientes.Add(new Cliente() { NombreCompleto ="Test1", Curp = "test1", Domicilio="test1", TipoPersona = "1"});
            context.Clientes.Add(new Cliente() { NombreCompleto ="Test2", Curp = "Test2", Domicilio= "Test2", TipoPersona = "2"});

            await context.SaveChangesAsync();
            //Contexto que no está en memoria
            var context2 = ContruirContext(nombredbTest);

            //Prueba
            var controller = new ClientesController(context2, mapper);
            var respuesta = await controller.GetAllClientes();

            //Verificacion
            var clientes= respuesta.ToList();
            Assert.AreEqual(2, clientes.Count); 

        }
    }
}