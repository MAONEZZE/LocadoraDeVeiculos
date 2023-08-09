namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    partial class TelaPlanoDeCobrancaForm
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
            btnCancelar = new Button();
            btnSalvar = new Button();
            cbox_gpAutomoveis = new ComboBox();
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txb_kmDisponivel = new TextBox();
            txb_precoKm = new TextBox();
            txb_precoD = new TextBox();
            cbox_tipoPlano = new ComboBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(208, 229);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 32);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvar.DialogResult = DialogResult.OK;
            btnSalvar.Location = new Point(108, 229);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(82, 32);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // cbox_gpAutomoveis
            // 
            cbox_gpAutomoveis.FormattingEnabled = true;
            cbox_gpAutomoveis.Location = new Point(137, 18);
            cbox_gpAutomoveis.Name = "cbox_gpAutomoveis";
            cbox_gpAutomoveis.Size = new Size(147, 23);
            cbox_gpAutomoveis.TabIndex = 12;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txb_kmDisponivel);
            groupBox1.Controls.Add(txb_precoKm);
            groupBox1.Controls.Add(txb_precoD);
            groupBox1.Controls.Add(cbox_tipoPlano);
            groupBox1.Location = new Point(12, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(278, 154);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configurações de Planos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 117);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 22;
            label5.Text = "Km Disponível:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 88);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 21;
            label4.Text = "Preço por Km:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 64);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 20;
            label3.Text = "Preço Diária:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 30);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 19;
            label2.Text = "Tipo do Plano:";
            // 
            // txb_kmDisponivel
            // 
            txb_kmDisponivel.Location = new Point(125, 114);
            txb_kmDisponivel.Name = "txb_kmDisponivel";
            txb_kmDisponivel.Size = new Size(147, 23);
            txb_kmDisponivel.TabIndex = 18;
            // 
            // txb_precoKm
            // 
            txb_precoKm.Location = new Point(125, 85);
            txb_precoKm.Name = "txb_precoKm";
            txb_precoKm.Size = new Size(147, 23);
            txb_precoKm.TabIndex = 17;
            // 
            // txb_precoD
            // 
            txb_precoD.Location = new Point(125, 56);
            txb_precoD.Name = "txb_precoD";
            txb_precoD.Size = new Size(147, 23);
            txb_precoD.TabIndex = 16;
            // 
            // cbox_tipoPlano
            // 
            cbox_tipoPlano.FormattingEnabled = true;
            cbox_tipoPlano.Location = new Point(125, 27);
            cbox_tipoPlano.Name = "cbox_tipoPlano";
            cbox_tipoPlano.Size = new Size(147, 23);
            cbox_tipoPlano.TabIndex = 15;
            cbox_tipoPlano.SelectedIndexChanged += cbox_tipoPlano_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 21);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 14;
            label1.Text = "Grupo de Automoveis:";
            // 
            // TelaPlanoDeCobrancaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 272);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(cbox_gpAutomoveis);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Name = "TelaPlanoDeCobrancaForm";
            Text = "TelaPlanoDeCobrancaForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnSalvar;
        private ComboBox cbox_gpAutomoveis;
        private GroupBox groupBox1;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txb_kmDisponivel;
        private TextBox txb_precoKm;
        private TextBox txb_precoD;
        private ComboBox cbox_tipoPlano;
    }
}