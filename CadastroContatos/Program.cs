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
/*    ASP.NET Core aplicativos criados com os modelos Web cont�m o
 *    c�digo de inicializa��o do aplicativo no Program.cs arquivo.

    O c�digo de inicializa��o do aplicativo a seguir d� suporte a:

    - P�ginas
    - Controladores MVC com exibi��es
    - API Web com controladores
    - APIs m�nimas
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
