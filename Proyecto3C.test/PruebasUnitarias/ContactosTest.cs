using Microsoft.EntityFrameworkCore;
using Proyecto3C.Controllers;
using Proyecto3C.DTOs;
using Proyecto3C.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto3C.test.PruebasUnitarias
{
    [TestClass]
    public class ContactosTest : DBTest
    {

        [TestMethod]
        public async Task ObtenerTodosLosContactos()
        {
            //Generar un nombre aleatorio para la DB
            var nombredbTest = Guid.NewGuid().ToString();
            //Contexto en memoria
            var context = ConstruirContext(nombredbTest);
            //Configuración de Automapper
            var mapper = ConfigureAutoMapper();

            context.Contactos.Add(new Contacto() { NombreCompleto = "Test1" , Correo="correo@test.com", Telefono="2343242"});
            context.Contactos.Add(new Contacto() { NombreCompleto = "Test2" , Correo="correo@test2.com", Telefono="22222222"});
           

            await context.SaveChangesAsync();
            //Contexto que no está en memoria
            var context2 = ConstruirContext(nombredbTest);

            //Prueba
            var controller = new ContactoController(context2, mapper);
            var respuesta = await controller.GetAllContactos();

            //Verificacion
            var clientes = respuesta.ToList();
            Assert.AreEqual(2, clientes.Count);
        }

        [TestMethod]
        public async Task ObtenerContactoPorId()
        {
            //Preparacion
            var nombredbTest = Guid.NewGuid().ToString();
            var context = ConstruirContext(nombredbTest);
            var mapper = ConfigureAutoMapper();

            context.Contactos.Add(new Contacto() { NombreCompleto = "Test1", Correo = "correo@test.com", Telefono = "2343242" });
            context.Contactos.Add(new Contacto() { NombreCompleto = "Test2", Correo = "correo@test2.com", Telefono = "22222222" });

            await context.SaveChangesAsync();
            var context2 = ConstruirContext(nombredbTest);

            //Prueba
            var controller = new ContactoController(context2, mapper);

            var id = 1;
            var respuesta = await controller.GetContacto(id);
            var resultado = respuesta.Value;
            Assert.AreEqual(id, resultado.Id);
        }

    }
}
