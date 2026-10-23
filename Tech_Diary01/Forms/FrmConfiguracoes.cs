using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Tech_Diary01.Data;

namespace Tech_Diary01.Forms
{
    public class FrmConfiguracoes : Form
    {
        private readonly ConfiguracaoRepository repositorio = new ConfiguracaoRepository();
        private TextBox txtInstituicao, txtEmail, txtTelefone, txtEndereco;
        private CheckBox chkNotificacoes;
        public FrmConfiguracoes() { CriarTela(); }
        private void CriarTela()
        {
            Text = "Tech Diary - Configurações"; ClientSize = new Size(1184, 661); BackColor = Color.White; StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(new Panel { BackColor = Color.DodgerBlue, Dock = DockStyle.Top, Height = 60 });
            Panel menu = new Panel { BackColor = Color.DodgerBlue, Dock = DockStyle.Left, Width = 230 }; Controls.Add(menu); CriarMenu(menu);
            Controls.Add(Label("Configurações", 260, 85, 400, 45, 24, Color.FromArgb(10,29,104), true)); Controls.Add(Label("Atualize os dados institucionais e as preferências do sistema.",263,130,650,25,11,Color.FromArgb(90,105,160),false));
            Panel dados = new Panel { Location = new Point(263,180), Size = new Size(600,350), BorderStyle = BorderStyle.FixedSingle }; Controls.Add(dados); dados.Controls.Add(Label("Dados da instituição",25,20,300,28,15,Color.FromArgb(10,29,104),true));
            txtInstituicao = Campo(dados,"Nome da instituição",70); txtEmail = Campo(dados,"E-mail",120); txtTelefone = Campo(dados,"Telefone",170); txtEndereco = Campo(dados,"Endereço",220);
            chkNotificacoes = new CheckBox { Text="Receber notificações do sistema", Location=new Point(210,275), AutoSize=true, Font=new Font("Segoe UI",10) }; dados.Controls.Add(chkNotificacoes);
            Label salvar = Botao("Salvar alterações", 690, 550, 173); salvar.Click += lblSalvar_Click; Controls.Add(salvar); Load += FrmConfiguracoes_Load;
        }
        private TextBox Campo(Panel p,string nome,int y) { p.Controls.Add(Label(nome,25,y+4,170,25,10,Color.FromArgb(40,50,80),true));TextBox c=new TextBox { Location=new Point(210,y),Size=new Size(350,25)};p.Controls.Add(c);return c; }
        private void CriarMenu(Panel menu) { menu.Controls.Add(Label("Tech Diary",45,20,160,40,20,Color.White,true));Label inicio=Menu("Início",100,false);inicio.Click+=delegate{Navegacao.Abrir(this,new Tech_Diary01.Data.Forms.FrmCurso());};menu.Controls.Add(inicio);Label cursos=Menu("Cursos",145,false);cursos.Click+=delegate{Navegacao.Abrir(this,new FrmCursos());};menu.Controls.Add(cursos);Label mat=Menu("Matrículas",190,false);mat.Click+=delegate{Navegacao.Abrir(this,new FrmMatriculas());};menu.Controls.Add(mat);Label pre=Menu("Presença",235,false);pre.Click+=delegate{Navegacao.Abrir(this,new FrmPresenca());};menu.Controls.Add(pre);Label rel=Menu("Relatórios",280,false);rel.Click+=delegate{Navegacao.Abrir(this,new FrmRelatorios());};menu.Controls.Add(rel);menu.Controls.Add(Menu("Configurações",325,true)); }
        private static Label Label(string t,int x,int y,int w,int h,float f,Color c,bool b){return new Label{Text=t,Location=new Point(x,y),Size=new Size(w,h),ForeColor=c,Font=new Font("Segoe UI",f,b?FontStyle.Bold:FontStyle.Regular)};}
        private static Label Botao(string t,int x,int y,int w){Label l=Label(t,x,y,w,33,10,Color.White,true);l.BackColor=Color.DodgerBlue;l.TextAlign=ContentAlignment.MiddleCenter;l.Cursor=Cursors.Hand;return l;}
        private static Label Menu(string t,int y,bool a){Label l=Label(IconeMenu(t)+"   "+t,12,y,205,42,13,Color.White,true);l.Padding=new Padding(22,0,0,0);l.TextAlign=ContentAlignment.MiddleLeft;l.Cursor=Cursors.Hand;if(a)l.BackColor=Color.FromArgb(55,145,245);return l;}
        private static string IconeMenu(string t){if(t=="Início")return "⌂";if(t=="Cursos")return "▣";if(t=="Matrículas")return "♙";if(t=="Presença")return "◷";if(t=="Relatórios")return "▤";return "⚙";}
        private void FrmConfiguracoes_Load(object s,EventArgs e){using(SqlDataReader r=repositorio.GetConfiguracao())if(r.Read()){txtInstituicao.Text=r["school_name"].ToString();txtEmail.Text=r["email"].ToString();txtTelefone.Text=r["phone"].ToString();txtEndereco.Text=r["address"].ToString();chkNotificacoes.Checked=Convert.ToBoolean(r["notifications_enabled"]);}}
        private void lblSalvar_Click(object s,EventArgs e){if(string.IsNullOrWhiteSpace(txtInstituicao.Text)){MessageBox.Show("Informe o nome da instituição.");return;}try{repositorio.SalvarConfiguracao(txtInstituicao.Text.Trim(),txtEmail.Text.Trim(),txtTelefone.Text.Trim(),txtEndereco.Text.Trim(),chkNotificacoes.Checked);MessageBox.Show("Configurações salvas.","Tech Diary");}catch(Exception ex){MessageBox.Show(ex.Message,"Não foi possível salvar");}}
    }
}
