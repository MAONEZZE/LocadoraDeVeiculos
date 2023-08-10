namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    partial class TelaFiltroAutomovelForm
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            comboGrupo = new ComboBox();
            btnFiltrar = new Button();
            btnCancelar = new Button();
            checkTodos = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkTodos);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboGrupo);
            groupBox1.Location = new Point(20, 19);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(334, 172);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrar Automóveis";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 48);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 1;
            label1.Text = "Selecione o grupo.";
            // 
            // comboGrupo
            // 
            comboGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboGrupo.FormattingEnabled = true;
            comboGrupo.Location = new Point(26, 79);
            comboGrupo.Name = "comboGrupo";
            comboGrupo.Size = new Size(273, 28);
            comboGrupo.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            btnFiltrar.DialogResult = DialogResult.OK;
            btnFiltrar.Location = new Point(141, 226);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(94, 46);
            btnFiltrar.TabIndex = 1;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(260, 226);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 45);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // checkTodos
            // 
            checkTodos.AutoSize = true;
            checkTodos.Location = new Point(28, 130);
            checkTodos.Name = "checkTodos";
            checkTodos.Size = new Size(118, 24);
            checkTodos.TabIndex = 2;
            checkTodos.Text = "Buscar Todos";
            checkTodos.UseVisualStyleBackColor = true;
            checkTodos.CheckedChanged += checkTodos_CheckedChanged;
            // 
            // TelaFiltroAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 298);
            Controls.Add(btnCancelar);
            Controls.Add(btnFiltrar);
            Controls.Add(groupBox1);
            Name = "TelaFiltroAutomovelForm";
            Text = "TelaFiltroAutomovelForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ComboBox comboGrupo;
        private Button btnFiltrar;
        private Button btnCancelar;
        private CheckBox checkTodos;
    }
}