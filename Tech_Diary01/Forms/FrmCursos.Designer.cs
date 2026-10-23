namespace Tech_Diary01.Forms
{
    partial class FrmCursos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFrontalSuperior = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblConfiguracoes = new System.Windows.Forms.Label();
            this.lblRelatorios = new System.Windows.Forms.Label();
            this.lblPresenca = new System.Windows.Forms.Label();
            this.lblMatriculas = new System.Windows.Forms.Label();
            this.lblCursos = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.blLogo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.pnlCurso = new System.Windows.Forms.Panel();
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.colNomeCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCargaHoraria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colExcluir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblNovoCurso = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.pnlCurso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFrontalSuperior
            // 
            this.pnlFrontalSuperior.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlFrontalSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFrontalSuperior.ForeColor = System.Drawing.Color.DodgerBlue;
            this.pnlFrontalSuperior.Location = new System.Drawing.Point(230, 0);
            this.pnlFrontalSuperior.Name = "pnlFrontalSuperior";
            this.pnlFrontalSuperior.Size = new System.Drawing.Size(954, 59);
            this.pnlFrontalSuperior.TabIndex = 9;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlMenu.Controls.Add(this.lblConfiguracoes);
            this.pnlMenu.Controls.Add(this.lblRelatorios);
            this.pnlMenu.Controls.Add(this.lblPresenca);
            this.pnlMenu.Controls.Add(this.lblMatriculas);
            this.pnlMenu.Controls.Add(this.lblCursos);
            this.pnlMenu.Controls.Add(this.lblInicio);
            this.pnlMenu.Controls.Add(this.blLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(230, 661);
            this.pnlMenu.TabIndex = 8;
            // 
            // lblConfiguracoes
            // 
            this.lblConfiguracoes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfiguracoes.ForeColor = System.Drawing.Color.White;
            this.lblConfiguracoes.Location = new System.Drawing.Point(24, 322);
            this.lblConfiguracoes.Name = "lblConfiguracoes";
            this.lblConfiguracoes.Size = new System.Drawing.Size(200, 45);
            this.lblConfiguracoes.TabIndex = 7;
            this.lblConfiguracoes.Text = "⚙   Configurações";
            this.lblConfiguracoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRelatorios
            // 
            this.lblRelatorios.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelatorios.ForeColor = System.Drawing.Color.White;
            this.lblRelatorios.Location = new System.Drawing.Point(24, 277);
            this.lblRelatorios.Name = "lblRelatorios";
            this.lblRelatorios.Size = new System.Drawing.Size(200, 45);
            this.lblRelatorios.TabIndex = 6;
            this.lblRelatorios.Text = "▤   Relatórios";
            this.lblRelatorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPresenca
            // 
            this.lblPresenca.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresenca.ForeColor = System.Drawing.Color.White;
            this.lblPresenca.Location = new System.Drawing.Point(24, 232);
            this.lblPresenca.Name = "lblPresenca";
            this.lblPresenca.Size = new System.Drawing.Size(200, 45);
            this.lblPresenca.TabIndex = 5;
            this.lblPresenca.Text = "◷   Presença";
            this.lblPresenca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMatriculas
            // 
            this.lblMatriculas.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatriculas.ForeColor = System.Drawing.Color.White;
            this.lblMatriculas.Location = new System.Drawing.Point(24, 187);
            this.lblMatriculas.Name = "lblMatriculas";
            this.lblMatriculas.Size = new System.Drawing.Size(200, 45);
            this.lblMatriculas.TabIndex = 4;
            this.lblMatriculas.Text = "♙   Matrículas";
            this.lblMatriculas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCursos
            // 
            this.lblCursos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursos.ForeColor = System.Drawing.Color.White;
            this.lblCursos.Location = new System.Drawing.Point(24, 142);
            this.lblCursos.Name = "lblCursos";
            this.lblCursos.Size = new System.Drawing.Size(200, 45);
            this.lblCursos.TabIndex = 3;
            this.lblCursos.Text = "▣   Cursos";
            this.lblCursos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInicio
            // 
            this.lblInicio.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.White;
            this.lblInicio.Location = new System.Drawing.Point(24, 97);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(200, 45);
            this.lblInicio.TabIndex = 2;
            this.lblInicio.Text = "⌂   Início";
            this.lblInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // blLogo
            // 
            this.blLogo.AutoSize = true;
            this.blLogo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blLogo.ForeColor = System.Drawing.Color.White;
            this.blLogo.Location = new System.Drawing.Point(58, 18);
            this.blLogo.Name = "blLogo";
            this.blLogo.Size = new System.Drawing.Size(156, 37);
            this.blLogo.TabIndex = 1;
            this.blLogo.Text = "Tech_Diary";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo.Location = new System.Drawing.Point(240, 97);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(141, 17);
            this.lblSubtitulo.TabIndex = 11;
            this.lblSubtitulo.Text = "Gerenciador de cursos";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(236, 62);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(102, 37);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Cursos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(243, 129);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(180, 33);
            this.txtPesquisar.TabIndex = 12;
            this.txtPesquisar.Text = "";
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // pnlCurso
            // 
            this.pnlCurso.BackColor = System.Drawing.Color.White;
            this.pnlCurso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCurso.Controls.Add(this.dgvCursos);
            this.pnlCurso.ForeColor = System.Drawing.Color.Gray;
            this.pnlCurso.Location = new System.Drawing.Point(243, 168);
            this.pnlCurso.Name = "pnlCurso";
            this.pnlCurso.Size = new System.Drawing.Size(929, 350);
            this.pnlCurso.TabIndex = 13;
            // 
            // dgvCursos
            // 
            this.dgvCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursos.BackgroundColor = System.Drawing.Color.White;
            this.dgvCursos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNomeCurso,
            this.colCargaHoraria,
            this.colTurno,
            this.colStatus,
            this.colEditar,
            this.colExcluir});
            this.dgvCursos.Location = new System.Drawing.Point(-2, -2);
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.Size = new System.Drawing.Size(929, 347);
            this.dgvCursos.TabIndex = 0;
            this.dgvCursos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCursos_CellContentClick);
            // 
            // colNomeCurso
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNomeCurso.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNomeCurso.HeaderText = "Nome do Curso";
            this.colNomeCurso.Name = "colNomeCurso";
            this.colNomeCurso.ReadOnly = true;
            // 
            // colCargaHoraria
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCargaHoraria.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCargaHoraria.HeaderText = "Carga Horária";
            this.colCargaHoraria.Name = "colCargaHoraria";
            this.colCargaHoraria.ReadOnly = true;
            // 
            // colTurno
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTurno.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTurno.HeaderText = "Turno";
            this.colTurno.Name = "colTurno";
            this.colTurno.ReadOnly = true;
            // 
            // colStatus
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "";
            this.colEditar.Name = "colEditar";
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            // 
            // colExcluir
            // 
            this.colExcluir.HeaderText = "";
            this.colExcluir.Name = "colExcluir";
            this.colExcluir.Text = "Excluir";
            this.colExcluir.UseColumnTextForButtonValue = true;
            // 
            // lblNovoCurso
            // 
            this.lblNovoCurso.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblNovoCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNovoCurso.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNovoCurso.ForeColor = System.Drawing.Color.White;
            this.lblNovoCurso.Location = new System.Drawing.Point(992, 131);
            this.lblNovoCurso.Name = "lblNovoCurso";
            this.lblNovoCurso.Size = new System.Drawing.Size(180, 34);
            this.lblNovoCurso.TabIndex = 1;
            this.lblNovoCurso.Text = "+ Novo Curso";
            this.lblNovoCurso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNovoCurso.Click += new System.EventHandler(this.lblNovoCurso_Click);
            // 
            // FrmCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.lblNovoCurso);
            this.Controls.Add(this.pnlCurso);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlFrontalSuperior);
            this.Controls.Add(this.pnlMenu);
            this.Name = "FrmCursos";
            this.Text = "FrmCursos";
            this.Load += new System.EventHandler(this.FrmCursos_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlCurso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFrontalSuperior;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblConfiguracoes;
        private System.Windows.Forms.Label lblRelatorios;
        private System.Windows.Forms.Label lblPresenca;
        private System.Windows.Forms.Label lblMatriculas;
        private System.Windows.Forms.Label lblCursos;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label blLogo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Panel pnlCurso;
        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.Label lblNovoCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomeCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCargaHoraria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colExcluir;
    }
}
