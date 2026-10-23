using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tech_Diary01.Forms;
using System.Data.SqlClient;
using Tech_Diary01.Data;


namespace Tech_Diary01.Data.Forms
{
    public partial class FrmCurso : Form
    {
        private DashboardRepository dashboard;
        private GraficoRepository grafico;

        public FrmCurso()
        {
            InitializeComponent();

            dashboard = new DashboardRepository();
            grafico = new GraficoRepository();
        }

        private void GetCursosMaisMatriculas()
        {
            using (SqlDataReader reader = grafico.GetCursosMaisMatriculas())
            {
                chartCursosMatriculas.Series["Matriculas"].Points.Clear();

                while (reader.Read())
                {
                    string curso = reader["Curso"].ToString();

                    int matriculas = Convert.ToInt32(reader["Matriculas"]);

                    chartCursosMatriculas.Series["Matriculas"]
                        .Points.AddXY(curso, matriculas);
                }
            }
        }
      

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblNumerosTotalCursos.Text =
                dashboard.GetTotalCursos().ToString();

            lblNumerosMatriculasAtivas.Text =
                dashboard.GetTotalMatriculas().ToString();

            lblNumeroPresenca.Text =
                dashboard.GetPresencasHoje().ToString();

            lblNumeroTaxaPresenca.Text =
                dashboard.GetTaxaPresenca().ToString("0.00") + "%";

            GetCursosMaisMatriculas();
        }
        private void lblCursos_Click(object sender, EventArgs e)
        {
            FrmCursos telaCursos = new FrmCursos();
            Navegacao.Abrir(this, telaCursos);
        }

        private void lblMatriculas_Click(object sender, EventArgs e)
        {
            FrmMatriculas telaMatriculas = new FrmMatriculas();
            Navegacao.Abrir(this, telaMatriculas);
        }

        private void lblPresenca_Click(object sender, EventArgs e)
        {
            Navegacao.Abrir(this, new FrmPresenca());
        }

        private void lblRelatorios_Click(object sender, EventArgs e)
        {
            Navegacao.Abrir(this, new FrmRelatorios());
        }

        private void lblConfiguracoes_Click(object sender, EventArgs e)
        {
            Navegacao.Abrir(this, new FrmConfiguracoes());
        }
    }
}
