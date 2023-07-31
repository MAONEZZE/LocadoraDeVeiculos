namespace LocadoraDeVeiculos.WinApp.ModuloCupom
{
    partial class TelaCupomForm
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
            labelNome = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNome = new TextBox();
            txtValor = new NumericUpDown();
            txtData = new DateTimePicker();
            txtComboParceiro = new ComboBox();
            BtnSalvar = new Button();
            BtnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)txtValor).BeginInit();
            SuspendLayout();
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(46, 31);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(53, 20);
            labelNome.TabIndex = 0;
            labelNome.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 84);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 1;
            label2.Text = "Valor: R$";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 137);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 2;
            label3.Text = "Vencimento:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 188);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 3;
            label4.Text = "Parceiro:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(106, 24);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(307, 27);
            txtNome.TabIndex = 4;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(106, 76);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(307, 27);
            txtValor.TabIndex = 5;
            // 
            // txtData
            // 
            txtData.Format = DateTimePickerFormat.Short;
            txtData.Location = new Point(106, 128);
            txtData.Name = "txtData";
            txtData.Size = new Size(307, 27);
            txtData.TabIndex = 6;
            // 
            // txtComboParceiro
            // 
            txtComboParceiro.FormattingEnabled = true;
            txtComboParceiro.Location = new Point(106, 180);
            txtComboParceiro.Name = "txtComboParceiro";
            txtComboParceiro.Size = new Size(307, 28);
            txtComboParceiro.TabIndex = 7;
            // 
            // BtnSalvar
            // 
            BtnSalvar.DialogResult = DialogResult.OK;
            BtnSalvar.Location = new Point(202, 244);
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new Size(94, 41);
            BtnSalvar.TabIndex = 8;
            BtnSalvar.Text = "Salvar";
            BtnSalvar.UseVisualStyleBackColor = true;
            BtnSalvar.Click += BtnSalvar_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.DialogResult = DialogResult.Cancel;
            BtnCancelar.Location = new Point(319, 244);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(94, 41);
            BtnCancelar.TabIndex = 9;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaCupomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 312);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnSalvar);
            Controls.Add(txtComboParceiro);
            Controls.Add(txtData);
            Controls.Add(txtValor);
            Controls.Add(txtNome);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labelNome);
            Name = "TelaCupomForm";
            Text = "TelaCupomForm";
            ((System.ComponentModel.ISupportInitialize)txtValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNome;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNome;
        private NumericUpDown txtValor;
        private DateTimePicker txtData;
        private ComboBox txtComboParceiro;
        private Button BtnSalvar;
        private Button BtnCancelar;
    }
}