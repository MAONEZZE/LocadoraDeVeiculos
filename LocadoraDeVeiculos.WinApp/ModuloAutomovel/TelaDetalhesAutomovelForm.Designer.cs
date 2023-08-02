namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    partial class TelaDetalhesAutomovelForm
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
            labelKm = new Label();
            txtPlaca = new TextBox();
            labelPLaca = new Label();
            labelAno = new Label();
            labelTanque = new Label();
            labelCombustivel = new Label();
            labelCor = new Label();
            labelMarca = new Label();
            BtnOk = new Button();
            txtCor = new TextBox();
            txtMarca = new TextBox();
            txtModelo = new TextBox();
            labelModelo = new Label();
            labelGrupo = new Label();
            labelFoto = new Label();
            pictureBoxFoto = new PictureBox();
            txtGrupo = new TextBox();
            txtKm = new TextBox();
            txtAno = new TextBox();
            txtCombustivel = new TextBox();
            txtLitros = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).BeginInit();
            SuspendLayout();
            // 
            // labelKm
            // 
            labelKm.AutoSize = true;
            labelKm.Location = new Point(89, 391);
            labelKm.Name = "labelKm";
            labelKm.Size = new Size(34, 20);
            labelKm.TabIndex = 45;
            labelKm.Text = "Km:";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(131, 480);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.ReadOnly = true;
            txtPlaca.Size = new Size(150, 27);
            txtPlaca.TabIndex = 36;
            txtPlaca.TabStop = false;
            // 
            // labelPLaca
            // 
            labelPLaca.AutoSize = true;
            labelPLaca.Location = new Point(76, 487);
            labelPLaca.Name = "labelPLaca";
            labelPLaca.Size = new Size(47, 20);
            labelPLaca.TabIndex = 44;
            labelPLaca.Text = "Placa:";
            // 
            // labelAno
            // 
            labelAno.AutoSize = true;
            labelAno.Location = new Point(299, 391);
            labelAno.Name = "labelAno";
            labelAno.Size = new Size(39, 20);
            labelAno.TabIndex = 43;
            labelAno.Text = "Ano:";
            // 
            // labelTanque
            // 
            labelTanque.AutoSize = true;
            labelTanque.Location = new Point(299, 438);
            labelTanque.Name = "labelTanque";
            labelTanque.Size = new Size(48, 20);
            labelTanque.TabIndex = 42;
            labelTanque.Text = "Litros:";
            // 
            // labelCombustivel
            // 
            labelCombustivel.AutoSize = true;
            labelCombustivel.Location = new Point(29, 438);
            labelCombustivel.Name = "labelCombustivel";
            labelCombustivel.Size = new Size(94, 20);
            labelCombustivel.TabIndex = 41;
            labelCombustivel.Text = "Combustivel:";
            // 
            // labelCor
            // 
            labelCor.AutoSize = true;
            labelCor.Location = new Point(88, 349);
            labelCor.Name = "labelCor";
            labelCor.Size = new Size(35, 20);
            labelCor.TabIndex = 40;
            labelCor.Text = "Cor:";
            // 
            // labelMarca
            // 
            labelMarca.AutoSize = true;
            labelMarca.Location = new Point(70, 303);
            labelMarca.Name = "labelMarca";
            labelMarca.Size = new Size(53, 20);
            labelMarca.TabIndex = 39;
            labelMarca.Text = "Marca:";
            // 
            // BtnOk
            // 
            BtnOk.DialogResult = DialogResult.OK;
            BtnOk.Location = new Point(372, 531);
            BtnOk.Name = "BtnOk";
            BtnOk.Size = new Size(94, 45);
            BtnOk.TabIndex = 37;
            BtnOk.Text = "Ok";
            BtnOk.UseVisualStyleBackColor = true;
            BtnOk.Click += BtnOk_Click;
            // 
            // txtCor
            // 
            txtCor.Location = new Point(129, 342);
            txtCor.Name = "txtCor";
            txtCor.ReadOnly = true;
            txtCor.Size = new Size(339, 27);
            txtCor.TabIndex = 31;
            txtCor.TabStop = false;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(131, 296);
            txtMarca.Name = "txtMarca";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(337, 27);
            txtMarca.TabIndex = 30;
            txtMarca.TabStop = false;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(131, 245);
            txtModelo.Name = "txtModelo";
            txtModelo.ReadOnly = true;
            txtModelo.Size = new Size(337, 27);
            txtModelo.TabIndex = 29;
            txtModelo.TabStop = false;
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(59, 252);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(64, 20);
            labelModelo.TabIndex = 28;
            labelModelo.Text = "Modelo:";
            // 
            // labelGrupo
            // 
            labelGrupo.AutoSize = true;
            labelGrupo.Location = new Point(70, 201);
            labelGrupo.Name = "labelGrupo";
            labelGrupo.Size = new Size(53, 20);
            labelGrupo.TabIndex = 26;
            labelGrupo.Text = "Grupo:";
            // 
            // labelFoto
            // 
            labelFoto.AutoSize = true;
            labelFoto.Location = new Point(81, 149);
            labelFoto.Name = "labelFoto";
            labelFoto.Size = new Size(42, 20);
            labelFoto.TabIndex = 25;
            labelFoto.Text = "Foto:";
            // 
            // pictureBoxFoto
            // 
            pictureBoxFoto.ErrorImage = null;
            pictureBoxFoto.InitialImage = Properties.Resources.Captura_de_tela_2023_08_01_202617;
            pictureBoxFoto.Location = new Point(136, 36);
            pictureBoxFoto.Name = "pictureBoxFoto";
            pictureBoxFoto.Size = new Size(145, 133);
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFoto.TabIndex = 23;
            pictureBoxFoto.TabStop = false;
            // 
            // txtGrupo
            // 
            txtGrupo.Location = new Point(131, 201);
            txtGrupo.Name = "txtGrupo";
            txtGrupo.ReadOnly = true;
            txtGrupo.Size = new Size(335, 27);
            txtGrupo.TabIndex = 46;
            txtGrupo.TabStop = false;
            // 
            // txtKm
            // 
            txtKm.Location = new Point(131, 388);
            txtKm.Name = "txtKm";
            txtKm.ReadOnly = true;
            txtKm.Size = new Size(150, 27);
            txtKm.TabIndex = 47;
            txtKm.TabStop = false;
            // 
            // txtAno
            // 
            txtAno.Location = new Point(344, 384);
            txtAno.Name = "txtAno";
            txtAno.ReadOnly = true;
            txtAno.Size = new Size(125, 27);
            txtAno.TabIndex = 48;
            txtAno.TabStop = false;
            // 
            // txtCombustivel
            // 
            txtCombustivel.Location = new Point(131, 431);
            txtCombustivel.Name = "txtCombustivel";
            txtCombustivel.ReadOnly = true;
            txtCombustivel.Size = new Size(150, 27);
            txtCombustivel.TabIndex = 49;
            txtCombustivel.TabStop = false;
            // 
            // txtLitros
            // 
            txtLitros.Location = new Point(353, 435);
            txtLitros.Name = "txtLitros";
            txtLitros.ReadOnly = true;
            txtLitros.Size = new Size(116, 27);
            txtLitros.TabIndex = 50;
            txtLitros.TabStop = false;
            // 
            // TelaDetalhesAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 608);
            Controls.Add(txtLitros);
            Controls.Add(txtCombustivel);
            Controls.Add(txtAno);
            Controls.Add(txtKm);
            Controls.Add(txtGrupo);
            Controls.Add(labelKm);
            Controls.Add(txtPlaca);
            Controls.Add(labelPLaca);
            Controls.Add(labelAno);
            Controls.Add(labelTanque);
            Controls.Add(labelCombustivel);
            Controls.Add(labelCor);
            Controls.Add(labelMarca);
            Controls.Add(BtnOk);
            Controls.Add(txtCor);
            Controls.Add(txtMarca);
            Controls.Add(txtModelo);
            Controls.Add(labelModelo);
            Controls.Add(labelGrupo);
            Controls.Add(labelFoto);
            Controls.Add(pictureBoxFoto);
            Name = "TelaDetalhesAutomovelForm";
            Text = "TelaDetalhesAutomovelForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelKm;
        private TextBox txtPlaca;
        private Label labelPLaca;
        private Label labelAno;
        private Label labelTanque;
        private Label labelCombustivel;
        private Label labelCor;
        private Label labelMarca;
        private Button BtnOk;
        private TextBox txtCor;
        private TextBox txtMarca;
        private TextBox txtModelo;
        private Label labelModelo;
        private Label labelGrupo;
        private Label labelFoto;
        private PictureBox pictureBoxFoto;
        private TextBox txtGrupo;
        private TextBox txtKm;
        private TextBox txtAno;
        private TextBox txtCombustivel;
        private TextBox txtLitros;
    }
}