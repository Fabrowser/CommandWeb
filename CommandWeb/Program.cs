using CommandWeb;
using CommandWeb.Entities;
using CommandWeb.Repositorio;

var _repo = new BookRepositorioSql();

IWebHost host = new WebHostBuilder()
    .UseKestrel()
    .UseStartup<Startup>()
    .Build();

host.Run();


static void ImprimeLista(BookRepositorioSql lista)
{
    Console.WriteLine(lista);

}