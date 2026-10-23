using System;
using System.Data.SqlClient;

namespace Tech_Diary01.Data
{
    public class RelatorioRepository
    {
        public SqlDataReader GetMatriculasPorCurso()
        {
            return ExecutarLeitura(@"
                SELECT c.name AS course_name, COUNT(r.id_registration) AS total_registrations
                FROM COURSE c LEFT JOIN REGISTRATION r ON r.id_course = c.id_course
                GROUP BY c.name ORDER BY total_registrations DESC, c.name;");
        }

        public SqlDataReader GetResumoPresencas()
        {
            return ExecutarLeitura(@"
                SELECT c.name AS course_name, COUNT(DISTINCT r.id_registration) AS total_registrations,
                       SUM(CASE WHEN p.status = 'Present' THEN 1 ELSE 0 END) AS present_count,
                       SUM(CASE WHEN p.status = 'Absent' THEN 1 ELSE 0 END) AS absent_count
                FROM COURSE c
                LEFT JOIN REGISTRATION r ON r.id_course = c.id_course
                LEFT JOIN PRESENCE p ON p.id_registration = r.id_registration
                GROUP BY c.name ORDER BY c.name;");
        }

        public int GetTotalCursos() { return Convert.ToInt32(ExecutarEscalar("SELECT COUNT(*) FROM COURSE;")); }
        public int GetTotalMatriculasAtivas() { return Convert.ToInt32(ExecutarEscalar("SELECT COUNT(*) FROM REGISTRATION WHERE status = 'Active';")); }
        public decimal GetTaxaPresenca()
        {
            object resultado = ExecutarEscalar(@"SELECT CASE WHEN COUNT(*) = 0 THEN 0 ELSE
                SUM(CASE WHEN status = 'Present' THEN 1 ELSE 0 END) * 100.0 / COUNT(*) END FROM PRESENCE;");
            return Convert.ToDecimal(resultado);
        }

        private static SqlDataReader ExecutarLeitura(string sql)
        {
            SqlConnection connection = Conection.GetConnection(); connection.Open();
            return new SqlCommand(sql, connection).ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        private static object ExecutarEscalar(string sql)
        {
            using (SqlConnection connection = Conection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            { connection.Open(); return command.ExecuteScalar(); }
        }
    }
}
