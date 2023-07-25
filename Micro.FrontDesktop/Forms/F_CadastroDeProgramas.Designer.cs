namespace Micro.FrontDesktop.Forms
{
    partial class F_CadastroDeProgramas
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
            label1 = new Label();
            t_Nome = new TextBox();
            t_Alimento = new TextBox();
            l_Alimento = new Label();
            t_tempo = new TextBox();
            label3 = new Label();
            t_Potencia = new TextBox();
            label4 = new Label();
            t_instrucoes = new TextBox();
            label5 = new Label();
            t_Aquece = new TextBox();
            label6 = new Label();
            b_Salvar = new Button();
            b_excluir = new Button();
            b_Cancelar = new Button();
            b_Novo = new Button();
            b_Localizar = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 21);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // t_Nome
            // 
            t_Nome.Location = new Point(21, 42);
            t_Nome.MaxLength = 100;
            t_Nome.Name = "t_Nome";
            t_Nome.Size = new Size(523, 23);
            t_Nome.TabIndex = 1;
            // 
            // t_Alimento
            // 
            t_Alimento.Location = new Point(21, 102);
            t_Alimento.MaxLength = 200;
            t_Alimento.Name = "t_Alimento";
            t_Alimento.Size = new Size(523, 23);
            t_Alimento.TabIndex = 2;
            // 
            // l_Alimento
            // 
            l_Alimento.AutoSize = true;
            l_Alimento.Location = new Point(19, 81);
            l_Alimento.Name = "l_Alimento";
            l_Alimento.Size = new Size(56, 15);
            l_Alimento.TabIndex = 2;
            l_Alimento.Text = "Alimento";
            // 
            // t_tempo
            // 
            t_tempo.Location = new Point(19, 161);
            t_tempo.MaxLength = 3;
            t_tempo.Name = "t_tempo";
            t_tempo.Size = new Size(153, 23);
            t_tempo.TabIndex = 3;
            t_tempo.KeyPress += Tempo_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 140);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 4;
            label3.Text = "Tempo";
            // 
            // t_Potencia
            // 
            t_Potencia.Location = new Point(183, 161);
            t_Potencia.MaxLength = 2;
            t_Potencia.Name = "t_Potencia";
            t_Potencia.Size = new Size(159, 23);
            t_Potencia.TabIndex = 4;
            t_Potencia.KeyPress += Potencia_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(181, 140);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 6;
            label4.Text = "Potência";
            // 
            // t_instrucoes
            // 
            t_instrucoes.Location = new Point(19, 220);
            t_instrucoes.MaxLength = 400;
            t_instrucoes.Multiline = true;
            t_instrucoes.Name = "t_instrucoes";
            t_instrucoes.Size = new Size(523, 129);
            t_instrucoes.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 199);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 8;
            label5.Text = "Instruções";
            // 
            // t_Aquece
            // 
            t_Aquece.Location = new Point(352, 161);
            t_Aquece.MaxLength = 1;
            t_Aquece.Name = "t_Aquece";
            t_Aquece.Size = new Size(153, 23);
            t_Aquece.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(350, 140);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 10;
            label6.Text = "Aquece";
            // 
            // b_Salvar
            // 
            b_Salvar.Enabled = false;
            b_Salvar.Location = new Point(250, 389);
            b_Salvar.Name = "b_Salvar";
            b_Salvar.Size = new Size(102, 41);
            b_Salvar.TabIndex = 12;
            b_Salvar.Text = "Salvar";
            b_Salvar.UseVisualStyleBackColor = true;
            b_Salvar.Click += B_Salvar_ClickAsync;
            // 
            // b_excluir
            // 
            b_excluir.Enabled = false;
            b_excluir.Location = new Point(143, 389);
            b_excluir.Name = "b_excluir";
            b_excluir.Size = new Size(102, 41);
            b_excluir.TabIndex = 13;
            b_excluir.Text = "Excluir";
            b_excluir.UseVisualStyleBackColor = true;
            b_excluir.Click += B_excluir_Click;
            // 
            // b_Cancelar
            // 
            b_Cancelar.Enabled = false;
            b_Cancelar.Location = new Point(460, 389);
            b_Cancelar.Name = "b_Cancelar";
            b_Cancelar.Size = new Size(102, 41);
            b_Cancelar.TabIndex = 14;
            b_Cancelar.Text = "Cancelar";
            b_Cancelar.UseVisualStyleBackColor = true;
            b_Cancelar.Click += B_Cancelar_Click;
            // 
            // b_Novo
            // 
            b_Novo.Location = new Point(39, 389);
            b_Novo.Name = "b_Novo";
            b_Novo.Size = new Size(102, 41);
            b_Novo.TabIndex = 15;
            b_Novo.Text = "Novo";
            b_Novo.UseVisualStyleBackColor = true;
            b_Novo.Click += B_Novo_Click;
            // 
            // b_Localizar
            // 
            b_Localizar.Location = new Point(355, 389);
            b_Localizar.Name = "b_Localizar";
            b_Localizar.Size = new Size(102, 41);
            b_Localizar.TabIndex = 16;
            b_Localizar.Text = "Localizar";
            b_Localizar.UseVisualStyleBackColor = true;
            b_Localizar.Click += B_Localizar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(t_instrucoes);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(t_Nome);
            panel1.Controls.Add(l_Alimento);
            panel1.Controls.Add(t_Alimento);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(t_Aquece);
            panel1.Controls.Add(t_tempo);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(t_Potencia);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(22, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(583, 371);
            panel1.TabIndex = 17;
            // 
            // F_CadastroDeProgramas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 445);
            Controls.Add(panel1);
            Controls.Add(b_Localizar);
            Controls.Add(b_Novo);
            Controls.Add(b_Cancelar);
            Controls.Add(b_excluir);
            Controls.Add(b_Salvar);
            Name = "F_CadastroDeProgramas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Programas";
            Load += F_CadastroDeProgramas_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox t_Nome;
        private TextBox t_Alimento;
        private Label l_Alimento;
        private TextBox t_tempo;
        private Label label3;
        private TextBox t_Potencia;
        private Label label4;
        private TextBox t_instrucoes;
        private Label label5;
        private TextBox t_Aquece;
        private Label label6;
        private Button b_Salvar;
        private Button b_excluir;
        private Button b_Cancelar;
        private Button b_Novo;
        private Button b_Localizar;
        private Panel panel1;
    }
}