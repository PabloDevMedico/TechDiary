using System.Data;
using System.Data.SqlClient;

namespace Tech_Diary01.Data
{
    public class CursoRepository
    {
        public SqlDataReader GetCursos(string pesquisa = "")
        {
            SqlConnection connection = Conection.GetConnection();
            connection.Open();

            const string sql = @"
                SELECT id_course, id_admin, id_teacher, name, workload_hours,
                       status, price, shift
                FROM COURSE
                WHERE name LIKE @pesquisa
                ORDER BY name;";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add("@pesquisa", SqlDbType.NVarChar, 155)
                .Value = "%" + pesquisa + "%";

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void InserirCurso(int idAdmin, int idProfessor, string nome,
            int cargaHoraria, decimal preco, string turno, string status)
        {
            const string sql = @"
                INSERT INTO COURSE
                    (id_admin, id_teacher, name, workload_hours, price, shift, status)
                VALUES
                    (@id_admin, @id_teacher, @name, @workload_hours, @price, @shift, @status);";

            ExecutarComando(sql, idAdmin, idProfessor, nome, cargaHoraria, preco, turno, status);
        }

        public void AtualizarCurso(int idCurso, string nome, int cargaHoraria,
            string turno, string status)
        {
            const string sql = @"
                UPDATE COURSE
                   SET name = @name,
                       workload_hours = @workload_hours,
                       shift = @shift,
                       status = @status
                 WHERE id_course = @id_course;";

            using (SqlConnection connection = Conection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id_course", idCurso);
                command.Parameters.AddWithValue("@name", nome);
                command.Parameters.AddWithValue("@workload_hours", cargaHoraria);
                command.Parameters.AddWithValue("@shift", turno);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ExcluirCurso(int idCurso)
        {
            const string sql = @"
                IF EXISTS (SELECT 1 FROM REGISTRATION WHERE id_course = @id_course)
                    THROW 50001, 'Não é possível excluir um curso que possui matrículas.', 1;

                DELETE FROM COURSE WHERE id_course = @id_course;";

            using (SqlConnection connection = Conection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id_course", idCurso);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void ExecutarComando(string sql, int idAdmin, int idProfessor,
            string nome, int cargaHoraria, decimal preco, string turno, string status)
        {
            using (SqlConnection connection = Conection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id_admin", idAdmin);
                command.Parameters.AddWithValue("@id_teacher", idProfessor);
                command.Parameters.AddWithValue("@name", nome);
                command.Parameters.AddWithValue("@workload_hours", cargaHoraria);
                command.Parameters.AddWithValue("@price", preco);
                command.Parameters.AddWithValue("@shift", turno);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
