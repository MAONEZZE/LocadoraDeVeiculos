namespace LocadoraDeVeiculos.WinApp.ModuloTaxaServico
{
    partial class TelaTaxaServicoForm
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
            LabelNome = new Label();
            txtNome = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            rbnDiario = new RadioButton();
            rbnFixo = new RadioButton();
            btnCancelar = new Button();
            btnSalvar = new Button();
            txtPreco = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPreco).BeginInit();
            SuspendLayout();
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(20, 34);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(43, 15);
            LabelNome.TabIndex = 0;
            LabelNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(80, 29);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(284, 23);
            txtNome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 69);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 2;
            label1.Text = "Preço:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbnDiario);
            groupBox1.Controls.Add(rbnFixo);
            groupBox1.Location = new Point(80, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 74);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Plano de Cobrança ";
            // 
            // rbnDiario
            // 
            rbnDiario.AutoSize = true;
            rbnDiario.Location = new Point(129, 37);
            rbnDiario.Name = "rbnDiario";
            rbnDiario.Size = new Size(109, 19);
            rbnDiario.TabIndex = 1;
            rbnDiario.TabStop = true;
            rbnDiario.Text = "Cobrança Diária";
            rbnDiario.UseVisualStyleBackColor = true;
            // 
            // rbnFixo
            // 
            rbnFixo.AutoSize = true;
            rbnFixo.Location = new Point(29, 37);
            rbnFixo.Name = "rbnFixo";
            rbnFixo.Size = new Size(80, 19);
            rbnFixo.TabIndex = 0;
            rbnFixo.TabStop = true;
            rbnFixo.Text = "Preço Fixo";
            rbnFixo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(282, 207);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 32);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.DialogResult = DialogResult.OK;
            btnSalvar.Location = new Point(182, 207);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(82, 32);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtPreco
            // 
            txtPreco.DecimalPlaces = 2;
            txtPreco.Location = new Point(80, 66);
            txtPreco.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(109, 23);
            txtPreco.TabIndex = 11;
            // 
            // TelaTaxaServicoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 270);
            Controls.Add(txtPreco);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(LabelNome);
            Name = "TelaTaxaServicoForm";
            Text = "TelaTaxaServicoForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPreco).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelNome;
        private TextBox txtNome;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton rbnDiario;
        private RadioButton rbnFixo;
        private Button btnCancelar;
        private Button btnSalvar;
        private NumericUpDown txtPreco;
    }
}