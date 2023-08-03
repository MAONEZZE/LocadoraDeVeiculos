namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracaoPreco
{
    partial class TelaConfigurarPrecoForm
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
            labelGasolina = new Label();
            labelEtanol = new Label();
            labelDiesel = new Label();
            txtGasolina = new NumericUpDown();
            txtEtanol = new NumericUpDown();
            txtDiesel = new NumericUpDown();
            BtnSalvar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)txtGasolina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEtanol).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).BeginInit();
            SuspendLayout();
            // 
            // labelGasolina
            // 
            labelGasolina.AutoSize = true;
            labelGasolina.Location = new Point(80, 38);
            labelGasolina.Name = "labelGasolina";
            labelGasolina.Size = new Size(69, 20);
            labelGasolina.TabIndex = 0;
            labelGasolina.Text = "Gasolina:";
            // 
            // labelEtanol
            // 
            labelEtanol.AutoSize = true;
            labelEtanol.Location = new Point(80, 79);
            labelEtanol.Name = "labelEtanol";
            labelEtanol.Size = new Size(54, 20);
            labelEtanol.TabIndex = 1;
            labelEtanol.Text = "Etanol:";
            // 
            // labelDiesel
            // 
            labelDiesel.AutoSize = true;
            labelDiesel.Location = new Point(80, 119);
            labelDiesel.Name = "labelDiesel";
            labelDiesel.Size = new Size(53, 20);
            labelDiesel.TabIndex = 2;
            labelDiesel.Text = "Diesel:";
            // 
            // txtGasolina
            // 
            txtGasolina.DecimalPlaces = 2;
            txtGasolina.Location = new Point(154, 31);
            txtGasolina.Name = "txtGasolina";
            txtGasolina.Size = new Size(150, 27);
            txtGasolina.TabIndex = 3;
            // 
            // txtEtanol
            // 
            txtEtanol.DecimalPlaces = 2;
            txtEtanol.Location = new Point(155, 72);
            txtEtanol.Name = "txtEtanol";
            txtEtanol.Size = new Size(150, 27);
            txtEtanol.TabIndex = 4;
            // 
            // txtDiesel
            // 
            txtDiesel.DecimalPlaces = 2;
            txtDiesel.Location = new Point(154, 112);
            txtDiesel.Name = "txtDiesel";
            txtDiesel.Size = new Size(150, 27);
            txtDiesel.TabIndex = 5;
            // 
            // BtnSalvar
            // 
            BtnSalvar.DialogResult = DialogResult.OK;
            BtnSalvar.Location = new Point(80, 181);
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new Size(94, 41);
            BtnSalvar.TabIndex = 6;
            BtnSalvar.Text = "Salvar";
            BtnSalvar.UseVisualStyleBackColor = true;
            BtnSalvar.Click += ButtonSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(211, 181);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 41);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaConfigurarPrecoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 265);
            Controls.Add(btnCancelar);
            Controls.Add(BtnSalvar);
            Controls.Add(txtDiesel);
            Controls.Add(txtEtanol);
            Controls.Add(txtGasolina);
            Controls.Add(labelDiesel);
            Controls.Add(labelEtanol);
            Controls.Add(labelGasolina);
            Name = "TelaConfigurarPrecoForm";
            Text = "Configurar Preço Combustível";
            ((System.ComponentModel.ISupportInitialize)txtGasolina).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEtanol).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelGasolina;
        private Label labelEtanol;
        private Label labelDiesel;
        private NumericUpDown txtGasolina;
        private NumericUpDown txtEtanol;
        private NumericUpDown txtDiesel;
        private Button BtnSalvar;
        private Button btnCancelar;
    }
}