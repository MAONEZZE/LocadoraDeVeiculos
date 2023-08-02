namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    partial class TelaAutomovelForm
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
            openFileDialog = new OpenFileDialog();
            pictureBoxFoto = new PictureBox();
            labelFoto = new Label();
            labelGrupo = new Label();
            labelModelo = new Label();
            comboBoxGrupo = new ComboBox();
            txtModelo = new TextBox();
            txtMarca = new TextBox();
            txtCor = new TextBox();
            comboBoxCombustivel = new ComboBox();
            txtLitros = new NumericUpDown();
            bntBuscarFoto = new Button();
            BtnSalvar = new Button();
            btnCancelar = new Button();
            labelMarca = new Label();
            labelCor = new Label();
            labelCombustivel = new Label();
            labelCapTanque = new Label();
            labelTanque = new Label();
            labelAno = new Label();
            txtAno = new NumericUpDown();
            labelPLaca = new Label();
            txtPlaca = new TextBox();
            labelKm = new Label();
            txtKm = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLitros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAno).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKm).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // pictureBoxFoto
            // 
            pictureBoxFoto.ErrorImage = null;
            pictureBoxFoto.Image = Properties.Resources.Captura_de_tela_2023_08_01_202617;
            pictureBoxFoto.InitialImage = null;
            pictureBoxFoto.Location = new Point(115, 12);
            pictureBoxFoto.Name = "pictureBoxFoto";
            pictureBoxFoto.Size = new Size(145, 133);
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxFoto.TabIndex = 0;
            pictureBoxFoto.TabStop = false;
            // 
            // labelFoto
            // 
            labelFoto.AutoSize = true;
            labelFoto.Location = new Point(60, 125);
            labelFoto.Name = "labelFoto";
            labelFoto.Size = new Size(42, 20);
            labelFoto.TabIndex = 1;
            labelFoto.Text = "Foto:";
            // 
            // labelGrupo
            // 
            labelGrupo.AutoSize = true;
            labelGrupo.Location = new Point(49, 177);
            labelGrupo.Name = "labelGrupo";
            labelGrupo.Size = new Size(53, 20);
            labelGrupo.TabIndex = 2;
            labelGrupo.Text = "Grupo:";
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(38, 228);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(64, 20);
            labelModelo.TabIndex = 3;
            labelModelo.Text = "Modelo:";
            // 
            // comboBoxGrupo
            // 
            comboBoxGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGrupo.FormattingEnabled = true;
            comboBoxGrupo.Location = new Point(108, 169);
            comboBoxGrupo.Name = "comboBoxGrupo";
            comboBoxGrupo.Size = new Size(339, 28);
            comboBoxGrupo.TabIndex = 2;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(110, 221);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(337, 27);
            txtModelo.TabIndex = 3;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(110, 272);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(337, 27);
            txtMarca.TabIndex = 4;
            // 
            // txtCor
            // 
            txtCor.Location = new Point(108, 318);
            txtCor.Name = "txtCor";
            txtCor.Size = new Size(339, 27);
            txtCor.TabIndex = 5;
            // 
            // comboBoxCombustivel
            // 
            comboBoxCombustivel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCombustivel.FormattingEnabled = true;
            comboBoxCombustivel.Location = new Point(108, 406);
            comboBoxCombustivel.Name = "comboBoxCombustivel";
            comboBoxCombustivel.Size = new Size(152, 28);
            comboBoxCombustivel.TabIndex = 8;
            // 
            // txtLitros
            // 
            txtLitros.Location = new Point(332, 407);
            txtLitros.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            txtLitros.Name = "txtLitros";
            txtLitros.Size = new Size(113, 27);
            txtLitros.TabIndex = 9;
            // 
            // bntBuscarFoto
            // 
            bntBuscarFoto.Location = new Point(332, 103);
            bntBuscarFoto.Name = "bntBuscarFoto";
            bntBuscarFoto.Size = new Size(113, 42);
            bntBuscarFoto.TabIndex = 1;
            bntBuscarFoto.Text = "Buscar";
            bntBuscarFoto.UseVisualStyleBackColor = true;
            bntBuscarFoto.Click += BntBuscarFoto_Click;
            // 
            // BtnSalvar
            // 
            BtnSalvar.DialogResult = DialogResult.OK;
            BtnSalvar.Location = new Point(241, 538);
            BtnSalvar.Name = "BtnSalvar";
            BtnSalvar.Size = new Size(94, 45);
            BtnSalvar.TabIndex = 11;
            BtnSalvar.Text = "Salvar";
            BtnSalvar.UseVisualStyleBackColor = true;
            BtnSalvar.Click += BtnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(353, 538);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 45);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // labelMarca
            // 
            labelMarca.AutoSize = true;
            labelMarca.Location = new Point(49, 279);
            labelMarca.Name = "labelMarca";
            labelMarca.Size = new Size(53, 20);
            labelMarca.TabIndex = 13;
            labelMarca.Text = "Marca:";
            // 
            // labelCor
            // 
            labelCor.AutoSize = true;
            labelCor.Location = new Point(67, 325);
            labelCor.Name = "labelCor";
            labelCor.Size = new Size(35, 20);
            labelCor.TabIndex = 14;
            labelCor.Text = "Cor:";
            // 
            // labelCombustivel
            // 
            labelCombustivel.AutoSize = true;
            labelCombustivel.Location = new Point(8, 414);
            labelCombustivel.Name = "labelCombustivel";
            labelCombustivel.Size = new Size(94, 20);
            labelCombustivel.TabIndex = 15;
            labelCombustivel.Text = "Combustivel:";
            // 
            // labelCapTanque
            // 
            labelCapTanque.AutoSize = true;
            labelCapTanque.Location = new Point(13, 511);
            labelCapTanque.Name = "labelCapTanque";
            labelCapTanque.Size = new Size(0, 20);
            labelCapTanque.TabIndex = 16;
            // 
            // labelTanque
            // 
            labelTanque.AutoSize = true;
            labelTanque.Location = new Point(278, 414);
            labelTanque.Name = "labelTanque";
            labelTanque.Size = new Size(48, 20);
            labelTanque.TabIndex = 18;
            labelTanque.Text = "Litros:";
            // 
            // labelAno
            // 
            labelAno.AutoSize = true;
            labelAno.Location = new Point(278, 367);
            labelAno.Name = "labelAno";
            labelAno.Size = new Size(39, 20);
            labelAno.TabIndex = 19;
            labelAno.Text = "Ano:";
            // 
            // txtAno
            // 
            txtAno.Location = new Point(332, 360);
            txtAno.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(113, 27);
            txtAno.TabIndex = 7;
            // 
            // labelPLaca
            // 
            labelPLaca.AutoSize = true;
            labelPLaca.Location = new Point(55, 463);
            labelPLaca.Name = "labelPLaca";
            labelPLaca.Size = new Size(47, 20);
            labelPLaca.TabIndex = 21;
            labelPLaca.Text = "Placa:";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(110, 456);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(150, 27);
            txtPlaca.TabIndex = 10;
            // 
            // labelKm
            // 
            labelKm.AutoSize = true;
            labelKm.Location = new Point(68, 367);
            labelKm.Name = "labelKm";
            labelKm.Size = new Size(34, 20);
            labelKm.TabIndex = 22;
            labelKm.Text = "Km:";
            // 
            // txtKm
            // 
            txtKm.Location = new Point(110, 360);
            txtKm.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            txtKm.Name = "txtKm";
            txtKm.Size = new Size(150, 27);
            txtKm.TabIndex = 6;
            // 
            // TelaAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 612);
            Controls.Add(txtKm);
            Controls.Add(labelKm);
            Controls.Add(txtPlaca);
            Controls.Add(labelPLaca);
            Controls.Add(txtAno);
            Controls.Add(labelAno);
            Controls.Add(labelTanque);
            Controls.Add(labelCapTanque);
            Controls.Add(labelCombustivel);
            Controls.Add(labelCor);
            Controls.Add(labelMarca);
            Controls.Add(btnCancelar);
            Controls.Add(BtnSalvar);
            Controls.Add(bntBuscarFoto);
            Controls.Add(txtLitros);
            Controls.Add(comboBoxCombustivel);
            Controls.Add(txtCor);
            Controls.Add(txtMarca);
            Controls.Add(txtModelo);
            Controls.Add(comboBoxGrupo);
            Controls.Add(labelModelo);
            Controls.Add(labelGrupo);
            Controls.Add(labelFoto);
            Controls.Add(pictureBoxFoto);
            Name = "TelaAutomovelForm";
            Text = "TelaAutomovelForm";
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLitros).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAno).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog;
        private PictureBox pictureBoxFoto;
        private Label labelFoto;
        private Label labelGrupo;
        private Label labelModelo;
        private ComboBox comboBoxGrupo;
        private TextBox txtModelo;
        private TextBox txtMarca;
        private TextBox txtCor;
        private ComboBox comboBoxCombustivel;
        private NumericUpDown txtLitros;
        private Button bntBuscarFoto;
        private Button BtnSalvar;
        private Button btnCancelar;
        private Label labelMarca;
        private Label labelCor;
        private Label labelCombustivel;
        private Label labelCapTanque;
        private Label labelTanque;
        private Label labelAno;
        private NumericUpDown txtAno;
        private Label labelPLaca;
        private TextBox txtPlaca;
        private Label labelKm;
        private NumericUpDown txtKm;
    }
}