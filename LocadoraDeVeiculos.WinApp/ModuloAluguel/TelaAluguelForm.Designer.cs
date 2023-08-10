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
            tctrlTaxas = new TabControl();
            tbTaxasSelecionadas = new TabPage();
            clbxTaxasSelecionadas = new CheckedListBox();
            tbTaxasAdicionais = new TabPage();
            clbxTaxasAdicionais = new CheckedListBox();
            gbDevolucao = new GroupBox();
            txtKMPercorrido = new NumericUpDown();
            gbLocacao = new GroupBox();
            label14 = new Label();
            txtValorTotal = new Label();
            tctrlTaxas.SuspendLayout();
            tbTaxasSelecionadas.SuspendLayout();
            tbTaxasAdicionais.SuspendLayout();
            gbDevolucao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKMPercorrido).BeginInit();
            gbLocacao.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(584, 533);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 32);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.DialogResult = DialogResult.OK;
            btnSalvar.Location = new Point(484, 533);
            btnSalvar.Margin = new Padding(3, 2, 3, 2);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(82, 32);
            btnSalvar.TabIndex = 16;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // label1
            // 
            label1.Location = new Point(35, 19);
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
            cbxFuncionario.Location = new Point(141, 20);
            cbxFuncionario.Name = "cbxFuncionario";
            cbxFuncionario.Size = new Size(196, 23);
            cbxFuncionario.TabIndex = 1;
            // 
            // cbxCliente
            // 
            cbxCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCliente.FormattingEnabled = true;
            cbxCliente.Location = new Point(141, 58);
            cbxCliente.Name = "cbxCliente";
            cbxCliente.Size = new Size(196, 23);
            cbxCliente.TabIndex = 2;
            cbxCliente.SelectedValueChanged += cbxCliente_SelectedValueChanged;
            // 
            // label2
            // 
            label2.Location = new Point(35, 57);
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
            cbxGrupoAutomovel.Location = new Point(141, 96);
            cbxGrupoAutomovel.Name = "cbxGrupoAutomovel";
            cbxGrupoAutomovel.Size = new Size(196, 23);
            cbxGrupoAutomovel.TabIndex = 4;
            cbxGrupoAutomovel.SelectedValueChanged += cbxGrupoAutomovel_SelectedValueChanged;
            // 
            // label3
            // 
            label3.Location = new Point(2, 95);
            label3.Name = "label3";
            label3.Size = new Size(133, 23);
            label3.TabIndex = 16;
            label3.Text = "Grupo de Automóveis:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxPlanoDeCobranca
            // 
            cbxPlanoDeCobranca.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPlanoDeCobranca.Enabled = false;
            cbxPlanoDeCobranca.FormattingEnabled = true;
            cbxPlanoDeCobranca.Location = new Point(141, 134);
            cbxPlanoDeCobranca.Name = "cbxPlanoDeCobranca";
            cbxPlanoDeCobranca.Size = new Size(196, 23);
            cbxPlanoDeCobranca.TabIndex = 6;
            cbxPlanoDeCobranca.SelectedValueChanged += AtualizarValorTotal_event;
            // 
            // label4
            // 
            label4.Location = new Point(17, 133);
            label4.Name = "label4";
            label4.Size = new Size(118, 23);
            label4.TabIndex = 18;
            label4.Text = "Plano de Cobrança:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxCondutor
            // 
            cbxCondutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCondutor.Enabled = false;
            cbxCondutor.FormattingEnabled = true;
            cbxCondutor.Location = new Point(458, 59);
            cbxCondutor.Name = "cbxCondutor";
            cbxCondutor.Size = new Size(196, 23);
            cbxCondutor.TabIndex = 3;
            // 
            // label5
            // 
            label5.Location = new Point(387, 58);
            label5.Name = "label5";
            label5.Size = new Size(65, 23);
            label5.TabIndex = 20;
            label5.Text = "Condutor:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cbxAutomovel
            // 
            cbxAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxAutomovel.Enabled = false;
            cbxAutomovel.FormattingEnabled = true;
            cbxAutomovel.Location = new Point(458, 96);
            cbxAutomovel.Name = "cbxAutomovel";
            cbxAutomovel.Size = new Size(196, 23);
            cbxAutomovel.TabIndex = 5;
            cbxAutomovel.SelectedValueChanged += cbxAutomovel_SelectedValueChanged;
            // 
            // label6
            // 
            label6.Location = new Point(380, 95);
            label6.Name = "label6";
            label6.Size = new Size(72, 23);
            label6.TabIndex = 22;
            label6.Text = "Automóvel:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Location = new Point(354, 135);
            label7.Name = "label7";
            label7.Size = new Size(98, 23);
            label7.TabIndex = 24;
            label7.Text = "KM Automóvel:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtQuilometragem
            // 
            txtQuilometragem.Enabled = false;
            txtQuilometragem.Location = new Point(458, 134);
            txtQuilometragem.Name = "txtQuilometragem";
            txtQuilometragem.Size = new Size(100, 23);
            txtQuilometragem.TabIndex = 25;
            txtQuilometragem.TabStop = false;
            // 
            // label8
            // 
            label8.Location = new Point(49, 172);
            label8.Name = "label8";
            label8.Size = new Size(86, 23);
            label8.TabIndex = 26;
            label8.Text = "Data Locação:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDataLocacao
            // 
            txtDataLocacao.Format = DateTimePickerFormat.Short;
            txtDataLocacao.Location = new Point(141, 172);
            txtDataLocacao.MinDate = new DateTime(2023, 8, 9, 0, 0, 0, 0);
            txtDataLocacao.Name = "txtDataLocacao";
            txtDataLocacao.Size = new Size(196, 23);
            txtDataLocacao.TabIndex = 7;
            txtDataLocacao.ValueChanged += txtDataLocacao_ValueChanged;
            // 
            // txtDevolucaoPrevista
            // 
            txtDevolucaoPrevista.Enabled = false;
            txtDevolucaoPrevista.Format = DateTimePickerFormat.Short;
            txtDevolucaoPrevista.Location = new Point(458, 173);
            txtDevolucaoPrevista.Name = "txtDevolucaoPrevista";
            txtDevolucaoPrevista.Size = new Size(196, 23);
            txtDevolucaoPrevista.TabIndex = 8;
            txtDevolucaoPrevista.ValueChanged += AtualizarValorTotal_event;
            // 
            // label9
            // 
            label9.Location = new Point(339, 173);
            label9.Name = "label9";
            label9.Size = new Size(113, 23);
            label9.TabIndex = 28;
            label9.Text = "Devolução Prevista:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCupom
            // 
            txtCupom.Location = new Point(141, 211);
            txtCupom.Name = "txtCupom";
            txtCupom.Size = new Size(100, 23);
            txtCupom.TabIndex = 9;
            // 
            // label10
            // 
            label10.Location = new Point(49, 210);
            label10.Name = "label10";
            label10.Size = new Size(86, 23);
            label10.TabIndex = 31;
            label10.Text = "Cupom:";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnCupom
            // 
            btnCupom.Location = new Point(255, 205);
            btnCupom.Name = "btnCupom";
            btnCupom.Size = new Size(107, 32);
            btnCupom.TabIndex = 10;
            btnCupom.Text = "Aplicar Cupom";
            btnCupom.UseVisualStyleBackColor = true;
            btnCupom.Click += btnCupom_Click;
            // 
            // txtDataDevolucao
            // 
            txtDataDevolucao.Checked = false;
            txtDataDevolucao.Format = DateTimePickerFormat.Short;
            txtDataDevolucao.Location = new Point(141, 19);
            txtDataDevolucao.Name = "txtDataDevolucao";
            txtDataDevolucao.Size = new Size(196, 23);
            txtDataDevolucao.TabIndex = 11;
            txtDataDevolucao.ValueChanged += AtualizarValorTotal_event;
            // 
            // label11
            // 
            label11.Location = new Point(37, 19);
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
            cbxNivelTanque.Location = new Point(141, 57);
            cbxNivelTanque.Name = "cbxNivelTanque";
            cbxNivelTanque.Size = new Size(196, 23);
            cbxNivelTanque.TabIndex = 13;
            cbxNivelTanque.SelectedValueChanged += AtualizarValorTotal_event;
            // 
            // label12
            // 
            label12.Location = new Point(6, 56);
            label12.Name = "label12";
            label12.Size = new Size(129, 23);
            label12.TabIndex = 35;
            label12.Text = "Nível Atual do Tanque:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Location = new Point(366, 19);
            label13.Name = "label13";
            label13.Size = new Size(86, 23);
            label13.TabIndex = 38;
            label13.Text = "KM Percorrido:";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tctrlTaxas
            // 
            tctrlTaxas.Controls.Add(tbTaxasSelecionadas);
            tctrlTaxas.Controls.Add(tbTaxasAdicionais);
            tctrlTaxas.Location = new Point(53, 357);
            tctrlTaxas.Name = "tctrlTaxas";
            tctrlTaxas.SelectedIndex = 0;
            tctrlTaxas.Size = new Size(613, 160);
            tctrlTaxas.TabIndex = 15;
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
            clbxTaxasSelecionadas.TabIndex = 14;
            clbxTaxasSelecionadas.ItemCheck += clbxTaxasSelecionadas_ItemCheck;
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
            clbxTaxasAdicionais.ItemCheck += clbxTaxasAdicionais_ItemCheck;
            // 
            // gbDevolucao
            // 
            gbDevolucao.Controls.Add(txtKMPercorrido);
            gbDevolucao.Controls.Add(label11);
            gbDevolucao.Controls.Add(txtDataDevolucao);
            gbDevolucao.Controls.Add(label13);
            gbDevolucao.Controls.Add(label12);
            gbDevolucao.Controls.Add(cbxNivelTanque);
            gbDevolucao.Enabled = false;
            gbDevolucao.Location = new Point(12, 259);
            gbDevolucao.Name = "gbDevolucao";
            gbDevolucao.Size = new Size(570, 91);
            gbDevolucao.TabIndex = 40;
            gbDevolucao.TabStop = false;
            gbDevolucao.Text = "Devolução";
            // 
            // txtKMPercorrido
            // 
            txtKMPercorrido.Location = new Point(458, 19);
            txtKMPercorrido.Name = "txtKMPercorrido";
            txtKMPercorrido.Size = new Size(100, 23);
            txtKMPercorrido.TabIndex = 12;
            // 
            // gbLocacao
            // 
            gbLocacao.Controls.Add(label1);
            gbLocacao.Controls.Add(cbxFuncionario);
            gbLocacao.Controls.Add(label2);
            gbLocacao.Controls.Add(cbxCliente);
            gbLocacao.Controls.Add(btnCupom);
            gbLocacao.Controls.Add(label3);
            gbLocacao.Controls.Add(label10);
            gbLocacao.Controls.Add(cbxGrupoAutomovel);
            gbLocacao.Controls.Add(txtCupom);
            gbLocacao.Controls.Add(label4);
            gbLocacao.Controls.Add(txtDevolucaoPrevista);
            gbLocacao.Controls.Add(cbxPlanoDeCobranca);
            gbLocacao.Controls.Add(label9);
            gbLocacao.Controls.Add(label5);
            gbLocacao.Controls.Add(txtDataLocacao);
            gbLocacao.Controls.Add(cbxCondutor);
            gbLocacao.Controls.Add(label8);
            gbLocacao.Controls.Add(label6);
            gbLocacao.Controls.Add(txtQuilometragem);
            gbLocacao.Controls.Add(cbxAutomovel);
            gbLocacao.Controls.Add(label7);
            gbLocacao.Location = new Point(12, 12);
            gbLocacao.Name = "gbLocacao";
            gbLocacao.Size = new Size(669, 241);
            gbLocacao.TabIndex = 41;
            gbLocacao.TabStop = false;
            gbLocacao.Text = "Locação";
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(47, 530);
            label14.Name = "label14";
            label14.Size = new Size(149, 35);
            label14.TabIndex = 42;
            label14.Text = "Valor Total Previsto:";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtValorTotal
            // 
            txtValorTotal.Font = new Font("Segoe UI Black", 13F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            txtValorTotal.ForeColor = Color.Chartreuse;
            txtValorTotal.Location = new Point(211, 536);
            txtValorTotal.Name = "txtValorTotal";
            txtValorTotal.Size = new Size(114, 23);
            txtValorTotal.TabIndex = 43;
            txtValorTotal.Text = "R$ 0";
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 586);
            Controls.Add(txtValorTotal);
            Controls.Add(label14);
            Controls.Add(gbDevolucao);
            Controls.Add(tctrlTaxas);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(gbLocacao);
            Name = "TelaAluguelForm";
            Text = "TelaAluguelForm";
            tctrlTaxas.ResumeLayout(false);
            tbTaxasSelecionadas.ResumeLayout(false);
            tbTaxasAdicionais.ResumeLayout(false);
            gbDevolucao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtKMPercorrido).EndInit();
            gbLocacao.ResumeLayout(false);
            gbLocacao.PerformLayout();
            ResumeLayout(false);
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
        private TabControl tctrlTaxas;
        private TabPage tbTaxasAdicionais;
        private TabPage tbTaxasSelecionadas;
        private CheckedListBox clbxTaxasSelecionadas;
        private CheckedListBox clbxTaxasAdicionais;
        private GroupBox gbDevolucao;
        private GroupBox gbLocacao;
        private Label label14;
        private Label txtValorTotal;
        private NumericUpDown numericUpDown1;
        private NumericUpDown txtKMPercorrido;
    }
}