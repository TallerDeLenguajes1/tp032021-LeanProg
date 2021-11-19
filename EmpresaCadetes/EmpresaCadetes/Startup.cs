using EmpresaCadetes.Entidades;
using EmpresaCadetes.DataBase;
using EmpresaCadetes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmpresaCadetes
{
    public class Startup
    {
       
       Cadeteria cadeteria = new Cadeteria(); 
        DBCadeteria DB = new DBCadeteria();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IIDBSQLite DB = new IDBSQLite(Configuration.GetConnectionString("Default"));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSingleton(DB);
            ////string connectionString=Configuration.GetConecction("Default");
            //IRepositorioCadetesDB repositorioCadetes=  new RepositorioCadetesSQLite(Configuration.GetConnectionString("Default"));
            //IRepositorioPedidosDB repositorioPedidos = new RepositorioPedidosSQLite(Configuration.GetConnectionString("Default"));
            //cadeteria.MisCadetes = DB.ReadCadetes();
            //cadeteria.MisPedidos = DB.ReadPedidos();
            //cadeteria.MisPagos = DB.ReadPago();

            //services.AddSingleton(cadeteria);
            //services.AddSingleton(DB);
            //services.AddSingleton(repositorioCadetes);
            //services.AddSingleton(repositorioPedidos);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

