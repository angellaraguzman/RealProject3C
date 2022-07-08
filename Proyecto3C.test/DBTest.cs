using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proyecto3C.Data;
using Proyecto3C.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto3C.test
{
    public class DBTest
    {
        //Para que la prueba unitaria pueda contruir su propia base de datos
        protected ApplicationDbContext ConstruirContext (string dbTest)
        {
            var opciones = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(dbTest).Options;
            var dbContext = new ApplicationDbContext (opciones);
            return dbContext;
        }
        //Configuración de AutoMapper
        protected IMapper ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(options => options.AddProfile(new AutoMapperProfiles()));
            return config.CreateMapper();
        }
    }
}
