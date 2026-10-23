using System.Data.SqlClient;

namespace Tech_Diary01.Data
{
    public class ConfiguracaoRepository
    {
        public SqlDataReader GetConfiguracao()
        {
            SqlConnection connection = Conection.GetConnection(); connection.Open();
            return new SqlCommand("SELECT TOP 1 school_name, email, phone, address, notifications_enabled FROM SYSTEM_SETTINGS ORDER BY id_setting;", connection)
                .ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public void SalvarConfiguracao(string nome, string email, string telefone, string endereco, bool notificacoes)
        {
            const string sql = @"
                IF EXISTS (SELECT 1 FROM SYSTEM_SETTINGS)
                    UPDATE SYSTEM_SETTINGS SET school_name = @school_name, email = @email,
                        phone = @phone, address = @address, notifications_enabled = @notifications_enabled;
                ELSE
                    INSERT INTO SYSTEM_SETTINGS (school_name, email, phone, address, notifications_enabled)
                    VALUES (@school_name, @email, @phone, @address, @notifications_enabled);";
            using (SqlConnection connection = Conection.GetConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@school_name", nome);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", telefone);
                command.Parameters.AddWithValue("@address", endereco);
                command.Parameters.AddWithValue("@notifications_enabled", notificacoes);
                connection.Open(); command.ExecuteNonQuery();
            }
        }
    }
}
