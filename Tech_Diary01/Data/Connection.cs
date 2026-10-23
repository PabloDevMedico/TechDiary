using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech_Diary01.Data
{

    public class Conection
    {
        private static readonly string connectionString =
            @"Server=DESKTOP-UCQEOT0\SQLEXPRESS;
          Database=SistemaEscolar;
          Trusted_Connection=True;
          TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}


