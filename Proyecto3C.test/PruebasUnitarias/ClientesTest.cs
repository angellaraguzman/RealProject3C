using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proyecto3C.Controllers;
using Proyecto3C.DTOs;
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
            var context = ConstruirContext(nombredbTest);
            //Configuración de Automapper
            var mapper = ConfigureAutoMapper();

            context.Clientes.Add(new Cliente() { NombreCompleto ="Test1", Curp = "test1", Domicilio="test1", TipoPersona = "1"});
            context.Clientes.Add(new Cliente() { NombreCompleto ="Test2", Curp = "Test2", Domicilio= "Test2", TipoPersona = "2"});

            await context.SaveChangesAsync();
            //Contexto que no está en memoria
            var context2 = ConstruirContext(nombredbTest);

            //Prueba
            var controller = new ClientesController(context2, mapper);
            var respuesta = await controller.GetAllClientes();

            //Verificacion
            var clientes= respuesta.ToList();
            Assert.AreEqual(2, clientes.Count); 
        }

        [TestMethod]
        public async Task ObtenerClientePorId()
        {
            //Preparacion
            var nombredbTest = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombredbTest);
            var mapper = ConfigureAutoMapper();

            context.Clientes.Add(new Cliente() { NombreCompleto = "Test1", Curp = "test1", Domicilio = "test1", TipoPersona = "1" });
            context.Clientes.Add(new Cliente() { NombreCompleto = "Test2", Curp = "Test2", Domicilio = "Test2", TipoPersona = "2" });

            await context.SaveChangesAsync();
            var context2 = ConstruirContext(nombredbTest);

            //Prueba
            var controller = new ClientesController(context2, mapper);

            var id = 1;
            var respuesta = await controller.GetCliente(id);
            var resultado = respuesta.Value;
            Assert.AreEqual(id, resultado.Id);
        }

        [TestMethod]
        public async Task CrearCliente()
        {
            var nombredbTest = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombredbTest);
            var mapper = ConfigureAutoMapper();

            var nuevoCliente = new ClienteCreacionDTO() { NombreCompleto ="Test1", TipoPersona= (Enum.TipoPersona)1 };
            var controller = new ClientesController(context, mapper);

            var respuesta = await controller.CreateCliente(nuevoCliente);

            var context2 = ConstruirContext(nombredbTest);
            var totalCliente = await context2.Clientes.CountAsync();
            Assert.AreEqual(1, totalCliente);
        }
       
    }
}