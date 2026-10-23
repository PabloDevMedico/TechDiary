using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech_Diary01.Data
{
    public class GraficoRepository
    {
        public SqlDataReader GetCursosMaisMatriculas()
        {
            SqlConnection connection = Conection.GetConnection();
            connection.Open();

            string sql = @"
        SELECT
            c.name AS Curso,
            COUNT(r.id_registration) AS Matriculas
        FROM COURSE c
        LEFT JOIN REGISTRATION r
            ON r.id_course = c.id_course
        GROUP BY c.id_course, c.name
        ORDER BY Matriculas DESC";

            SqlCommand command = new SqlCommand(sql, connection);

            return command.ExecuteReader(
                System.Data.CommandBehavior.CloseConnection
            );
        }
    }
}
