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
            btnCancelar.Location = new Point(278, 327);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 43);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvar.DialogResult = DialogResult.OK;
            btnSalvar.Location = new Point(163, 327);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 43);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // cbox_gpAutomoveis
            // 
            cbox_gpAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_gpAutomoveis.FormattingEnabled = true;
            cbox_gpAutomoveis.Location = new Point(178, 28);
            cbox_gpAutomoveis.Margin = new Padding(3, 4, 3, 4);
            cbox_gpAutomoveis.Name = "cbox_gpAutomoveis";
            cbox_gpAutomoveis.Size = new Size(167, 28);
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
            groupBox1.Location = new Point(14, 75);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(358, 219);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configurações de Planos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 154);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 22;
            label5.Text = "Km Disponível:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 116);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 21;
            label4.Text = "Preço por Km:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 78);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 20;
            label3.Text = "Preço Diária:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 40);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 19;
            label2.Text = "Tipo do Plano:";
            // 
            // txb_kmDisponivel
            // 
            txb_kmDisponivel.Location = new Point(164, 153);
            txb_kmDisponivel.Margin = new Padding(3, 4, 3, 4);
            txb_kmDisponivel.Name = "txb_kmDisponivel";
            txb_kmDisponivel.Size = new Size(167, 27);
            txb_kmDisponivel.TabIndex = 18;
            // 
            // txb_precoKm
            // 
            txb_precoKm.Location = new Point(164, 114);
            txb_precoKm.Margin = new Padding(3, 4, 3, 4);
            txb_precoKm.Name = "txb_precoKm";
            txb_precoKm.Size = new Size(167, 27);
            txb_precoKm.TabIndex = 17;
            // 
            // txb_precoD
            // 
            txb_precoD.Location = new Point(164, 76);
            txb_precoD.Margin = new Padding(3, 4, 3, 4);
            txb_precoD.Name = "txb_precoD";
            txb_precoD.Size = new Size(167, 27);
            txb_precoD.TabIndex = 16;
            // 
            // cbox_tipoPlano
            // 
            cbox_tipoPlano.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_tipoPlano.FormattingEnabled = true;
            cbox_tipoPlano.Location = new Point(164, 37);
            cbox_tipoPlano.Margin = new Padding(3, 4, 3, 4);
            cbox_tipoPlano.Name = "cbox_tipoPlano";
            cbox_tipoPlano.Size = new Size(167, 28);
            cbox_tipoPlano.TabIndex = 15;
            cbox_tipoPlano.SelectedIndexChanged += cbox_tipoPlano_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 28);
            label1.Name = "label1";
            label1.Size = new Size(157, 20);
            label1.TabIndex = 14;
            label1.Text = "Grupo de Automoveis:";
            // 
            // TelaPlanoDeCobrancaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 399);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(cbox_gpAutomoveis);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Margin = new Padding(3, 4, 3, 4);
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