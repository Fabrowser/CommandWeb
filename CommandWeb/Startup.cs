using CommandWeb.Entities;
using CommandWeb.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Security.Cryptography;
using System.Text;

namespace CommandWeb
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Livro", NomeLivro);
            builder.MapRoute("ToString", LivroToString);
            builder.MapRoute("Autores", ListaAutores);
            builder.MapRoute("LivrosEAutores", LivrosAutores);

            var rotas = builder.Build();
            app.UseRouter(rotas);
            //app.Run(Roteamento);

        }


        public Task NomeLivro(HttpContext context)
        {

            var _repo = new BookRepositorioSql();
            StringBuilder stbook = new StringBuilder();

            foreach (var book in _repo.Books)
            {
                stbook.Append(book.getName()+"\n");
            }
            return context.Response.WriteAsync("Nome dos Livros: \n-------------------------" +
                "\n" + stbook.ToString());


        }


        public Task LivroToString(HttpContext context)
        {

            var _repo = new BookRepositorioSql();
            StringBuilder stbook = new StringBuilder();

            foreach (var book in _repo.Books)
            {
                stbook.Append(book.ToString());
            }
            return context.Response.WriteAsync("Livros ToString: \n-------------------------" +
                "\n" + stbook.ToString());

        }



        public Task ListaAutores(HttpContext context)
        {

            var _repo = new BookRepositorioSql();
            Book livro = new Book();
            return context.Response.WriteAsync("Lista de Autores: \n-------------------------" +
                "\n" + livro.getAuthorNames());


        }

        public Task LivrosAutores(HttpContext context)
        {

            var _repo = new BookRepositorioSql();
            StringBuilder stlivrosAutores = new StringBuilder();

            foreach (var book in _repo.Books)
            {
                stlivrosAutores.Append(book.ToString() + "\nAutores: \n");
                foreach (Author autor in book.Authors)
                {
                    stlivrosAutores.Append(autor.Name  + "\n");
                }
                stlivrosAutores.Append("-------------------------------------\n");

            }
           

            return context.Response.WriteAsync("Lista de Livros e Autores: \n-------------------------------------" +
                "\n" + stlivrosAutores.ToString() + "-------------------------------------");

        }

    }
}