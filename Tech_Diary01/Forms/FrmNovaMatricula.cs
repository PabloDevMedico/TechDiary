using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Tech_Diary01.Data;

namespace Tech_Diary01.Forms
{
    public class FrmNovaMatricula : Form
    {
        private readonly MatriculaRepository matriculaRepository = new MatriculaRepository();
        private readonly int? idMatricula;
        private readonly int? alunoSelecionado;
        private readonly int? cursoSelecionado;
        private readonly DateTime? dataSelecionada;
        private readonly string statusSelecionado;
        private ComboBox cboAluno;
        private ComboBox cboCurso;
        private ComboBox cboStatus;
        private DateTimePicker dtpData;

        public FrmNovaMatricula()
        {
            CriarTela();
        }

        public FrmNovaMatricula(int id, int idAluno, int idCurso, DateTime data, string status) : this()
        {
            idMatricula = id;
            alunoSelecionado = idAluno;
            cursoSelecionado = idCurso;
            dataSelecionada = data;
            statusSelecionado = status;
            Text = "Tech Diary - Editar matrícula";
        }

        private void CriarTela()
        {
            Text = "Tech Diary - Nova matrícula";
            ClientSize = new Size(510, 360);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            BackColor = Color.White;

            Controls.Add(CriarLabel("Cadastro de matrícula", new Point(28, 25), new Size(380, 38), 18, Color.FromArgb(10, 29, 104), true));
            Controls.Add(CriarLabel("Aluno", new Point(28, 90), new Size(165, 25), 10, Color.FromArgb(40, 50, 80), true));
            Controls.Add(CriarLabel("Curso", new Point(28, 140), new Size(165, 25), 10, Color.FromArgb(40, 50, 80), true));
            Controls.Add(CriarLabel("Data da matrícula", new Point(28, 190), new Size(165, 25), 10, Color.FromArgb(40, 50, 80), true));
            Controls.Add(CriarLabel("Status", new Point(28, 240), new Size(165, 25), 10, Color.FromArgb(40, 50, 80), true));

            cboAluno = new ComboBox { Location = new Point(205, 86), Size = new Size(175, 26), DropDownStyle = ComboBoxStyle.DropDownList };
            cboCurso = new ComboBox { Location = new Point(205, 136), Size = new Size(270, 26), DropDownStyle = ComboBoxStyle.DropDownList };
            dtpData = new DateTimePicker { Location = new Point(205, 186), Size = new Size(270, 26), Format = DateTimePickerFormat.Short };
            cboStatus = new ComboBox { Location = new Point(205, 236), Size = new Size(270, 26), DropDownStyle = ComboBoxStyle.DropDownList };
            cboStatus.Items.AddRange(new object[] { "Ativa", "Pendente", "Cancelada" });
            cboStatus.SelectedIndex = 0;
            Button btnNovoAluno = new Button
            {
                Text = "+ Novo aluno",
                Location = new Point(385, 86),
                Size = new Size(90, 26),
                BackColor = Color.FromArgb(240, 245, 255),
                ForeColor = Color.FromArgb(30, 70, 150),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8, FontStyle.Bold)
            };
            btnNovoAluno.FlatAppearance.BorderColor = Color.FromArgb(180, 200, 230);
            btnNovoAluno.Click += BtnNovoAluno_Click;

            Controls.Add(cboAluno); Controls.Add(cboCurso); Controls.Add(dtpData); Controls.Add(cboStatus); Controls.Add(btnNovoAluno);

            Label lblSalvar = CriarLabel("Salvar", new Point(287, 300), new Size(88, 32), 10, Color.White, true);
            lblSalvar.BackColor = Color.DodgerBlue; lblSalvar.TextAlign = ContentAlignment.MiddleCenter; lblSalvar.Cursor = Cursors.Hand;
            lblSalvar.Click += lblSalvar_Click;
            Controls.Add(lblSalvar);
            Label lblCancelar = CriarLabel("Cancelar", new Point(387, 300), new Size(88, 32), 10, Color.FromArgb(30, 70, 150), true);
            lblCancelar.BorderStyle = BorderStyle.FixedSingle; lblCancelar.TextAlign = ContentAlignment.MiddleCenter; lblCancelar.Cursor = Cursors.Hand;
            lblCancelar.Click += delegate { DialogResult = DialogResult.Cancel; Close(); };
            Controls.Add(lblCancelar);

