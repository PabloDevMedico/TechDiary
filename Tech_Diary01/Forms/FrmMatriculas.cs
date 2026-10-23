using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Tech_Diary01.Data;

namespace Tech_Diary01.Forms
{
    public class FrmMatriculas : Form
    {
        private readonly MatriculaRepository matriculaRepository = new MatriculaRepository();
        private readonly DataGridView dgvMatriculas = new DataGridView();
        private readonly TextBox txtPesquisar = new TextBox();

        public FrmMatriculas()
        {
            CriarTela();
        }

        private void CriarTela()
        {
            Text = "Tech Diary - Matrículas";
            ClientSize = new Size(1184, 661);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;

            Panel topo = new Panel { BackColor = Color.DodgerBlue, Dock = DockStyle.Top, Height = 60 };
            Controls.Add(topo);

            Panel menu = new Panel { BackColor = Color.DodgerBlue, Dock = DockStyle.Left, Width = 230 };
            Controls.Add(menu);
            CriarMenu(menu);

            Label titulo = CriarLabel("Matrículas", new Point(260, 85), new Size(400, 45), 24, Color.FromArgb(10, 29, 104), true);
            Controls.Add(titulo);
            Controls.Add(CriarLabel("Gerencie as matrículas dos alunos nos cursos da Tech Diary.", new Point(263, 130), new Size(600, 25), 11, Color.FromArgb(90, 105, 160), false));

            txtPesquisar.Location = new Point(263, 180);
            txtPesquisar.Size = new Size(410, 32);
            txtPesquisar.Font = new Font("Segoe UI", 11);
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            Controls.Add(txtPesquisar);

            Label lblNovaMatricula = CriarLabel("+  Nova Matrícula", new Point(972, 180), new Size(180, 38), 12, Color.White, true);
            lblNovaMatricula.BackColor = Color.DodgerBlue;
            lblNovaMatricula.Cursor = Cursors.Hand;
            lblNovaMatricula.TextAlign = ContentAlignment.MiddleCenter;
            lblNovaMatricula.Click += lblNovaMatricula_Click;
            Controls.Add(lblNovaMatricula);

            ConfigurarTabela();
            dgvMatriculas.Location = new Point(263, 235);
            dgvMatriculas.Size = new Size(889, 350);
            Controls.Add(dgvMatriculas);

            Load += FrmMatriculas_Load;
        }

        private void CriarMenu(Panel menu)
        {
            menu.Controls.Add(CriarLabel("Tech Diary", new Point(45, 20), new Size(160, 40), 20, Color.White, true));
            Label inicio = CriarMenuLabel("Início", 100, false);
            inicio.Click += delegate { Navegacao.Abrir(this, new Tech_Diary01.Data.Forms.FrmCurso()); };
            menu.Controls.Add(inicio);
            Label cursos = CriarMenuLabel("Cursos", 145, false);
            cursos.Click += delegate { Navegacao.Abrir(this, new FrmCursos()); };
            menu.Controls.Add(cursos);
            menu.Controls.Add(CriarMenuLabel("Matrículas", 190, true));
            Label presenca = CriarMenuLabel("Presença", 235, false);
            presenca.Click += delegate { Navegacao.Abrir(this, new FrmPresenca()); };
            menu.Controls.Add(presenca);
            Label relatorios = CriarMenuLabel("Relatórios", 280, false);
            relatorios.Click += delegate { Navegacao.Abrir(this, new FrmRelatorios()); };
            menu.Controls.Add(relatorios);
            Label configuracoes = CriarMenuLabel("Configurações", 325, false);
            configuracoes.Click += delegate { Navegacao.Abrir(this, new FrmConfiguracoes()); };
            menu.Controls.Add(configuracoes);
        }

        private Label CriarMenuLabel(string texto, int y, bool selecionado)
        {
            Label label = CriarLabel(IconeMenu(texto) + "   " + texto, new Point(12, y), new Size(205, 42), 13, Color.White, true);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Padding = new Padding(32, 0, 0, 0);
            label.Cursor = Cursors.Hand;
            if (selecionado) label.BackColor = Color.FromArgb(55, 145, 245);
            return label;
        }

        private static string IconeMenu(string texto)
        {
            if (texto == "Início") return "⌂";
            if (texto == "Cursos") return "▣";
            if (texto == "Matrículas") return "♙";
            if (texto == "Presença") return "◷";
            if (texto == "Relatórios") return "▤";
            return "⚙";
        }

