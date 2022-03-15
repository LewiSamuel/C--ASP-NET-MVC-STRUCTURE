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
     * a classe com nome Startup é inicializada de forma automática pelo ASP.NET.
     * Nela é iniciada todas as configurações necessários para
     * o projeto e agora vou mostrar a entender melhor essas configurações.
     */
    public class Startup
    {

        /**
         * • Método Startup onde é responsável por carregar os valores da configuração
         */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        /*
         * • Método ConfigureServices onde é responsável por
         *   adicionar os serviços no container do injetor de dependência.
         */
        public void ConfigureServices(IServiceCollection services)
        {
            // pega url de connexão com banco de dados
            string DATABASE_CON = Configuration.GetConnectionString("DataBase");

            services.AddControllersWithViews();
            services.AddApplicationInsightsTelemetry();
            // Faz a conexão com o banco de dados baseado no contexto pasado
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o => o.UseSqlServer(DATABASE_CON));

            // Adiciona repositório do Cadastro de contatos ao projeto
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        /*
         * • Método Configure onde é responsável por adicionar os
         *   middlewares e serviços no HTTP pipeline.
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
