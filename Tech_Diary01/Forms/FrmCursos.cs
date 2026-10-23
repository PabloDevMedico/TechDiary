using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Tech_Diary01.Data;

namespace Tech_Diary01.Forms
{
    public partial class FrmCursos : Form
    {
        private readonly CursoRepository cursoRepository;

        public FrmCursos()
        {
            InitializeComponent();
            cursoRepository = new CursoRepository();
            ConfigurarNavegacao();
        }

        private void ConfigurarNavegacao()
        {
            lblInicio.Click += delegate { Navegacao.Abrir(this, new Tech_Diary01.Data.Forms.FrmCurso()); };
            lblMatriculas.Click += delegate { Navegacao.Abrir(this, new FrmMatriculas()); };
            lblPresenca.Click += delegate { Navegacao.Abrir(this, new FrmPresenca()); };
            lblRelatorios.Click += delegate { Navegacao.Abrir(this, new FrmRelatorios()); };
            lblConfiguracoes.Click += delegate { Navegacao.Abrir(this, new FrmConfiguracoes()); };
            lblInicio.Cursor = lblMatriculas.Cursor = lblPresenca.Cursor = lblRelatorios.Cursor = lblConfiguracoes.Cursor = Cursors.Hand;
        }

        private void FrmCursos_Load(object sender, EventArgs e)
        {
            dgvCursos.AllowUserToAddRows = false;
            dgvCursos.AutoGenerateColumns = false;
            dgvCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCursos.MultiSelect = false;
            CarregarCursos();
        }

        private void CarregarCursos(string pesquisa = "")
        {
            dgvCursos.Rows.Clear();

            using (SqlDataReader reader = cursoRepository.GetCursos(pesquisa))
            {
                while (reader.Read())
                {
                    int linha = dgvCursos.Rows.Add();
                    DataGridViewRow curso = dgvCursos.Rows[linha];

                    curso.Tag = Convert.ToInt32(reader["id_course"]);
                    curso.Cells["colNomeCurso"].Value = reader["name"].ToString();
                    curso.Cells["colCargaHoraria"].Value =
                        Convert.ToInt32(reader["workload_hours"]) + " horas";
                    curso.Cells["colTurno"].Value = TraduzirTurno(reader["shift"].ToString());
                    curso.Cells["colStatus"].Value = TraduzirStatus(reader["status"].ToString());
                }
            }
        }

        private static string TraduzirTurno(string turno)
        {
            if (turno == "Morning") return "Manhã";
            if (turno == "Afternoon") return "Tarde";
            if (turno == "Evening") return "Noite";
            return turno;
        }

        private static string TraduzirStatus(string status)
        {
            if (status == "Active") return "Ativo";
            if (status == "Inactive") return "Inativo";
            return status;
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            CarregarCursos(txtPesquisar.Text.Trim());
        }

        private void lblNovoCurso_Click(object sender, EventArgs e)
        {
            using (FrmNovoCurso formulario = new FrmNovoCurso())
            {
                if (formulario.ShowDialog() == DialogResult.OK)
                    CarregarCursos(txtPesquisar.Text.Trim());
            }
        }

        private void dgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int idCurso = Convert.ToInt32(dgvCursos.Rows[e.RowIndex].Tag);
            string coluna = dgvCursos.Columns[e.ColumnIndex].Name;

            if (coluna == "colEditar")
            {
                using (FrmNovoCurso formulario = new FrmNovoCurso(
                    idCurso,
                    dgvCursos.Rows[e.RowIndex].Cells["colNomeCurso"].Value.ToString(),
                    dgvCursos.Rows[e.RowIndex].Cells["colCargaHoraria"].Value.ToString(),
                    dgvCursos.Rows[e.RowIndex].Cells["colTurno"].Value.ToString(),
                    dgvCursos.Rows[e.RowIndex].Cells["colStatus"].Value.ToString()))
                {
                    if (formulario.ShowDialog() == DialogResult.OK)
                        CarregarCursos(txtPesquisar.Text.Trim());
                }
            }

            if (coluna == "colExcluir" && MessageBox.Show(
                "Deseja realmente excluir este curso?", "Excluir curso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    cursoRepository.ExcluirCurso(idCurso);
                    CarregarCursos(txtPesquisar.Text.Trim());
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Curso não excluído",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
