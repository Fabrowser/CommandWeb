namespace CommandWeb.Entities
{
    public class Author
    {

        public string Name;
        public string Email;
        public string Gender;

        public Author(string name, string email, string gender)
        {
            Name = name;
            Email = email;
            Gender = gender;
        }

        public override string ToString()
        {
            return "Name: " + this.Name +
                    "\nEmail: " + this.Email +
                    "\nGender: " + this.Gender +
                    "\n-------------------------\n";

        }
    }
}
