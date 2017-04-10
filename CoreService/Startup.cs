using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CoreService.Entities;
using Microsoft.EntityFrameworkCore;
using CoreService.Contratos;
using CoreService.Repository;
using CoreService.Data;
using CoreService.Repository.Implementations;
using CoreService.Models;

namespace CoreService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().
                AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    
                    });

            //inyectamos la dependencia del entityFrame Directamente pasando como referencia la cadena de coneccion a la db
            services.AddDbContext<Hungry4Context>(options => options.UseSqlServer(Configuration.GetConnectionString("HunngrySchema2")));

            //inyectamos la referencia al servicio.
            services.AddSingleton<IRepository<Alimentos>, AlimentosRepo>();
            services.AddSingleton<IRepository<Ordenes>, OrdenesRepo>();
            services.AddSingleton<IRepository<Categorias>, CategoriasRepo>();
            services.AddSingleton<IRepository<Comensales>, ComensalesRepo>();
            services.AddSingleton<IRepository<FoodImageMapping>, FoodImageMappingRepo>();
            services.AddSingleton<IRepository<FoodImages>, FoodImagesRepo>();
            services.AddSingleton<IRepository<Tipos>, TipoRepo>();
            services.AddSingleton<IRepository<Estado>, EstadoRepo>();
            services.AddSingleton<IRepository<Menu>, MenuRepo>();

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, Hungry4Context context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            //inicializamos la BD
            //DbInitializer.Init(context);

            
        }
    }
}
