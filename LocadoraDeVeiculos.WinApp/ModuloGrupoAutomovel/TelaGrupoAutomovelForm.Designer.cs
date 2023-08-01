namespace LocadoraDeVeiculos.WinApp.ModuloGrupoAutomovel
{
    partial class TelaGrupoAutomovelForm
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
            txtNome = new TextBox();
            labelNome = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(329, 126);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 42);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.DialogResult = DialogResult.OK;
            btnSalvar.Location = new Point(215, 126);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 43);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += BtnSalvar_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(91, 39);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(332, 27);
            txtNome.TabIndex = 5;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(23, 46);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(53, 20);
            labelNome.TabIndex = 4;
            labelNome.Text = "Nome:";
            // 
            // TelaGrupoAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 198);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(txtNome);
            Controls.Add(labelNome);
            Name = "TelaGrupoAutomovelForm";
            Text = "TelaGrupoAutomovelForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnSalvar;
        private TextBox txtNome;
        private Label labelNome;
    }
}