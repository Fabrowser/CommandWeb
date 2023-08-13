using CommandWeb.Entities;
using System.Text;

namespace CommandWeb.Entities
{

    public class Book
    {

        public int IdLivro;
        public string Name;
        public List<Author> Authors = new List<Author>();
        public double Price;
        public int Qty;



        public Book()
        {
        }

        public Book(int id, string name, double price, int qty)
        {
            IdLivro = id;
            Name = name;
            Price = price;
            Qty = qty;
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

        public String getAuthorNames()
        {
            StringBuilder sbAutores = new StringBuilder();
            foreach (Author autor in Authors)
            {


                sbAutores.Append("name: " + autor.Name + "\n" +
                    "email: " + autor.Email + "\n" +
                    "Gender: " + autor.Gender + "\n---------------\n");

            }
            return sbAutores.ToString();
        }

        public override string ToString()
        {
            return "\nBook: " + Name +
                    "\nPrice: " + Price +
                    "\nQuantity: " + Qty +
                    "\n-----------------------------\n";

        }

    }

}

