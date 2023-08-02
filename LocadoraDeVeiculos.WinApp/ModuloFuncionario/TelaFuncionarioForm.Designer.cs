namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    partial class TelaFuncionarioForm
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
            txtNome = new TextBox();
            LabelNome = new Label();
            label1 = new Label();
            txtDataAdmissao = new DateTimePicker();
            label2 = new Label();
            txtSalario = new TextBox();
            btnCancelar = new Button();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(92, 28);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(284, 23);
            txtNome.TabIndex = 3;
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(32, 33);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(43, 15);
            LabelNome.TabIndex = 2;
            LabelNome.Text = "Nome:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 67);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 4;
            label1.Text = "Admissão:";
            // 
            // txtDataAdmissao
            // 
            txtDataAdmissao.Format = DateTimePickerFormat.Short;
            txtDataAdmissao.Location = new Point(92, 61);
            txtDataAdmissao.Name = "txtDataAdmissao";
            txtDataAdmissao.Size = new Size(97, 23);
            txtDataAdmissao.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 97);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 6;
            label2.Text = "Salário:";
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(92, 97);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(97, 23);
            txtSalario.TabIndex = 7;
            txtSalario.KeyPress += txtSalario_KeyPress;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(294, 149);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 32);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.DialogResult = DialogResult.OK;
            btnSalvar.Location = new Point(194, 149);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(82, 32);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // TelaFuncionarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 196);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(txtSalario);
            Controls.Add(label2);
            Controls.Add(txtDataAdmissao);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(LabelNome);
            Name = "TelaFuncionarioForm";
            Text = "TelaFuncionarioForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private Label LabelNome;
        private Label label1;
        private DateTimePicker txtDataAdmissao;
        private Label label2;
        private TextBox txtSalario;
        private Button btnCancelar;
        private Button btnSalvar;
    }
}