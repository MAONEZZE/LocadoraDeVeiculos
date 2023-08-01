namespace LocadoraDeVeiculos.WinApp.ModuloGrupoAutomovel
{
    partial class TabelaGrupoAutomovelControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridGrupoVeiculo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridGrupoVeiculo).BeginInit();
            SuspendLayout();
            // 
            // gridGrupoVeiculo
            // 
            gridGrupoVeiculo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridGrupoVeiculo.Dock = DockStyle.Fill;
            gridGrupoVeiculo.Location = new Point(0, 0);
            gridGrupoVeiculo.Name = "gridGrupoVeiculo";
            gridGrupoVeiculo.RowHeadersWidth = 51;
            gridGrupoVeiculo.RowTemplate.Height = 29;
            gridGrupoVeiculo.Size = new Size(150, 150);
            gridGrupoVeiculo.TabIndex = 0;
            // 
            // TabelaGrupoAutomovelControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridGrupoVeiculo);
            Name = "TabelaGrupoAutomovelControl";
            ((System.ComponentModel.ISupportInitialize)gridGrupoVeiculo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridGrupoVeiculo;
    }
}
