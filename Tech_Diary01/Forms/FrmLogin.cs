using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tech_Diary01.Data;

namespace Tech_Diary01.Data.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Preencha o usuário e a senha.");
                return;
            }

            using (SqlConnection connection = Conection.GetConnection())
            {
                try
                {
                    connection.Open();

                    string sql = @"
                        SELECT id_admin, name, email
                        FROM dbo.SUPERVISOR
                        WHERE email = @email
                        AND password = @password
                        AND status = 'Active'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Login realizado com sucesso!");

                                FrmCurso principal = new FrmCurso();
                                principal.Show();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usuário ou senha inválidos.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao realizar login: " + ex.Message);
                }
            }
        }
    }
}
