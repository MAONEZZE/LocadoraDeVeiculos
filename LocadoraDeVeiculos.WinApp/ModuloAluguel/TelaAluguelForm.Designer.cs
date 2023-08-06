namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    partial class TelaAluguelForm
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
            label1 = new Label();
            cbxFuncionario = new ComboBox();
            cbxCliente = new ComboBox();
            label2 = new Label();
            cbxGrupoAutomovel = new ComboBox();
            label3 = new Label();
            cbxPlanoDeCobranca = new ComboBox();
            label4 = new Label();
            cbxCondutor = new ComboBox();
            label5 = new Label();
            cbxAutomovel = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            txtQuilometragem = new TextBox();
            label8 = new Label();
            txtDataLocacao = new DateTimePicker();
            txtDevolucaoPrevista = new DateTimePicker();
            label9 = new Label();
            txtCupom = new TextBox();
            label10 = new Label();
            btnCupom = new Button();
            txtDataDevolucao = new DateTimePicker();
            label11 = new Label();
            cbxNivelTanque = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            txtKMPercorrido = new TextBox();
            tctrlTaxas = new TabControl();
            tbTaxasSelecionadas = new TabPage();
            clbxTaxasSelecionadas = new CheckedListBox();
            tbTaxasAdicionais = new TabPage();
            clbxTaxasAdicionais = new CheckedListBox();
            gbDevolucao = new GroupBox();
            gbLocacao = new GroupBox();
            tctrlTaxas.SuspendLayout();
            tbTaxasSelecionadas.SuspendLayout();
            tbTaxasAdicionais.SuspendLayout();
            gbDevolucao.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(577, 523);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 32);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.DialogResult = DialogResult.OK;
            btnSalvar.Location = new Point(477, 523);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(82, 32);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(40, 24);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 12;
            label1.Text = "Funcionário:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxFuncionario
            // 
            cbxFuncionario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFuncionario.FormattingEnabled = true;
            cbxFuncionario.Location = new Point(146, 25);
            cbxFuncionario.Name = "cbxFuncionario";
            cbxFuncionario.Size = new Size(196, 23);
            cbxFuncionario.TabIndex = 1;
            // 
            // cbxCliente
            // 
            cbxCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCliente.FormattingEnabled = true;
            cbxCliente.Location = new Point(146, 63);
            cbxCliente.Name = "cbxCliente";
            cbxCliente.Size = new Size(196, 23);
            cbxCliente.TabIndex = 2;
            // 
            // label2
            // 
            label2.Location = new Point(40, 62);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 14;
            label2.Text = "Cliente:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxGrupoAutomovel
            // 
            cbxGrupoAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGrupoAutomovel.FormattingEnabled = true;
            cbxGrupoAutomovel.Location = new Point(146, 101);
            cbxGrupoAutomovel.Name = "cbxGrupoAutomovel";
            cbxGrupoAutomovel.Size = new Size(196, 23);
            cbxGrupoAutomovel.TabIndex = 4;
            // 
            // label3
            // 
            label3.Location = new Point(7, 100);
            label3.Name = "label3";
            label3.Size = new Size(133, 23);
            label3.TabIndex = 16;
            label3.Text = "Grupo de Automóveis:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxPlanoDeCobranca
            // 
            cbxPlanoDeCobranca.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPlanoDeCobranca.FormattingEnabled = true;
            cbxPlanoDeCobranca.Location = new Point(146, 139);
            cbxPlanoDeCobranca.Name = "cbxPlanoDeCobranca";
            cbxPlanoDeCobranca.Size = new Size(196, 23);
            cbxPlanoDeCobranca.TabIndex = 6;
            // 
            // label4
            // 
            label4.Location = new Point(22, 138);
            label4.Name = "label4";
            label4.Size = new Size(118, 23);
            label4.TabIndex = 18;
            label4.Text = "Plano de Cobrança:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxCondutor
            // 
            cbxCondutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCondutor.FormattingEnabled = true;
            cbxCondutor.Location = new Point(463, 64);
            cbxCondutor.Name = "cbxCondutor";
            cbxCondutor.Size = new Size(196, 23);
            cbxCondutor.TabIndex = 3;
            // 
            // label5
            // 
            label5.Location = new Point(392, 63);
            label5.Name = "label5";
            label5.Size = new Size(65, 23);
            label5.TabIndex = 20;
            label5.Text = "Condutor:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxAutomovel
            // 
            cbxAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxAutomovel.FormattingEnabled = true;
            cbxAutomovel.Location = new Point(463, 101);
            cbxAutomovel.Name = "cbxAutomovel";
            cbxAutomovel.Size = new Size(196, 23);
            cbxAutomovel.TabIndex = 5;
            // 
            // label6
            // 
            label6.Location = new Point(385, 100);
            label6.Name = "label6";
            label6.Size = new Size(72, 23);
            label6.TabIndex = 22;
            label6.Text = "Automóvel:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Location = new Point(359, 140);
            label7.Name = "label7";
            label7.Size = new Size(98, 23);
            label7.TabIndex = 24;
            label7.Text = "KM Automóvel:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtQuilometragem
            // 
            txtQuilometragem.Location = new Point(463, 139);
            txtQuilometragem.Name = "txtQuilometragem";
            txtQuilometragem.ReadOnly = true;
            txtQuilometragem.Size = new Size(100, 23);
            txtQuilometragem.TabIndex = 25;
            txtQuilometragem.TabStop = false;
            // 
            // label8
            // 
            label8.Location = new Point(54, 177);
            label8.Name = "label8";
            label8.Size = new Size(86, 23);
            label8.TabIndex = 26;
            label8.Text = "Data Locação:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDataLocacao
            // 
            txtDataLocacao.Format = DateTimePickerFormat.Short;
            txtDataLocacao.Location = new Point(146, 177);
            txtDataLocacao.Name = "txtDataLocacao";
            txtDataLocacao.Size = new Size(196, 23);
            txtDataLocacao.TabIndex = 7;
            // 
            // txtDevolucaoPrevista
            // 
            txtDevolucaoPrevista.Format = DateTimePickerFormat.Short;
            txtDevolucaoPrevista.Location = new Point(463, 178);
            txtDevolucaoPrevista.Name = "txtDevolucaoPrevista";
            txtDevolucaoPrevista.Size = new Size(196, 23);
            txtDevolucaoPrevista.TabIndex = 8;
            // 
            // label9
            // 
            label9.Location = new Point(344, 178);
            label9.Name = "label9";
            label9.Size = new Size(113, 23);
            label9.TabIndex = 28;
            label9.Text = "Devolução Prevista:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCupom
            // 
            txtCupom.Location = new Point(146, 216);
            txtCupom.Name = "txtCupom";
            txtCupom.Size = new Size(100, 23);
            txtCupom.TabIndex = 9;
            // 
            // label10
            // 
            label10.Location = new Point(54, 215);
            label10.Name = "label10";
            label10.Size = new Size(86, 23);
            label10.TabIndex = 31;
            label10.Text = "Cupom:";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnCupom
            // 
            btnCupom.Location = new Point(260, 210);
            btnCupom.Name = "btnCupom";
            btnCupom.Size = new Size(96, 32);
            btnCupom.TabIndex = 10;
            btnCupom.Text = "Aplicar Cupom";
            btnCupom.UseVisualStyleBackColor = true;
            // 
            // txtDataDevolucao
            // 
            txtDataDevolucao.Format = DateTimePickerFormat.Short;
            txtDataDevolucao.Location = new Point(110, 19);
            txtDataDevolucao.Name = "txtDataDevolucao";
            txtDataDevolucao.Size = new Size(196, 23);
            txtDataDevolucao.TabIndex = 11;
            // 
            // label11
            // 
            label11.Location = new Point(6, 19);
            label11.Name = "label11";
            label11.Size = new Size(98, 23);
            label11.TabIndex = 33;
            label11.Text = "Data Devolução:";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxNivelTanque
            // 
            cbxNivelTanque.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxNivelTanque.FormattingEnabled = true;
            cbxNivelTanque.Location = new Point(110, 57);
            cbxNivelTanque.Name = "cbxNivelTanque";
            cbxNivelTanque.Size = new Size(196, 23);
            cbxNivelTanque.TabIndex = 13;
            // 
            // label12
            // 
            label12.Location = new Point(6, 56);
            label12.Name = "label12";
            label12.Size = new Size(98, 23);
            label12.TabIndex = 35;
            label12.Text = "Nível do Tanque:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Location = new Point(335, 19);
            label13.Name = "label13";
            label13.Size = new Size(86, 23);
            label13.TabIndex = 38;
            label13.Text = "KM Percorrido:";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtKMPercorrido
            // 
            txtKMPercorrido.Location = new Point(427, 20);
            txtKMPercorrido.Name = "txtKMPercorrido";
            txtKMPercorrido.Size = new Size(100, 23);
            txtKMPercorrido.TabIndex = 12;
            // 
            // tctrlTaxas
            // 
            tctrlTaxas.Controls.Add(tbTaxasSelecionadas);
            tctrlTaxas.Controls.Add(tbTaxasAdicionais);
            tctrlTaxas.Location = new Point(46, 347);
            tctrlTaxas.Name = "tctrlTaxas";
            tctrlTaxas.SelectedIndex = 0;
            tctrlTaxas.Size = new Size(613, 160);
            tctrlTaxas.TabIndex = 39;
            // 
            // tbTaxasSelecionadas
            // 
            tbTaxasSelecionadas.Controls.Add(clbxTaxasSelecionadas);
            tbTaxasSelecionadas.Location = new Point(4, 24);
            tbTaxasSelecionadas.Name = "tbTaxasSelecionadas";
            tbTaxasSelecionadas.Padding = new Padding(3);
            tbTaxasSelecionadas.Size = new Size(605, 132);
            tbTaxasSelecionadas.TabIndex = 0;
            tbTaxasSelecionadas.Text = "Taxas Selecionadas";
            tbTaxasSelecionadas.UseVisualStyleBackColor = true;
            // 
            // clbxTaxasSelecionadas
            // 
            clbxTaxasSelecionadas.Dock = DockStyle.Fill;
            clbxTaxasSelecionadas.FormattingEnabled = true;
            clbxTaxasSelecionadas.Location = new Point(3, 3);
            clbxTaxasSelecionadas.Name = "clbxTaxasSelecionadas";
            clbxTaxasSelecionadas.Size = new Size(599, 126);
            clbxTaxasSelecionadas.TabIndex = 0;
            // 
            // tbTaxasAdicionais
            // 
            tbTaxasAdicionais.Controls.Add(clbxTaxasAdicionais);
            tbTaxasAdicionais.Location = new Point(4, 24);
            tbTaxasAdicionais.Name = "tbTaxasAdicionais";
            tbTaxasAdicionais.Padding = new Padding(3);
            tbTaxasAdicionais.Size = new Size(605, 132);
            tbTaxasAdicionais.TabIndex = 1;
            tbTaxasAdicionais.Text = "Taxas Adicionais";
            tbTaxasAdicionais.UseVisualStyleBackColor = true;
            // 
            // clbxTaxasAdicionais
            // 
            clbxTaxasAdicionais.Dock = DockStyle.Fill;
            clbxTaxasAdicionais.FormattingEnabled = true;
            clbxTaxasAdicionais.Location = new Point(3, 3);
            clbxTaxasAdicionais.Name = "clbxTaxasAdicionais";
            clbxTaxasAdicionais.Size = new Size(599, 126);
            clbxTaxasAdicionais.TabIndex = 0;
            // 
            // gbDevolucao
            // 
            gbDevolucao.Controls.Add(label11);
            gbDevolucao.Controls.Add(txtDataDevolucao);
            gbDevolucao.Controls.Add(label13);
            gbDevolucao.Controls.Add(label12);
            gbDevolucao.Controls.Add(txtKMPercorrido);
            gbDevolucao.Controls.Add(cbxNivelTanque);
            gbDevolucao.Enabled = false;
            gbDevolucao.Location = new Point(40, 250);
            gbDevolucao.Name = "gbDevolucao";
            gbDevolucao.Size = new Size(543, 91);
            gbDevolucao.TabIndex = 40;
            gbDevolucao.TabStop = false;
            gbDevolucao.Text = "Devolução";
            // 
            // gbLocacao
            // 
            gbLocacao.Location = new Point(7, 3);
            gbLocacao.Name = "gbLocacao";
            gbLocacao.Size = new Size(669, 241);
            gbLocacao.TabIndex = 41;
            gbLocacao.TabStop = false;
            gbLocacao.Text = "Locação";
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 577);
            Controls.Add(gbDevolucao);
            Controls.Add(tctrlTaxas);
            Controls.Add(btnCupom);
            Controls.Add(label10);
            Controls.Add(txtCupom);
            Controls.Add(txtDevolucaoPrevista);
            Controls.Add(label9);
            Controls.Add(txtDataLocacao);
            Controls.Add(label8);
            Controls.Add(txtQuilometragem);
            Controls.Add(label7);
            Controls.Add(cbxAutomovel);
            Controls.Add(label6);
            Controls.Add(cbxCondutor);
            Controls.Add(label5);
            Controls.Add(cbxPlanoDeCobranca);
            Controls.Add(label4);
            Controls.Add(cbxGrupoAutomovel);
            Controls.Add(label3);
            Controls.Add(cbxCliente);
            Controls.Add(label2);
            Controls.Add(cbxFuncionario);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(gbLocacao);
            Name = "TelaAluguelForm";
            Text = "TelaAluguelForm";
            tctrlTaxas.ResumeLayout(false);
            tbTaxasSelecionadas.ResumeLayout(false);
            tbTaxasAdicionais.ResumeLayout(false);
            gbDevolucao.ResumeLayout(false);
            gbDevolucao.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnSalvar;
        private Label label1;
        private ComboBox cbxFuncionario;
        private ComboBox cbxCliente;
        private Label label2;
        private ComboBox cbxGrupoAutomovel;
        private Label label3;
        private ComboBox cbxPlanoDeCobranca;
        private Label label4;
        private ComboBox cbxCondutor;
        private Label label5;
        private ComboBox cbxAutomovel;
        private Label label6;
        private Label label7;
        private TextBox txtQuilometragem;
        private Label label8;
        private DateTimePicker txtDataLocacao;
        private DateTimePicker txtDevolucaoPrevista;
        private Label label9;
        private TextBox txtCupom;
        private Label label10;
        private Button btnCupom;
        private DateTimePicker txtDataDevolucao;
        private Label label11;
        private ComboBox cbxNivelTanque;
        private Label label12;
        private Label label13;
        private TextBox txtKMPercorrido;
        private TabControl tctrlTaxas;
        private TabPage tbTaxasAdicionais;
        private TabPage tbTaxasSelecionadas;
        private CheckedListBox clbxTaxasSelecionadas;
        private CheckedListBox clbxTaxasAdicionais;
        private GroupBox gbDevolucao;
        private GroupBox gbLocacao;
    }
}