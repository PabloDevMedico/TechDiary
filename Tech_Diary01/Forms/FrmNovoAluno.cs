using System;
using System.Drawing;
using System.Windows.Forms;
using Tech_Diary01.Data;

namespace Tech_Diary01.Forms
{
    public class FrmNovoAluno : Form
    {
        private readonly MatriculaRepository matriculaRepository = new MatriculaRepository();
        private TextBox txtNome;
        private DateTimePicker dtpNascimento;
        private ComboBox cboStatus;

        public int IdAlunoCriado { get; private set; }

        public FrmNovoAluno()
        {
            CriarTela();
        }

        private void CriarTela()
        {
            Text = "Tech Diary - Novo aluno";
            ClientSize = new Size(510, 300);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;

            Controls.Add(CriarLabel("Cadastro de aluno", new Point(28, 25), new Size(380, 38), 18, Color.FromArgb(10, 29, 104), true));
            Controls.Add(CriarLabel("Nome", new Point(28, 90), new Size(165, 25), 10, Color.FromArgb(40, 50, 80), true));
            Controls.Add(CriarLabel("Data de nascimento", new Point(28, 140), new Size(165, 25), 10, Color.FromArgb(40, 50, 80), true));
            Controls.Add(CriarLabel("Status", new Point(28, 190), new Size(165, 25), 10, Color.FromArgb(40, 50, 80), true));

            txtNome = new TextBox
            {
                Location = new Point(205, 86),
                Size = new Size(270, 26),
                Font = new Font("Segoe UI", 10)
            };

            dtpNascimento = new DateTimePicker
            {
                Location = new Point(205, 136),
                Size = new Size(270, 26),
                Format = DateTimePickerFormat.Short,
                MaxDate = DateTime.Today,
                Value = DateTime.Today.AddYears(-18)
            };

            cboStatus = new ComboBox
            {
                Location = new Point(205, 186),
                Size = new Size(270, 26),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboStatus.Items.AddRange(new object[] { "Ativo", "Inativo", "Afastado" });
            cboStatus.SelectedIndex = 0;

            Controls.Add(txtNome);
            Controls.Add(dtpNascimento);
            Controls.Add(cboStatus);

            Button btnSalvar = new Button
            {
                Text = "Salvar",
                Location = new Point(287, 235),
                Size = new Size(88, 32),
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            Button btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(387, 235),
                Size = new Size(88, 32),
                ForeColor = Color.FromArgb(30, 70, 150),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnCancelar.Click += delegate { DialogResult = DialogResult.Cancel; Close(); };
            Controls.Add(btnCancelar);

            AcceptButton = btnSalvar;
            CancelButton = btnCancelar;
        }

        private static Label CriarLabel(string texto, Point local, Size tamanho, float fonte, Color cor, bool negrito)
        {
            return new Label
            {
                Text = texto,
                Location = local,
                Size = tamanho,
                ForeColor = cor,
                Font = new Font("Segoe UI", fonte, negrito ? FontStyle.Bold : FontStyle.Regular)
            };
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome do aluno.", "Dados necessários", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            try
            {
                IdAlunoCriado = matriculaRepository.InserirAluno(
                    nome,
                    dtpNascimento.Value,
                    ConverterStatus(cboStatus.Text));

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não foi possível cadastrar o aluno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string ConverterStatus(string status)
        {
            if (status == "Inativo") return "Inactive";
            if (status == "Afastado") return "Away";
            return "Active";
        }
    }
}
