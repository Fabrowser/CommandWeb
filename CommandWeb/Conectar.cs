using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandWeb
{
    internal class Conectar
    {

        SqlConnectionStringBuilder builder;

        public SqlConnectionStringBuilder ConexaoDb()
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(localdb)\\MSSQLLocalDB";
            builder.UserID = "DESKTOP-5C8JRU2\fabri";
            builder.Password = "";
            builder.InitialCatalog = "Command";
            builder.IntegratedSecurity = true;

            return builder;

        }
    }
}