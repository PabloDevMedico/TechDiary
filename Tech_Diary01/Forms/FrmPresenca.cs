using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Tech_Diary01.Data;

namespace Tech_Diary01.Forms
{
    public class FrmPresenca : Form
    {
        private readonly PresencaRepository repositorio = new PresencaRepository();
        private readonly ComboBox cboCurso = new ComboBox();
        private readonly DateTimePicker dtpData = new DateTimePicker();
        private readonly DataGridView dgvPresencas = new DataGridView();

        public FrmPresenca() { CriarTela(); }

        private void CriarTela()
        {
            Text = "Tech Diary - Presença"; ClientSize = new Size(1184, 661); BackColor = Color.White; StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(new Panel { BackColor = Color.DodgerBlue, Dock = DockStyle.Top, Height = 60 });
            Panel menu = new Panel { BackColor = Color.DodgerBlue, Dock = DockStyle.Left, Width = 230 }; Controls.Add(menu); CriarMenu(menu);
            Controls.Add(Label("Presença", 260, 85, 300, 43, 24, Color.FromArgb(10, 29, 104), true));
            Controls.Add(Label("Registre a presença dos alunos por curso e data.", 263, 130, 600, 25, 11, Color.FromArgb(90, 105, 160), false));
            Controls.Add(Label("Curso", 263, 180, 70, 25, 10, Color.FromArgb(40, 50, 80), true));
            cboCurso.Location = new Point(320, 177);
            cboCurso.Size = new Size(330, 27);

            cboCurso.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboCurso.DropDownStyle = ComboBoxStyle.DropDownList;

            cboCurso.RightToLeft = RightToLeft.No;
            cboCurso.FlatStyle = FlatStyle.Standard;

            Controls.Add(cboCurso);
            Controls.Add(Label("Data", 675, 180, 50, 25, 10, Color.FromArgb(40, 50, 80), true));
            dtpData.Location = new Point(725, 177); dtpData.Format = DateTimePickerFormat.Short; dtpData.Size = new Size(120, 27); Controls.Add(dtpData);
            Label carregar = Botao("Carregar alunos", 870, 174, 135); carregar.Click += delegate { CarregarAlunos(); }; Controls.Add(carregar);
            Label salvar = Botao("Salvar presença", 1015, 174, 137); salvar.Click += lblSalvar_Click; Controls.Add(salvar);
            ConfigurarTabela(); dgvPresencas.Location = new Point(263, 230); dgvPresencas.Size = new Size(889, 355); Controls.Add(dgvPresencas);
            Load += FrmPresenca_Load;
        }
       
        private void CriarMenu(Panel menu)
        {
            menu.Controls.Add(Label("Tech Diary", 45, 20, 160, 40, 20, Color.White, true));
            Label inicio = Menu("Início", 100, false); inicio.Click += delegate { Navegacao.Abrir(this, new Tech_Diary01.Data.Forms.FrmCurso()); }; menu.Controls.Add(inicio);
            Label cursos = Menu("Cursos", 145, false); cursos.Click += delegate { Navegacao.Abrir(this, new FrmCursos()); }; menu.Controls.Add(cursos);
            Label matriculas = Menu("Matrículas", 190, false); matriculas.Click += delegate { Navegacao.Abrir(this, new FrmMatriculas()); }; menu.Controls.Add(matriculas);
            menu.Controls.Add(Menu("Presença", 235, true));
            Label relatorios = Menu("Relatórios", 280, false); relatorios.Click += delegate { Navegacao.Abrir(this, new FrmRelatorios()); }; menu.Controls.Add(relatorios);
            Label configuracoes = Menu("Configurações", 325, false); configuracoes.Click += delegate { Navegacao.Abrir(this, new FrmConfiguracoes()); }; menu.Controls.Add(configuracoes);
        }

        private Label Menu(string texto, int y, bool ativo)
        { Label l = Label(IconeMenu(texto) + "   " + texto, 12, y, 205, 42, 13, Color.White, true); l.Padding = new Padding(22, 0, 0, 0); l.TextAlign = ContentAlignment.MiddleLeft; l.Cursor = Cursors.Hand; if (ativo) l.BackColor = Color.FromArgb(55, 145, 245); return l; }
        private static string IconeMenu(string texto) { if (texto == "Início") return "⌂"; if (texto == "Cursos") return "▣"; if (texto == "Matrículas") return "♙"; if (texto == "Presença") return "◷"; if (texto == "Relatórios") return "▤"; return "⚙"; }
        private static Label Label(string texto, int x, int y, int w, int h, float fonte, Color cor, bool negrito)
        { return new Label { Text = texto, Location = new Point(x, y), Size = new Size(w, h), ForeColor = cor, Font = new Font("Segoe UI", fonte, negrito ? FontStyle.Bold : FontStyle.Regular) }; }
        private static Label Botao(string texto, int x, int y, int w)
        { Label l = Label(texto, x, y, w, 33, 10, Color.White, true); l.BackColor = Color.DodgerBlue; l.TextAlign = ContentAlignment.MiddleCenter; l.Cursor = Cursors.Hand; return l; }

        private void ConfigurarTabela()
        {
            dgvPresencas.AllowUserToAddRows = false; dgvPresencas.AllowUserToDeleteRows = false; dgvPresencas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPresencas.RowTemplate.Height = 42; dgvPresencas.BackgroundColor = Color.White; dgvPresencas.EnableHeadersVisualStyles = false;
            dgvPresencas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 255); dgvPresencas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvPresencas.Columns.Add("colAluno", "Aluno");
            DataGridViewComboBoxColumn status = new DataGridViewComboBoxColumn { Name = "colStatus", HeaderText = "Status", FlatStyle = FlatStyle.Flat };
            status.Items.AddRange("Present", "Absent", "Certificate"); dgvPresencas.Columns.Add(status);
        }

        private void FrmPresenca_Load(object sender, EventArgs e)
        {
            using (SqlDataReader reader = repositorio.GetCursosAtivos())
                while (reader.Read()) cboCurso.Items.Add(new Item(Convert.ToInt32(reader["id_course"]), reader["name"].ToString()));
            if (cboCurso.Items.Count > 0) cboCurso.SelectedIndex = 0;
        }

        private void CarregarAlunos()
        {
            dgvPresencas.Rows.Clear(); if (cboCurso.SelectedItem == null) return;
            int curso = ((Item)cboCurso.SelectedItem).Id;
            using (SqlDataReader reader = repositorio.GetAlunosDoCurso(curso, dtpData.Value))
                while (reader.Read())
                {
                    string valor = reader["presence_status"].ToString(); if (valor == "NotRegistered") valor = "Present";
                    int linha = dgvPresencas.Rows.Add(reader["student_name"].ToString(), valor);
                    dgvPresencas.Rows[linha].Tag = Convert.ToInt32(reader["id_registration"]);
                }
        }

        private void lblSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow linha in dgvPresencas.Rows)
                    if (!linha.IsNewRow) repositorio.SalvarPresenca(Convert.ToInt32(linha.Tag), dtpData.Value, linha.Cells["colStatus"].Value.ToString());
                MessageBox.Show("Presenças salvas com sucesso.", "Tech Diary");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Não foi possível salvar"); }
        }

        private class Item { public int Id { get; private set; } public string Nome { get; private set; } public Item(int id, string nome) { Id = id; Nome = nome; } public override string ToString() { return Nome; } }
    }
}
