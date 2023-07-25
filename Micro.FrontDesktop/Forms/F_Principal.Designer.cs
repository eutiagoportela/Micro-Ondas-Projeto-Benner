namespace Micro.FrontDesktop
{
    partial class F_Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            nivel1ToolStripMenuItem = new ToolStripMenuItem();
            l_Processando = new Label();
            t_tempo = new TextBox();
            b_Inicio = new Button();
            l_potencia = new Label();
            b_pausaCancela = new Button();
            t_Potencia = new TextBox();
            l_tempo = new Label();
            t_MsgProcessando = new TextBox();
            groupBox1 = new GroupBox();
            RbNivel3 = new RadioButton();
            Rb_Nivel2 = new RadioButton();
            Rb_Nivel1 = new RadioButton();
            cb_Programas = new ComboBox();
            l_cbProgramas = new Label();
            lb_Instrucoes = new Label();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { nivel1ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(638, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // nivel1ToolStripMenuItem
            // 
            nivel1ToolStripMenuItem.Name = "nivel1ToolStripMenuItem";
            nivel1ToolStripMenuItem.Size = new Size(129, 20);
            nivel1ToolStripMenuItem.Text = "Cadastrar Programas";
            nivel1ToolStripMenuItem.Click += Nivel1ToolStripMenuItem_Click;
            // 
            // l_Processando
            // 
            l_Processando.AutoSize = true;
            l_Processando.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            l_Processando.Location = new Point(278, 47);
            l_Processando.Name = "l_Processando";
            l_Processando.Size = new Size(98, 21);
            l_Processando.TabIndex = 16;
            l_Processando.Text = "Processando";
            l_Processando.Visible = false;
            // 
            // t_tempo
            // 
            t_tempo.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            t_tempo.Location = new Point(140, 314);
            t_tempo.MaxLength = 3;
            t_tempo.Name = "t_tempo";
            t_tempo.Size = new Size(175, 61);
            t_tempo.TabIndex = 12;
            // 
            // b_Inicio
            // 
            b_Inicio.Location = new Point(110, 410);
            b_Inicio.Name = "b_Inicio";
            b_Inicio.Size = new Size(228, 53);
            b_Inicio.TabIndex = 11;
            b_Inicio.Text = "Inicio";
            b_Inicio.UseVisualStyleBackColor = true;
            b_Inicio.Click += B_Inicio_Click;
            // 
            // l_potencia
            // 
            l_potencia.AutoSize = true;
            l_potencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            l_potencia.Location = new Point(332, 290);
            l_potencia.Name = "l_potencia";
            l_potencia.Size = new Size(68, 21);
            l_potencia.TabIndex = 14;
            l_potencia.Text = "Potência";
            // 
            // b_pausaCancela
            // 
            b_pausaCancela.Location = new Point(358, 410);
            b_pausaCancela.Name = "b_pausaCancela";
            b_pausaCancela.Size = new Size(230, 53);
            b_pausaCancela.TabIndex = 10;
            b_pausaCancela.Text = "Pausa/Cancela";
            b_pausaCancela.UseVisualStyleBackColor = true;
            b_pausaCancela.Click += B_pausaCancela_Click;
            // 
            // t_Potencia
            // 
            t_Potencia.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            t_Potencia.Location = new Point(334, 314);
            t_Potencia.MaxLength = 2;
            t_Potencia.Name = "t_Potencia";
            t_Potencia.Size = new Size(87, 61);
            t_Potencia.TabIndex = 15;
            // 
            // l_tempo
            // 
            l_tempo.AutoSize = true;
            l_tempo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            l_tempo.Location = new Point(138, 290);
            l_tempo.Name = "l_tempo";
            l_tempo.Size = new Size(56, 21);
            l_tempo.TabIndex = 13;
            l_tempo.Text = "Tempo";
            // 
            // t_MsgProcessando
            // 
            t_MsgProcessando.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            t_MsgProcessando.ForeColor = Color.Red;
            t_MsgProcessando.Location = new Point(110, 81);
            t_MsgProcessando.MaxLength = 3;
            t_MsgProcessando.Multiline = true;
            t_MsgProcessando.Name = "t_MsgProcessando";
            t_MsgProcessando.ScrollBars = ScrollBars.Vertical;
            t_MsgProcessando.Size = new Size(478, 314);
            t_MsgProcessando.TabIndex = 17;
            t_MsgProcessando.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(RbNivel3);
            groupBox1.Controls.Add(Rb_Nivel2);
            groupBox1.Controls.Add(Rb_Nivel1);
            groupBox1.Location = new Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(81, 126);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Niveis";
            // 
            // RbNivel3
            // 
            RbNivel3.AutoSize = true;
            RbNivel3.Location = new Point(7, 93);
            RbNivel3.Name = "RbNivel3";
            RbNivel3.Size = new Size(61, 19);
            RbNivel3.TabIndex = 2;
            RbNivel3.TabStop = true;
            RbNivel3.Text = "Nivel 3";
            RbNivel3.UseVisualStyleBackColor = true;
            RbNivel3.CheckedChanged += RbNivel3_CheckedChanged;
            // 
            // Rb_Nivel2
            // 
            Rb_Nivel2.AutoSize = true;
            Rb_Nivel2.Location = new Point(7, 54);
            Rb_Nivel2.Name = "Rb_Nivel2";
            Rb_Nivel2.Size = new Size(61, 19);
            Rb_Nivel2.TabIndex = 1;
            Rb_Nivel2.Text = "Nivel 2";
            Rb_Nivel2.UseVisualStyleBackColor = true;
            Rb_Nivel2.CheckedChanged += Rb_Nivel1_CheckedChanged;
            // 
            // Rb_Nivel1
            // 
            Rb_Nivel1.AutoSize = true;
            Rb_Nivel1.Checked = true;
            Rb_Nivel1.Location = new Point(7, 16);
            Rb_Nivel1.Name = "Rb_Nivel1";
            Rb_Nivel1.Size = new Size(61, 19);
            Rb_Nivel1.TabIndex = 0;
            Rb_Nivel1.TabStop = true;
            Rb_Nivel1.Text = "Nivel 1";
            Rb_Nivel1.UseVisualStyleBackColor = true;
            Rb_Nivel1.CheckedChanged += Rb_Nivel1_CheckedChanged;
            // 
            // cb_Programas
            // 
            cb_Programas.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cb_Programas.FormattingEnabled = true;
            cb_Programas.Location = new Point(140, 120);
            cb_Programas.Name = "cb_Programas";
            cb_Programas.Size = new Size(400, 33);
            cb_Programas.TabIndex = 19;
            cb_Programas.Visible = false;
            cb_Programas.SelectedIndexChanged += Cb_Programas_SelectedIndexChanged;
            // 
            // l_cbProgramas
            // 
            l_cbProgramas.AutoSize = true;
            l_cbProgramas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            l_cbProgramas.Location = new Point(140, 96);
            l_cbProgramas.Name = "l_cbProgramas";
            l_cbProgramas.Size = new Size(122, 21);
            l_cbProgramas.TabIndex = 20;
            l_cbProgramas.Text = "Lista Programas";
            l_cbProgramas.Visible = false;
            // 
            // lb_Instrucoes
            // 
            lb_Instrucoes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Instrucoes.Location = new Point(140, 168);
            lb_Instrucoes.Name = "lb_Instrucoes";
            lb_Instrucoes.Size = new Size(400, 104);
            lb_Instrucoes.TabIndex = 21;
            lb_Instrucoes.Text = "Instruções";
            lb_Instrucoes.Visible = false;
            // 
            // F_Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 484);
            Controls.Add(lb_Instrucoes);
            Controls.Add(l_cbProgramas);
            Controls.Add(cb_Programas);
            Controls.Add(groupBox1);
            Controls.Add(l_Processando);
            Controls.Add(t_tempo);
            Controls.Add(b_Inicio);
            Controls.Add(l_potencia);
            Controls.Add(b_pausaCancela);
            Controls.Add(t_Potencia);
            Controls.Add(l_tempo);
            Controls.Add(t_MsgProcessando);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "F_Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Microondas";
            Load += F_Principal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem nivel1ToolStripMenuItem;
        private Label l_Processando;
        private TextBox t_tempo;
        private Button b_Inicio;
        private Label l_potencia;
        private Button b_pausaCancela;
        private TextBox t_Potencia;
        private Label l_tempo;
        private TextBox t_MsgProcessando;
        private GroupBox groupBox1;
        private RadioButton Rb_Nivel2;
        private RadioButton Rb_Nivel1;
        private ComboBox cb_Programas;
        private Label l_cbProgramas;
        private Label lb_Instrucoes;
        private RadioButton RbNivel3;
    }
}