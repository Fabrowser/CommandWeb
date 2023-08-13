using CommandWeb.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandWeb.Repositorio
{
    internal class BookRepositorioSql
    {


        public List<Book> books;
        public List<Author> authors;


        public BookRepositorioSql()
        {

            books = new List<Book>();
            authors = new List<Author>();
            Author autor;

            try
            {
                Conectar con = new Conectar();

                using (SqlConnection connection = new SqlConnection(con.ConexaoDb().ConnectionString))
                {
                    connection.Open();
               

                    //Query com o comando de muitos para muitos
                    String sql = "select l.id_livro, l.nm_livro, l.price, l.qty, a.id_author,a.name_author,a.email, a.gender from livro as l inner join livro_autor on l.id_livro = livro_autor.id_livro \r\n      inner join autor as a on a.id_author = livro_autor.id_autor\r\n   ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            while (reader.Read())
                            {
                                Book livro = new Book(reader.GetInt32(0), reader.GetString(1), authors, reader.GetFloat(2), reader.GetInt32(3));

                                if (books.Find(id => id.IdLivro == livro.IdLivro) == null)
                                //Pesquisa se o livro ja tem na lista. Caso não , adiciona
                                {
                                    books.Add(livro);
                                    
                                }

                                autor = new Author(reader.GetString(5), reader.GetString(6), reader.GetString(7));
                                if (livro.Authors.Contains(autor))
                                {

                                }
                                else
                                {
                                    livro.Authors.Add(autor);

                                }

                            }

                            //Console.WriteLine("{0} {1}", reader.GetString(1), reader.GetString(5));
                        }



                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