        private static Label CriarLabel(string texto, Point local, Size tamanho, float fonte, Color cor, bool negrito)
        {
            return new Label
            {
                Text = texto, Location = local, Size = tamanho,
                Font = new Font("Segoe UI", fonte, negrito ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = cor
            };
        }

        private void ConfigurarTabela()
        {
            dgvMatriculas.AllowUserToAddRows = false;
            dgvMatriculas.AllowUserToDeleteRows = false;
            dgvMatriculas.ReadOnly = true;
            dgvMatriculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatriculas.MultiSelect = false;
            dgvMatriculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMatriculas.BackgroundColor = Color.White;
            dgvMatriculas.BorderStyle = BorderStyle.FixedSingle;
            dgvMatriculas.RowTemplate.Height = 45;
            dgvMatriculas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 255);
            dgvMatriculas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvMatriculas.EnableHeadersVisualStyles = false;
            dgvMatriculas.Columns.Add("colAluno", "Aluno");
            dgvMatriculas.Columns.Add("colCurso", "Curso");
            dgvMatriculas.Columns.Add("colData", "Data da Matrícula");
            dgvMatriculas.Columns.Add("colStatus", "Status");
            dgvMatriculas.Columns.Add("colEditar", "Editar");
            dgvMatriculas.Columns.Add("colExcluir", "Excluir");
            dgvMatriculas.CellClick += dgvMatriculas_CellContentClick;
        }

        private void FrmMatriculas_Load(object sender, EventArgs e)
        {
            CarregarMatriculas();
        }

        private void CarregarMatriculas(string pesquisa = "")
        {
            dgvMatriculas.Rows.Clear();
            using (SqlDataReader reader = matriculaRepository.GetMatriculas(pesquisa))
            {
                while (reader.Read())
                {
                    int linha = dgvMatriculas.Rows.Add(
                        reader["student_name"].ToString(),
                        reader["course_name"].ToString(),
                        Convert.ToDateTime(reader["date_registration"]).ToString("dd/MM/yyyy"),
                        TraduzirStatus(reader["status"].ToString()), "Editar", "Excluir");
                    dgvMatriculas.Rows[linha].Tag = new MatriculaLinha(
                        Convert.ToInt32(reader["id_registration"]),
                        Convert.ToInt32(reader["id_student"]),
                        Convert.ToInt32(reader["id_course"]),
                        Convert.ToDateTime(reader["date_registration"]),
                        reader["status"].ToString());
                }
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            CarregarMatriculas(txtPesquisar.Text.Trim());
        }

        private void lblNovaMatricula_Click(object sender, EventArgs e)
        {
            using (FrmNovaMatricula tela = new FrmNovaMatricula())
                if (tela.ShowDialog() == DialogResult.OK) CarregarMatriculas(txtPesquisar.Text.Trim());
        }

        private void dgvMatriculas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            MatriculaLinha matricula = (MatriculaLinha)dgvMatriculas.Rows[e.RowIndex].Tag;
            string coluna = dgvMatriculas.Columns[e.ColumnIndex].Name;

            if (coluna == "colEditar")
            {
                using (FrmNovaMatricula tela = new FrmNovaMatricula(matricula.Id, matricula.IdAluno,
                    matricula.IdCurso, matricula.Data, matricula.Status))
                    if (tela.ShowDialog() == DialogResult.OK) CarregarMatriculas(txtPesquisar.Text.Trim());
                return;
            }

            if (coluna == "colExcluir" && MessageBox.Show("Deseja excluir esta matrícula?", "Excluir matrícula", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try { matriculaRepository.ExcluirMatricula(matricula.Id); CarregarMatriculas(txtPesquisar.Text.Trim()); }
                catch (SqlException ex) { MessageBox.Show(ex.Message, "Matrícula não excluída"); }
            }
        }

        private static string TraduzirStatus(string status)
        {
            if (status == "Active") return "Ativa";
            if (status == "Pending") return "Pendente";
            if (status == "Cancelled") return "Cancelada";
            return status;
        }

        private class MatriculaLinha
        {
            public int Id { get; private set; }
            public int IdAluno { get; private set; }
            public int IdCurso { get; private set; }
            public DateTime Data { get; private set; }
            public string Status { get; private set; }
            public MatriculaLinha(int id, int idAluno, int idCurso, DateTime data, string status)
            { Id = id; IdAluno = idAluno; IdCurso = idCurso; Data = data; Status = status; }
        }
    }
}
