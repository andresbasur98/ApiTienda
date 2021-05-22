using ApiTienda.Data;
using ApiTienda.Helpers;
using ApiTienda.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = this.Configuration.GetConnectionString("cadenamysql");
            
            services.AddTransient<RepositoryProductos>();
            services.AddTransient<RepositoryUsuarios>();
            services.AddTransient<RepositoryCategoria>();
            services.AddTransient<RepositoryPedidos>();
            services.AddTransient<HelperToken>();

            services.AddDbContext<TiendaContext>(options =>
            //options.UseSqlServer(cadena)
            options.UseMySql(
                cadena, ServerVersion.AutoDetect(cadena)
            ));

      

            //SWAGGER
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc(name: "v1"
                        , new OpenApiInfo
                        {
                            Title = "Api Tienda"
                            ,
                            Version = "v1",
                            //Description = "Ejemplo de seguridad OAuth Token"
                        });
                });

            HelperToken helper = new HelperToken(Configuration);

            services.AddAuthentication(helper.GetAuthOptions())
                .AddJwtBearer(helper.GetJwtBearerOptions());


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "Api v1");
                    c.RoutePrefix = "";
                });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
