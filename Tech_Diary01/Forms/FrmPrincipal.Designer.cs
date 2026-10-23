namespace Tech_Diary01.Data.Forms
{
    partial class FrmCurso
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblConfiguracoes = new System.Windows.Forms.Label();
            this.lblRelatorios = new System.Windows.Forms.Label();
            this.lblPresenca = new System.Windows.Forms.Label();
            this.lblMatriculas = new System.Windows.Forms.Label();
            this.lblCursos = new System.Windows.Forms.Label();
            this.lblInicio = new System.Windows.Forms.Label();
            this.blLogo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlCursos = new System.Windows.Forms.Panel();
            this.lblNumerosTotalCursos = new System.Windows.Forms.Label();
            this.lblTotalCursos = new System.Windows.Forms.Label();
            this.pnlMatriculasAtivas = new System.Windows.Forms.Panel();
            this.lblNumerosMatriculasAtivas = new System.Windows.Forms.Label();
            this.lblMatriculasAtivas = new System.Windows.Forms.Label();
            this.pnlPresencaHoje = new System.Windows.Forms.Panel();
            this.lblNumeroPresenca = new System.Windows.Forms.Label();
            this.lblPresencaHoje = new System.Windows.Forms.Label();
            this.pnlTaxaPresenca = new System.Windows.Forms.Panel();
            this.lblNumeroTaxaPresenca = new System.Windows.Forms.Label();
            this.lblTaxaPresenca = new System.Windows.Forms.Label();
            this.pnlFrontalSuperior = new System.Windows.Forms.Panel();
            this.pnlCursosMatriculas = new System.Windows.Forms.Panel();
            this.chartCursosMatriculas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTituloCursosMatriculas = new System.Windows.Forms.Label();
            this.pnlAtividadesRecentes = new System.Windows.Forms.Panel();
            this.chartAtividadesRecentes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTituloAtividades = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.pnlCursos.SuspendLayout();
            this.pnlMatriculasAtivas.SuspendLayout();
            this.pnlPresencaHoje.SuspendLayout();
            this.pnlTaxaPresenca.SuspendLayout();
            this.pnlCursosMatriculas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCursosMatriculas)).BeginInit();
            this.pnlAtividadesRecentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAtividadesRecentes)).BeginInit();
            this.SuspendLayout();
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
            this.pnlMenu.TabIndex = 0;
            // 
            // lblConfiguracoes
            // 
            this.lblConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblConfiguracoes.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfiguracoes.ForeColor = System.Drawing.Color.White;
            this.lblConfiguracoes.Location = new System.Drawing.Point(24, 322);
            this.lblConfiguracoes.Name = "lblConfiguracoes";
            this.lblConfiguracoes.Size = new System.Drawing.Size(200, 45);
            this.lblConfiguracoes.TabIndex = 7;
            this.lblConfiguracoes.Text = "⚙ Configurações";
            this.lblConfiguracoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblConfiguracoes.Click += new System.EventHandler(this.lblConfiguracoes_Click);
            // 
            // lblRelatorios
            // 
            this.lblRelatorios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRelatorios.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelatorios.ForeColor = System.Drawing.Color.White;
            this.lblRelatorios.Location = new System.Drawing.Point(24, 277);
            this.lblRelatorios.Name = "lblRelatorios";
            this.lblRelatorios.Size = new System.Drawing.Size(200, 45);
            this.lblRelatorios.TabIndex = 6;
            this.lblRelatorios.Text = "▤   Relatórios";
            this.lblRelatorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRelatorios.Click += new System.EventHandler(this.lblRelatorios_Click);
            // 
            // lblPresenca
            // 
            this.lblPresenca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPresenca.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresenca.ForeColor = System.Drawing.Color.White;
            this.lblPresenca.Location = new System.Drawing.Point(24, 232);
            this.lblPresenca.Name = "lblPresenca";
            this.lblPresenca.Size = new System.Drawing.Size(200, 45);
            this.lblPresenca.TabIndex = 5;
            this.lblPresenca.Text = "◷   Presença";
            this.lblPresenca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPresenca.Click += new System.EventHandler(this.lblPresenca_Click);
            // 
            // lblMatriculas
            // 
            this.lblMatriculas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMatriculas.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatriculas.ForeColor = System.Drawing.Color.White;
            this.lblMatriculas.Location = new System.Drawing.Point(24, 187);
            this.lblMatriculas.Name = "lblMatriculas";
            this.lblMatriculas.Size = new System.Drawing.Size(200, 45);
            this.lblMatriculas.TabIndex = 4;
            this.lblMatriculas.Text = "♙   Matrículas";
            this.lblMatriculas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMatriculas.Click += new System.EventHandler(this.lblMatriculas_Click);
            // 
            // lblCursos
            // 
            this.lblCursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCursos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursos.ForeColor = System.Drawing.Color.White;
            this.lblCursos.Location = new System.Drawing.Point(24, 142);
            this.lblCursos.Name = "lblCursos";
            this.lblCursos.Size = new System.Drawing.Size(200, 45);
            this.lblCursos.TabIndex = 3;
            this.lblCursos.Text = "▣   Cursos";
            this.lblCursos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCursos.Click += new System.EventHandler(this.lblCursos_Click);
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
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(236, 62);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(295, 37);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Painel Adminsitrativo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo.Location = new System.Drawing.Point(240, 97);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(142, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Visão geral do sistema";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlCursos
            // 
            this.pnlCursos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCursos.Controls.Add(this.lblNumerosTotalCursos);
            this.pnlCursos.Controls.Add(this.lblTotalCursos);
            this.pnlCursos.Location = new System.Drawing.Point(236, 142);
            this.pnlCursos.Name = "pnlCursos";
            this.pnlCursos.Size = new System.Drawing.Size(207, 110);
            this.pnlCursos.TabIndex = 3;
            // 
            // lblNumerosTotalCursos
            // 
            this.lblNumerosTotalCursos.AutoSize = true;
            this.lblNumerosTotalCursos.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumerosTotalCursos.Location = new System.Drawing.Point(56, 44);
            this.lblNumerosTotalCursos.Name = "lblNumerosTotalCursos";
            this.lblNumerosTotalCursos.Size = new System.Drawing.Size(34, 40);
            this.lblNumerosTotalCursos.TabIndex = 1;
            this.lblNumerosTotalCursos.Text = "0";
            this.lblNumerosTotalCursos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCursos
            // 
            this.lblTotalCursos.AutoSize = true;
            this.lblTotalCursos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCursos.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalCursos.Location = new System.Drawing.Point(59, 23);
            this.lblTotalCursos.Name = "lblTotalCursos";
            this.lblTotalCursos.Size = new System.Drawing.Size(125, 21);
            this.lblTotalCursos.TabIndex = 0;
            this.lblTotalCursos.Text = "Total de Cursos";
            // 
            // pnlMatriculasAtivas
            // 
            this.pnlMatriculasAtivas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMatriculasAtivas.Controls.Add(this.lblNumerosMatriculasAtivas);
            this.pnlMatriculasAtivas.Controls.Add(this.lblMatriculasAtivas);
            this.pnlMatriculasAtivas.Location = new System.Drawing.Point(459, 142);
            this.pnlMatriculasAtivas.Name = "pnlMatriculasAtivas";
            this.pnlMatriculasAtivas.Size = new System.Drawing.Size(200, 110);
            this.pnlMatriculasAtivas.TabIndex = 4;
            // 
            // lblNumerosMatriculasAtivas
            // 
            this.lblNumerosMatriculasAtivas.AutoSize = true;
            this.lblNumerosMatriculasAtivas.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumerosMatriculasAtivas.Location = new System.Drawing.Point(53, 44);
            this.lblNumerosMatriculasAtivas.Name = "lblNumerosMatriculasAtivas";
            this.lblNumerosMatriculasAtivas.Size = new System.Drawing.Size(34, 40);
            this.lblNumerosMatriculasAtivas.TabIndex = 1;
            this.lblNumerosMatriculasAtivas.Text = "0";
            this.lblNumerosMatriculasAtivas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMatriculasAtivas
            // 
            this.lblMatriculasAtivas.AutoSize = true;
            this.lblMatriculasAtivas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatriculasAtivas.ForeColor = System.Drawing.Color.Gray;
            this.lblMatriculasAtivas.Location = new System.Drawing.Point(56, 23);
            this.lblMatriculasAtivas.Name = "lblMatriculasAtivas";
            this.lblMatriculasAtivas.Size = new System.Drawing.Size(141, 21);
            this.lblMatriculasAtivas.TabIndex = 0;
            this.lblMatriculasAtivas.Text = "Matrículas Ativas";
            // 
            // pnlPresencaHoje
            // 
            this.pnlPresencaHoje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPresencaHoje.Controls.Add(this.lblNumeroPresenca);
            this.pnlPresencaHoje.Controls.Add(this.lblPresencaHoje);
            this.pnlPresencaHoje.Location = new System.Drawing.Point(695, 142);
            this.pnlPresencaHoje.Name = "pnlPresencaHoje";
            this.pnlPresencaHoje.Size = new System.Drawing.Size(211, 110);
            this.pnlPresencaHoje.TabIndex = 5;
            // 
            // lblNumeroPresenca
            // 
            this.lblNumeroPresenca.AutoSize = true;
            this.lblNumeroPresenca.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroPresenca.Location = new System.Drawing.Point(53, 44);
            this.lblNumeroPresenca.Name = "lblNumeroPresenca";
            this.lblNumeroPresenca.Size = new System.Drawing.Size(34, 40);
            this.lblNumeroPresenca.TabIndex = 1;
            this.lblNumeroPresenca.Text = "0";
            this.lblNumeroPresenca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPresencaHoje
            // 
            this.lblPresencaHoje.AutoSize = true;
            this.lblPresencaHoje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresencaHoje.ForeColor = System.Drawing.Color.Gray;
            this.lblPresencaHoje.Location = new System.Drawing.Point(70, 23);
            this.lblPresencaHoje.Name = "lblPresencaHoje";
            this.lblPresencaHoje.Size = new System.Drawing.Size(125, 21);
            this.lblPresencaHoje.TabIndex = 0;
            this.lblPresencaHoje.Text = "Presenças Hoje";
            // 
            // pnlTaxaPresenca
            // 
            this.pnlTaxaPresenca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTaxaPresenca.Controls.Add(this.lblNumeroTaxaPresenca);
            this.pnlTaxaPresenca.Controls.Add(this.lblTaxaPresenca);
            this.pnlTaxaPresenca.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTaxaPresenca.Location = new System.Drawing.Point(939, 142);
            this.pnlTaxaPresenca.Name = "pnlTaxaPresenca";
            this.pnlTaxaPresenca.Size = new System.Drawing.Size(216, 110);
            this.pnlTaxaPresenca.TabIndex = 6;
            // 
            // lblNumeroTaxaPresenca
            // 
            this.lblNumeroTaxaPresenca.AutoSize = true;
            this.lblNumeroTaxaPresenca.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroTaxaPresenca.Location = new System.Drawing.Point(53, 44);
            this.lblNumeroTaxaPresenca.Name = "lblNumeroTaxaPresenca";
            this.lblNumeroTaxaPresenca.Size = new System.Drawing.Size(34, 40);
            this.lblNumeroTaxaPresenca.TabIndex = 1;
            this.lblNumeroTaxaPresenca.Text = "0";
            this.lblNumeroTaxaPresenca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTaxaPresenca
            // 
            this.lblTaxaPresenca.AutoSize = true;
            this.lblTaxaPresenca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaxaPresenca.ForeColor = System.Drawing.Color.Gray;
            this.lblTaxaPresenca.Location = new System.Drawing.Point(56, 22);
            this.lblTaxaPresenca.Name = "lblTaxaPresenca";
            this.lblTaxaPresenca.Size = new System.Drawing.Size(140, 21);
            this.lblTaxaPresenca.TabIndex = 0;
            this.lblTaxaPresenca.Text = "Taxa de Presença";
            // 
            // pnlFrontalSuperior
            // 
            this.pnlFrontalSuperior.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlFrontalSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFrontalSuperior.ForeColor = System.Drawing.Color.DodgerBlue;
            this.pnlFrontalSuperior.Location = new System.Drawing.Point(230, 0);
            this.pnlFrontalSuperior.Name = "pnlFrontalSuperior";
            this.pnlFrontalSuperior.Size = new System.Drawing.Size(954, 59);
            this.pnlFrontalSuperior.TabIndex = 7;
            // 
            // pnlCursosMatriculas
            // 
            this.pnlCursosMatriculas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCursosMatriculas.Controls.Add(this.chartCursosMatriculas);
            this.pnlCursosMatriculas.Controls.Add(this.lblTituloCursosMatriculas);
            this.pnlCursosMatriculas.Location = new System.Drawing.Point(236, 277);
            this.pnlCursosMatriculas.Name = "pnlCursosMatriculas";
            this.pnlCursosMatriculas.Size = new System.Drawing.Size(450, 220);
            this.pnlCursosMatriculas.TabIndex = 8;
            // 
            // chartCursosMatriculas
            // 
            this.chartCursosMatriculas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartCursosMatriculas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartCursosMatriculas.Legends.Add(legend1);
            this.chartCursosMatriculas.Location = new System.Drawing.Point(-2, 56);
            this.chartCursosMatriculas.Name = "chartCursosMatriculas";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "Matriculas";
            this.chartCursosMatriculas.Series.Add(series1);
            this.chartCursosMatriculas.Size = new System.Drawing.Size(450, 162);
            this.chartCursosMatriculas.TabIndex = 1;
            this.chartCursosMatriculas.Text = "chart1";
            title1.Name = "Curso com mais matrículas";
            this.chartCursosMatriculas.Titles.Add(title1);
            // 
            // lblTituloCursosMatriculas
            // 
            this.lblTituloCursosMatriculas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCursosMatriculas.Location = new System.Drawing.Point(3, 0);
            this.lblTituloCursosMatriculas.Name = "lblTituloCursosMatriculas";
            this.lblTituloCursosMatriculas.Size = new System.Drawing.Size(400, 35);
            this.lblTituloCursosMatriculas.TabIndex = 0;
            this.lblTituloCursosMatriculas.Text = "Cursos com mais matrículas";
            this.lblTituloCursosMatriculas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAtividadesRecentes
            // 
            this.pnlAtividadesRecentes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAtividadesRecentes.Controls.Add(this.chartAtividadesRecentes);
            this.pnlAtividadesRecentes.Controls.Add(this.lblTituloAtividades);
            this.pnlAtividadesRecentes.Location = new System.Drawing.Point(705, 277);
            this.pnlAtividadesRecentes.Name = "pnlAtividadesRecentes";
            this.pnlAtividadesRecentes.Size = new System.Drawing.Size(450, 220);
            this.pnlAtividadesRecentes.TabIndex = 9;
            // 
            // chartAtividadesRecentes
            // 
            this.chartAtividadesRecentes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartAtividadesRecentes.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartAtividadesRecentes.Legends.Add(legend2);
            this.chartAtividadesRecentes.Location = new System.Drawing.Point(-3, 56);
            this.chartAtividadesRecentes.Name = "chartAtividadesRecentes";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "Cursos";
            this.chartAtividadesRecentes.Series.Add(series2);
            this.chartAtividadesRecentes.Size = new System.Drawing.Size(450, 162);
            this.chartAtividadesRecentes.TabIndex = 2;
            this.chartAtividadesRecentes.Text = "chart1";
            title2.Name = "Curso com mais matrículas";
            this.chartAtividadesRecentes.Titles.Add(title2);
            // 
            // lblTituloAtividades
            // 
            this.lblTituloAtividades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAtividades.Location = new System.Drawing.Point(3, 0);
            this.lblTituloAtividades.Name = "lblTituloAtividades";
            this.lblTituloAtividades.Size = new System.Drawing.Size(400, 35);
            this.lblTituloAtividades.TabIndex = 0;
            this.lblTituloAtividades.Text = "Atividades recentes";
            this.lblTituloAtividades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlAtividadesRecentes);
            this.Controls.Add(this.pnlCursosMatriculas);
            this.Controls.Add(this.pnlFrontalSuperior);
            this.Controls.Add(this.pnlTaxaPresenca);
            this.Controls.Add(this.pnlPresencaHoje);
            this.Controls.Add(this.pnlMatriculasAtivas);
            this.Controls.Add(this.pnlCursos);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlMenu);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tech Diary -  Painel Admnistrativo";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlCursos.ResumeLayout(false);
            this.pnlCursos.PerformLayout();
            this.pnlMatriculasAtivas.ResumeLayout(false);
            this.pnlMatriculasAtivas.PerformLayout();
            this.pnlPresencaHoje.ResumeLayout(false);
            this.pnlPresencaHoje.PerformLayout();
            this.pnlTaxaPresenca.ResumeLayout(false);
            this.pnlTaxaPresenca.PerformLayout();
            this.pnlCursosMatriculas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCursosMatriculas)).EndInit();
            this.pnlAtividadesRecentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAtividadesRecentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label blLogo;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblConfiguracoes;
        private System.Windows.Forms.Label lblRelatorios;
        private System.Windows.Forms.Label lblPresenca;
        private System.Windows.Forms.Label lblMatriculas;
        private System.Windows.Forms.Label lblCursos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlCursos;
        private System.Windows.Forms.Label lblNumerosTotalCursos;
        private System.Windows.Forms.Label lblTotalCursos;
        private System.Windows.Forms.Panel pnlMatriculasAtivas;
        private System.Windows.Forms.Label lblNumerosMatriculasAtivas;
        private System.Windows.Forms.Label lblMatriculasAtivas;
        private System.Windows.Forms.Panel pnlPresencaHoje;
        private System.Windows.Forms.Label lblNumeroPresenca;
        private System.Windows.Forms.Label lblPresencaHoje;
        private System.Windows.Forms.Panel pnlTaxaPresenca;
        private System.Windows.Forms.Label lblNumeroTaxaPresenca;
        private System.Windows.Forms.Label lblTaxaPresenca;
        private System.Windows.Forms.Panel pnlFrontalSuperior;
        private System.Windows.Forms.Panel pnlCursosMatriculas;
        private System.Windows.Forms.Label lblTituloCursosMatriculas;
        private System.Windows.Forms.Panel pnlAtividadesRecentes;
        private System.Windows.Forms.Label lblTituloAtividades;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCursosMatriculas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAtividadesRecentes;
    }
}
