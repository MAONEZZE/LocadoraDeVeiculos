namespace LocadoraDeVeiculos.WinApp.ModuloParceiro
{
    partial class TelaParceiroForm
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
            txtNome = new TextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(28, 45);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(53, 20);
            labelNome.TabIndex = 0;
            labelNome.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(96, 38);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(332, 27);
            txtNome.TabIndex = 1;
            // 
            // btnSalvar
            // 
            btnSalvar.DialogResult = DialogResult.OK;
            btnSalvar.Location = new Point(220, 125);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 43);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += BtnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(334, 125);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 42);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // ParceiroTelaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 198);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(txtNome);
            Controls.Add(labelNome);
            Name = "ParceiroTelaForm";
            Text = "ParceiroTelaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelNome;
        private TextBox txtNome;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}