            Load += FrmNovaMatricula_Load;
        }

        private static Label CriarLabel(string texto, Point local, Size tamanho, float fonte, Color cor, bool negrito)
        {
            return new Label { Text = texto, Location = local, Size = tamanho, ForeColor = cor,
                Font = new Font("Segoe UI", fonte, negrito ? FontStyle.Bold : FontStyle.Regular) };
        }

        private void FrmNovaMatricula_Load(object sender, EventArgs e)
        {
            CarregarAlunos();
            CarregarCursos();
            if (alunoSelecionado.HasValue) SelecionarItem(cboAluno, alunoSelecionado.Value);
            if (cursoSelecionado.HasValue) SelecionarItem(cboCurso, cursoSelecionado.Value);
            if (dataSelecionada.HasValue) dtpData.Value = dataSelecionada.Value;
            if (!string.IsNullOrEmpty(statusSelecionado)) cboStatus.SelectedItem = TraduzirStatus(statusSelecionado);
        }

        private void CarregarAlunos()
        {
            cboAluno.Items.Clear();
            cboAluno.DisplayMember = "Nome"; cboAluno.ValueMember = "Id";
            using (SqlDataReader reader = matriculaRepository.GetAlunosAtivos())
                while (reader.Read()) cboAluno.Items.Add(new ItemCombo(Convert.ToInt32(reader["id_student"]), reader["name"].ToString()));
            cboAluno.DisplayMember = "Nome"; cboAluno.ValueMember = "Id";
            if (cboAluno.Items.Count > 0) cboAluno.SelectedIndex = 0;
        }

        private void CarregarCursos()
        {
            cboCurso.Items.Clear();
            using (SqlDataReader reader = matriculaRepository.GetCursosAtivos())
                while (reader.Read()) cboCurso.Items.Add(new ItemCombo(Convert.ToInt32(reader["id_course"]), reader["name"].ToString()));
            if (cboCurso.Items.Count > 0) cboCurso.SelectedIndex = 0;
        }

        private void BtnNovoAluno_Click(object sender, EventArgs e)
        {
            using (FrmNovoAluno tela = new FrmNovoAluno())
            {
                if (tela.ShowDialog(this) == DialogResult.OK)
                {
                    CarregarAlunos();
                    SelecionarItem(cboAluno, tela.IdAlunoCriado);
                }
            }
        }

        private void lblSalvar_Click(object sender, EventArgs e)
        {
            if (cboAluno.SelectedItem == null || cboCurso.SelectedItem == null)
            {
                MessageBox.Show("Cadastre ao menos um aluno ativo e um curso ativo antes de realizar a matrícula.", "Dados necessários");
                return;
            }
            try
            {
                int aluno = ((ItemCombo)cboAluno.SelectedItem).Id;
                int curso = ((ItemCombo)cboCurso.SelectedItem).Id;
                string status = ConverterStatus(cboStatus.Text);
                if (idMatricula.HasValue)
                    matriculaRepository.AtualizarMatricula(idMatricula.Value, aluno, curso, dtpData.Value, status);
                else
                    matriculaRepository.InserirMatricula(aluno, curso, dtpData.Value, status);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    MessageBox.Show(
                        "Este aluno já está matriculado neste curso. Para matricular o mesmo aluno em outro curso, selecione outro curso.",
                        "Matrícula já existente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Não foi possível salvar a matrícula");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não foi possível salvar a matrícula");
            }
        }

        private static string ConverterStatus(string status)
        {
            if (status == "Ativa") return "Active";
            if (status == "Pendente") return "Pending";
            return "Cancelled";
        }
        private static string TraduzirStatus(string status)
        {
            if (status == "Active") return "Ativa";
            if (status == "Pending") return "Pendente";
            return "Cancelada";
        }

        private static void SelecionarItem(ComboBox combo, int id)
        {
            for (int indice = 0; indice < combo.Items.Count; indice++)
            {
                if (((ItemCombo)combo.Items[indice]).Id == id)
                {
                    combo.SelectedIndex = indice;
                    return;
                }
            }
        }

        private class ItemCombo
        {
            public int Id { get; private set; }
            public string Nome { get; private set; }
            public ItemCombo(int id, string nome) { Id = id; Nome = nome; }
            public override string ToString() { return Nome; }
        }
    }
}
