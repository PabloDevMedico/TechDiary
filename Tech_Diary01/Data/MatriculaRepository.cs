using System;
using System.Data;
using System.Data.SqlClient;

namespace Tech_Diary01.Data
{
    public class MatriculaRepository
    {
        public SqlDataReader GetMatriculas(string pesquisa = "")
        {
            SqlConnection connection = Conection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT r.id_registration, r.id_student, r.id_course,
                       s.name AS student_name, c.name AS course_name,
                       r.date_registration, r.status
                FROM REGISTRATION r
                INNER JOIN STUDENT s ON s.id_student = r.id_student
                INNER JOIN COURSE c ON c.id_course = r.id_course
                WHERE s.name LIKE @pesquisa
                   OR c.name LIKE @pesquisa
                   OR r.status LIKE @pesquisa
                ORDER BY r.date_registration DESC, s.name;";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@pesquisa", SqlDbType.NVarChar, 155)
                .Value = "%" + pesquisa + "%";
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader GetAlunosAtivos()
        {
            return ExecutarConsulta("SELECT id_student, name FROM STUDENT WHERE status = 'Active' ORDER BY name;");
        }

        public SqlDataReader GetCursosAtivos()
        {
            return ExecutarConsulta("SELECT id_course, name FROM COURSE WHERE status = 'Active' ORDER BY name;");
        }

        public int InserirAluno(string nome, DateTime dataNascimento, string status)
        {
            const string sql = @"
                INSERT INTO STUDENT (id_admin, name, date_birthday, date_register, status)
                OUTPUT INSERTED.id_student
                SELECT TOP 1
                       id_admin,
                       @name,
                       @date_birthday,
                       CAST(GETDATE() AS DATE),
                       @status
                  FROM SUPERVISOR
                 WHERE status = 'Active'
                 ORDER BY id_admin;";

            using (SqlConnection connection = Conection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@name", SqlDbType.NVarChar, 155).Value = nome;
                command.Parameters.Add("@date_birthday", SqlDbType.Date).Value = dataNascimento.Date;
                command.Parameters.Add("@status", SqlDbType.NVarChar, 18).Value = status;
                connection.Open();

                object resultado = command.ExecuteScalar();
                if (resultado == null || resultado == DBNull.Value)
                    throw new InvalidOperationException("Não existe um supervisor ativo para cadastrar o aluno.");

                return Convert.ToInt32(resultado);
            }
        }

        public void InserirMatricula(int idAluno, int idCurso, DateTime dataMatricula, string status)
        {
            const string sql = @"
                INSERT INTO REGISTRATION (id_student, id_course, date_registration, status)
                VALUES (@id_student, @id_course, @date_registration, @status);";
            ExecutarAlteracao(sql, null, idAluno, idCurso, dataMatricula, status);
        }

        public void AtualizarMatricula(int idMatricula, int idAluno, int idCurso,
            DateTime dataMatricula, string status)
        {
            const string sql = @"
                UPDATE REGISTRATION
                   SET id_student = @id_student,
                       id_course = @id_course,
                       date_registration = @date_registration,
                       status = @status
                 WHERE id_registration = @id_registration;";
            ExecutarAlteracao(sql, idMatricula, idAluno, idCurso, dataMatricula, status);
        }

        public void ExcluirMatricula(int idMatricula)
        {
            const string sql = "DELETE FROM REGISTRATION WHERE id_registration = @id_registration;";
            using (SqlConnection connection = Conection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id_registration", idMatricula);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static SqlDataReader ExecutarConsulta(string sql)
        {
            SqlConnection connection = Conection.GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        private static void ExecutarAlteracao(string sql, int? idMatricula, int idAluno,
            int idCurso, DateTime dataMatricula, string status)
        {
            using (SqlConnection connection = Conection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (idMatricula.HasValue)
                    command.Parameters.AddWithValue("@id_registration", idMatricula.Value);
                command.Parameters.AddWithValue("@id_student", idAluno);
                command.Parameters.AddWithValue("@id_course", idCurso);
                command.Parameters.AddWithValue("@date_registration", dataMatricula.Date);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
