using CadastroContatos.Data;
using CadastroContatos.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroContatos
{
    /*
     * O ponto de partida do projeto, por default,
     * a classe com nome Startup � inicializada de forma autom�tica pelo ASP.NET.
     * Nela � iniciada todas as configura��es necess�rios para
     * o projeto e agora vou mostrar a entender melhor essas configura��es.
     */
    public class Startup
    {

        /**
         * � M�todo Startup onde � respons�vel por carregar os valores da configura��o
         */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        /*
         * � M�todo ConfigureServices onde � respons�vel por
         *   adicionar os servi�os no container do injetor de depend�ncia.
         */
        public void ConfigureServices(IServiceCollection services)
        {
            // pega url de connex�o com banco de dados
            string DATABASE_CON = Configuration.GetConnectionString("DataBase");

            services.AddControllersWithViews();
            services.AddApplicationInsightsTelemetry();
            // Faz a conex�o com o banco de dados baseado no contexto pasado
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o => o.UseSqlServer(DATABASE_CON));

            // Adiciona reposit�rio do Cadastro de contatos ao projeto
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        /*
         * � M�todo Configure onde � respons�vel por adicionar os
         *   middlewares e servi�os no HTTP pipeline.
         */
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
