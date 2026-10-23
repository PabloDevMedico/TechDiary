using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Tech_Diary01.Data;

namespace Tech_Diary01.Forms
{
    public partial class FrmNovoCurso : Form
    {
        private readonly CursoRepository cursoRepository = new CursoRepository();
        private readonly int? idCurso;
        private TextBox txtNome;
        private NumericUpDown nudCargaHoraria;
        private ComboBox cboTurno;
        private ComboBox cboStatus;
        private NumericUpDown nudAdmin;
        private NumericUpDown nudProfessor;
        private NumericUpDown nudPreco;

        public FrmNovoCurso()
        {
            InitializeComponent();
            CriarTela();
        }

        public FrmNovoCurso(int idCurso, string nome, string cargaHoraria,
            string turno, string status) : this()
        {
            this.idCurso = idCurso;
            Text = "Tech Diary - Editar curso";
            txtNome.Text = nome;
            nudCargaHoraria.Value = ExtrairNumero(cargaHoraria);
            cboTurno.SelectedItem = turno;
            cboStatus.SelectedItem = status;
            nudAdmin.Visible = false;
            nudProfessor.Visible = false;
            nudPreco.Visible = false;
            Controls["lblAdmin"].Visible = false;
            Controls["lblProfessor"].Visible = false;
            Controls["lblPreco"].Visible = false;
        }

        private void CriarTela()
        {
            BackColor = Color.White;
            ClientSize = new Size(520, 470);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tech Diary - Novo curso";

            Label titulo = new Label
            {
                Text = "Cadastro de curso",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 42, 100),
                Location = new Point(30, 20), AutoSize = true
            };
            Controls.Add(titulo);

            txtNome = AdicionarTexto("Nome do curso", "", 75);
            nudCargaHoraria = AdicionarNumero("Carga horária (horas)", 125, 1, 5000, 1);
            cboTurno = AdicionarLista("Turno", 175, "Manhã", "Tarde", "Noite");
            cboStatus = AdicionarLista("Status", 225, "Ativo", "Inativo");
            nudAdmin = AdicionarNumero("ID do administrador", 275, 1, 999999, 1, "lblAdmin");
            nudProfessor = AdicionarNumero("ID do professor", 325, 1, 999999, 1, "lblProfessor");
            nudPreco = AdicionarNumero("Preço", 375, 0, 999999, 0, "lblPreco", 2);

            Button btnSalvar = new Button
            {
                Text = "Salvar",
                BackColor = Color.DodgerBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(300, 420), Size = new Size(90, 32)
            };
            btnSalvar.Click += btnSalvar_Click;
            Controls.Add(btnSalvar);

            Button btnCancelar = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Location = new Point(400, 420), Size = new Size(90, 32)
            };
            Controls.Add(btnCancelar);
            CancelButton = btnCancelar;
        }

        private TextBox AdicionarTexto(string rotulo, string texto, int y)
        {
            AdicionarRotulo(rotulo, y, null);
            TextBox campo = new TextBox { Text = texto, Location = new Point(230, y), Size = new Size(260, 25) };
            Controls.Add(campo);
            return campo;
        }

        private NumericUpDown AdicionarNumero(string rotulo, int y, decimal minimo,
            decimal maximo, decimal valor, string nomeRotulo = null, int casasDecimais = 0)
        {
            AdicionarRotulo(rotulo, y, nomeRotulo);
            NumericUpDown campo = new NumericUpDown
            {
                Location = new Point(230, y), Size = new Size(260, 25),
                Minimum = minimo, Maximum = maximo, Value = valor,
                DecimalPlaces = casasDecimais
            };
            Controls.Add(campo);
            return campo;
        }

        private ComboBox AdicionarLista(string rotulo, int y, params string[] itens)
        {
            AdicionarRotulo(rotulo, y, null);
            ComboBox campo = new ComboBox { Location = new Point(230, y), Size = new Size(260, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            campo.Items.AddRange(itens);
            campo.SelectedIndex = 0;
            Controls.Add(campo);
            return campo;
        }

        private void AdicionarRotulo(string texto, int y, string nome)
        {
            Label rotulo = new Label { Text = texto, Location = new Point(30, y + 4), AutoSize = true };
            if (nome != null) rotulo.Name = nome;
            Controls.Add(rotulo);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do curso.", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }

            string turno = ConverterTurno(cboTurno.Text);
            string status = cboStatus.Text == "Ativo" ? "Active" : "Inactive";

            try
            {
                if (idCurso.HasValue)
                    cursoRepository.AtualizarCurso(idCurso.Value, txtNome.Text.Trim(), (int)nudCargaHoraria.Value, turno, status);
                else
                    cursoRepository.InserirCurso((int)nudAdmin.Value, (int)nudProfessor.Value,
                        txtNome.Text.Trim(), (int)nudCargaHoraria.Value, nudPreco.Value, turno, status);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar o curso.\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string ConverterTurno(string turno)
        {
            if (turno == "Manhã") return "Morning";
            if (turno == "Tarde") return "Afternoon";
            return "Evening";
        }

        private static decimal ExtrairNumero(string texto)
        {
            string apenasNumero = texto.Replace("horas", "").Trim();
            decimal valor;
            return decimal.TryParse(apenasNumero, NumberStyles.Number,
                CultureInfo.CurrentCulture, out valor) ? valor : 1;
        }
    }
}
