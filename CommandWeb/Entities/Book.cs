using CommandWeb.Entities;
using CommandWeb.Repositorio;
using System.Text;

namespace CommandWeb.Entities
{

    public class Book
    {

        public int IdLivro;
        public string Name;
        public double Price;
        public int Qty;
        public List<Author> Authors;


        public Book()
        {
        }

        public Book(int id, string name, double price, int qty, List<Author> authors)
        {
            IdLivro = id;
            Name = name;
            Price = price;
            Qty = qty;
            Authors = authors;
            Authors = new List<Author>(authors);
        }

        public Book(int id, string name, List<Author> listaAuthors, double price)
        {
            IdLivro = id;
            Name = name;
            Price = price;
            Authors = listaAuthors;
        }

        public Book(int id, string name, List<Author> listaAuthors, double price, int qty) : this(id, name, listaAuthors, price)
        {
            Qty = qty;
        }
        public String getName()
        {
            return Name;
        }

        public List<Author> getAuthor()
        {
            return Authors;
        }

        public Double getPrice()
        {
            return Price;
        }

        public void setPrice(double price)
        {
            price = this.Price;
        }

        public int getQty()
        {
            return this.Qty;
        }

        public void setQty(int qty)
        {

            qty = this.Qty;

        }

        public StringBuilder getAuthorNames()
        {
            BookRepositorioSql repo = new BookRepositorioSql();
            StringBuilder sbAutores = new StringBuilder();

            List<Author> listadeAutores = new List<Author>();

            foreach (Book livro in repo.Books)
            {
                foreach (var autor in livro.Authors)
                {
                    if(listadeAutores.Find(a => a.Id == autor.Id) == null)
                    {
                        listadeAutores.Add(autor);
                        sbAutores.Append("\n" + autor.Name);
                    }
                }
            }
            return sbAutores;
        }

        public override string ToString()
        {
            return "\nBook: " + Name +
                    "\nPrice: " + Price +
                    "\nQuantity: " + Qty +
                    "\n--------------";

        }

    }

}

