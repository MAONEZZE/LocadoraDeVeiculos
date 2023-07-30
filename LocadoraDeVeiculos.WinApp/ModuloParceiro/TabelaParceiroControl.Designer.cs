namespace LocadoraDeVeiculos.WinApp.ModuloParceiro
{
    partial class TabelaParceiroControl
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
            gridParceiro = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridParceiro).BeginInit();
            SuspendLayout();
            // 
            // gridParceiro
            // 
            gridParceiro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridParceiro.Dock = DockStyle.Fill;
            gridParceiro.Location = new Point(0, 0);
            gridParceiro.Name = "gridParceiro";
            gridParceiro.RowHeadersWidth = 51;
            gridParceiro.RowTemplate.Height = 29;
            gridParceiro.Size = new Size(150, 150);
            gridParceiro.TabIndex = 0;
            // 
            // TabelaParceiroControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridParceiro);
            Name = "TabelaParceiroControl";
            ((System.ComponentModel.ISupportInitialize)gridParceiro).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridParceiro;
    }
}
