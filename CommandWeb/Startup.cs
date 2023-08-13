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

            foreach (var book in _repo.books)
            {
                stbook.Append(book.getName());
            }
            return context.Response.WriteAsync("Nome dos Livros: \n-------------------------" +
                "\n" + stbook.ToString());


        }


        public Task LivroToString(HttpContext context)
        {

            var _repo = new BookRepositorioSql();
            StringBuilder stbook = new StringBuilder();

            foreach (var book in _repo.books)
            {
                stbook.Append(book.ToString());
            }
            return context.Response.WriteAsync("Livros ToString: \n-------------------------" +
                "\n" + stbook.ToString());

        }



        public Task ListaAutores(HttpContext context)
        {

            var _repo = new BookRepositorioSql();
            StringBuilder stauthors = new StringBuilder();

            foreach (var author in _repo.authors)
            {
                stauthors.Append(author.ToString());
            }
            return context.Response.WriteAsync("Lista de Autores: \n-------------------------" +
                "\n" + stauthors.ToString());


        }

        public Task LivrosAutores(HttpContext context)
        {

            var _repo = new BookRepositorioSql();
            StringBuilder stlivrosAutores = new StringBuilder();

            foreach (var book in _repo.books)
            {
                stlivrosAutores.Append(book.ToString());
                stlivrosAutores.Append("Autores\n\n");
                stlivrosAutores.Append(book.getAuthorNames());
            }
            return context.Response.WriteAsync("Lista de Livros e Autores: \n-------------------------------------" +
                "\n" + stlivrosAutores.ToString() + "-------------------------------------");

        }

    }
}