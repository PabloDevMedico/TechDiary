using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Tech_Diary01.Data;

namespace Tech_Diary01.Forms
{
    public class FrmRelatorios : Form
    {
        private readonly RelatorioRepository repositorio = new RelatorioRepository();
        private readonly DataGridView dgvRelatorio = new DataGridView();
        private readonly Label lblCursos = new Label();
        private readonly Label lblMatriculas = new Label();
        private readonly Label lblTaxa = new Label();

        public FrmRelatorios() { CriarTela(); }
        private void CriarTela()
        {
            Text = "Tech Diary - Relatórios"; ClientSize = new Size(1184, 661); BackColor = Color.White; StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(new Panel { BackColor = Color.DodgerBlue, Dock = DockStyle.Top, Height = 60 });
            Panel menu = new Panel { BackColor = Color.DodgerBlue, Dock = DockStyle.Left, Width = 230 }; Controls.Add(menu); CriarMenu(menu);
            Controls.Add(Label("Relatórios", 260, 85, 350, 45, 24, Color.FromArgb(10, 29, 104), true));
            Controls.Add(Label("Acompanhe os indicadores de cursos, matrículas e frequência.", 263, 130, 650, 25, 11, Color.FromArgb(90, 105, 160), false));
            CriarCartao("Cursos cadastrados", lblCursos, 263); CriarCartao("Matrículas ativas", lblMatriculas, 550); CriarCartao("Taxa de presença", lblTaxa, 837);
            Label atualizar = Botao("Atualizar", 905, 270, 115); atualizar.Click += delegate { CarregarRelatorio(); }; Controls.Add(atualizar);
            Label exportar = Botao("Exportar CSV", 1030, 270, 122); exportar.Click += lblExportar_Click; Controls.Add(exportar);
            dgvRelatorio.Location = new Point(263, 315); dgvRelatorio.Size = new Size(889, 270); dgvRelatorio.AllowUserToAddRows = false; dgvRelatorio.ReadOnly = true; dgvRelatorio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRelatorio.EnableHeadersVisualStyles = false; dgvRelatorio.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 248, 255); dgvRelatorio.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold); Controls.Add(dgvRelatorio);
            Load += delegate { CarregarRelatorio(); };
        }
        private void CriarCartao(string titulo, Label valor, int x)
        {
            Panel p = new Panel { Location = new Point(x, 180), Size = new Size(265, 70), BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };
            p.Controls.Add(Label(titulo, 20, 10, 220, 22, 10, Color.FromArgb(80, 95, 140), false)); valor.Location = new Point(20, 30); valor.Size = new Size(220, 33); valor.Font = new Font("Segoe UI", 18, FontStyle.Bold); valor.ForeColor = Color.FromArgb(10, 29, 104); p.Controls.Add(valor); Controls.Add(p);
        }
        private void CriarMenu(Panel menu)
        {
            menu.Controls.Add(Label("Tech Diary", 45, 20, 160, 40, 20, Color.White, true));
            Label inicio=Menu("Início",100,false);inicio.Click+=delegate{Navegacao.Abrir(this,new Tech_Diary01.Data.Forms.FrmCurso());};menu.Controls.Add(inicio);
            Label cursos = Menu("Cursos",145,false); cursos.Click += delegate { Navegacao.Abrir(this,new FrmCursos()); }; menu.Controls.Add(cursos);
            Label matriculas = Menu("Matrículas",190,false); matriculas.Click += delegate { Navegacao.Abrir(this,new FrmMatriculas()); }; menu.Controls.Add(matriculas);
            Label presenca = Menu("Presença",235,false); presenca.Click += delegate { Navegacao.Abrir(this,new FrmPresenca()); }; menu.Controls.Add(presenca);
            menu.Controls.Add(Menu("Relatórios",280,true)); Label config=Menu("Configurações",325,false);config.Click+=delegate{Navegacao.Abrir(this,new FrmConfiguracoes());};menu.Controls.Add(config);
        }
        private static Label Label(string texto,int x,int y,int w,int h,float fonte,Color cor,bool negrito) { return new Label { Text=texto, Location=new Point(x,y), Size=new Size(w,h), ForeColor=cor, Font=new Font("Segoe UI",fonte,negrito?FontStyle.Bold:FontStyle.Regular) }; }
        private static Label Botao(string texto,int x,int y,int w) { Label l=Label(texto,x,y,w,33,10,Color.White,true); l.BackColor=Color.DodgerBlue;l.TextAlign=ContentAlignment.MiddleCenter;l.Cursor=Cursors.Hand;return l; }
        private static Label Menu(string texto,int y,bool ativo) { Label l=Label(IconeMenu(texto)+"   "+texto,12,y,205,42,13,Color.White,true);l.Padding=new Padding(22,0,0,0);l.TextAlign=ContentAlignment.MiddleLeft;l.Cursor=Cursors.Hand;if(ativo)l.BackColor=Color.FromArgb(55,145,245);return l; }
        private static string IconeMenu(string texto){if(texto=="Início")return "⌂";if(texto=="Cursos")return "▣";if(texto=="Matrículas")return "♙";if(texto=="Presença")return "◷";if(texto=="Relatórios")return "▤";return "⚙";}
        private void CarregarRelatorio()
        {
            lblCursos.Text = repositorio.GetTotalCursos().ToString(); lblMatriculas.Text = repositorio.GetTotalMatriculasAtivas().ToString(); lblTaxa.Text = repositorio.GetTaxaPresenca().ToString("0.0") + "%";
            dgvRelatorio.Rows.Clear(); dgvRelatorio.Columns.Clear(); dgvRelatorio.Columns.Add("curso","Curso");dgvRelatorio.Columns.Add("matriculas","Matrículas");dgvRelatorio.Columns.Add("presentes","Presenças");dgvRelatorio.Columns.Add("faltas","Faltas");
            using (SqlDataReader reader = repositorio.GetResumoPresencas()) while (reader.Read()) dgvRelatorio.Rows.Add(reader["course_name"],reader["total_registrations"],reader["present_count"],reader["absent_count"]);
        }
        private void lblExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog salvar = new SaveFileDialog { Filter = "Arquivo CSV|*.csv", FileName = "relatorio-tech-diary.csv" })
                if (salvar.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder("Curso;Matrículas;Presenças;Faltas" + Environment.NewLine);
                    foreach (DataGridViewRow linha in dgvRelatorio.Rows) if (!linha.IsNewRow) csv.AppendLine(string.Join(";", linha.Cells[0].Value, linha.Cells[1].Value, linha.Cells[2].Value, linha.Cells[3].Value));
                    File.WriteAllText(salvar.FileName, csv.ToString(), Encoding.UTF8); MessageBox.Show("Relatório exportado.", "Tech Diary");
                }
        }
    }
}
