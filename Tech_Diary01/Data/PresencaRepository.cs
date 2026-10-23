using System;
using System.Data;
using System.Data.SqlClient;

namespace Tech_Diary01.Data
{
    public class PresencaRepository
    {
        public SqlDataReader GetCursosAtivos()
        {
            return ExecutarLeitura("SELECT id_course, name FROM COURSE WHERE status = 'Active' ORDER BY name;");
        }

        public SqlDataReader GetAlunosDoCurso(int idCurso, DateTime data)
        {
            SqlConnection connection = Conection.GetConnection();
            connection.Open();
            const string sql = @"
                SELECT r.id_registration, s.name AS student_name,
                       ISNULL(p.status, 'NotRegistered') AS presence_status
                  FROM REGISTRATION r
                  INNER JOIN STUDENT s ON s.id_student = r.id_student
                  LEFT JOIN PRESENCE p ON p.id_registration = r.id_registration
                                      AND p.date_presence = @date_presence
                 WHERE r.id_course = @id_course AND r.status = 'Active'
                 ORDER BY s.name;";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id_course", idCurso);
            command.Parameters.AddWithValue("@date_presence", data.Date);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void SalvarPresenca(int idMatricula, DateTime data, string status)
        {
            const string sql = @"
                IF EXISTS (SELECT 1 FROM PRESENCE WHERE id_registration = @id_registration AND date_presence = @date_presence)
                    UPDATE PRESENCE SET status = @status
                     WHERE id_registration = @id_registration AND date_presence = @date_presence;
                ELSE
                    INSERT INTO PRESENCE (id_registration, date_presence, status)
                    VALUES (@id_registration, @date_presence, @status);";
            using (SqlConnection connection = Conection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id_registration", idMatricula);
                command.Parameters.AddWithValue("@date_presence", data.Date);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static SqlDataReader ExecutarLeitura(string sql)
        {
            SqlConnection connection = Conection.GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
