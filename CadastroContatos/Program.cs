using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroContatos
{
/*    ASP.NET Core aplicativos criados com os modelos Web contêm o
 *    código de inicialização do aplicativo no Program.cs arquivo.

    O código de inicialização do aplicativo a seguir dá suporte a:

    - Páginas
    - Controladores MVC com exibições
    - API Web com controladores
    - APIs mínimas
*/
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
