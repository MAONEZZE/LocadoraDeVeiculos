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
            comboBox1 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            label3 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            comboBox4 = new ComboBox();
            label5 = new Label();
            comboBox5 = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            txtQuilometragem = new TextBox();
            label8 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label9 = new Label();
            textBox1 = new TextBox();
            label10 = new Label();
            btnCupom = new Button();
            dateTimePicker3 = new DateTimePicker();
            label11 = new Label();
            comboBox6 = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            textBox2 = new TextBox();
            tabControl1 = new TabControl();
            tbTaxasAdicionais = new TabPage();
            tbTaxasSelecionadas = new TabPage();
            clbxTaxasSelecionadas = new CheckedListBox();
            clbxTaxasAdicionais = new CheckedListBox();
            groupBox1 = new GroupBox();
            tabControl1.SuspendLayout();
            tbTaxasAdicionais.SuspendLayout();
            tbTaxasSelecionadas.SuspendLayout();
            groupBox1.SuspendLayout();
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
            cbxFuncionario.TabIndex = 13;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(146, 63);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(196, 23);
            comboBox1.TabIndex = 15;
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
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(146, 101);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(196, 23);
            comboBox2.TabIndex = 17;
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
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(146, 139);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(196, 23);
            comboBox3.TabIndex = 19;
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
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(463, 64);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(196, 23);
            comboBox4.TabIndex = 21;
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
            // comboBox5
            // 
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(463, 101);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(196, 23);
            comboBox5.TabIndex = 23;
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
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(146, 177);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(196, 23);
            dateTimePicker1.TabIndex = 27;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(463, 178);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(196, 23);
            dateTimePicker2.TabIndex = 29;
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
            // textBox1
            // 
            textBox1.Location = new Point(146, 216);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 30;
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
            btnCupom.TabIndex = 32;
            btnCupom.Text = "Aplicar Cupom";
            btnCupom.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Format = DateTimePickerFormat.Short;
            dateTimePicker3.Location = new Point(110, 19);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(196, 23);
            dateTimePicker3.TabIndex = 34;
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
            // comboBox6
            // 
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(110, 57);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(196, 23);
            comboBox6.TabIndex = 36;
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
            // textBox2
            // 
            textBox2.Location = new Point(427, 20);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 37;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbTaxasSelecionadas);
            tabControl1.Controls.Add(tbTaxasAdicionais);
            tabControl1.Location = new Point(46, 347);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(613, 160);
            tabControl1.TabIndex = 39;
            tabControl1.Visible = false;
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
            // clbxTaxasAdicionais
            // 
            clbxTaxasAdicionais.Dock = DockStyle.Fill;
            clbxTaxasAdicionais.FormattingEnabled = true;
            clbxTaxasAdicionais.Location = new Point(3, 3);
            clbxTaxasAdicionais.Name = "clbxTaxasAdicionais";
            clbxTaxasAdicionais.Size = new Size(599, 126);
            clbxTaxasAdicionais.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(dateTimePicker3);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(comboBox6);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(40, 250);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(543, 91);
            groupBox1.TabIndex = 40;
            groupBox1.TabStop = false;
            groupBox1.Text = "Devolução";
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(676, 577);
            Controls.Add(groupBox1);
            Controls.Add(tabControl1);
            Controls.Add(btnCupom);
            Controls.Add(label10);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label9);
            Controls.Add(dateTimePicker1);
            Controls.Add(label8);
            Controls.Add(txtQuilometragem);
            Controls.Add(label7);
            Controls.Add(comboBox5);
            Controls.Add(label6);
            Controls.Add(comboBox4);
            Controls.Add(label5);
            Controls.Add(comboBox3);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(cbxFuncionario);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Name = "TelaAluguelForm";
            Text = "TelaAluguelForm";
            Load += TelaAluguelForm_Load_1;
            tabControl1.ResumeLayout(false);
            tbTaxasAdicionais.ResumeLayout(false);
            tbTaxasSelecionadas.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnSalvar;
        private Label label1;
        private ComboBox cbxFuncionario;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Label label3;
        private ComboBox comboBox3;
        private Label label4;
        private ComboBox comboBox4;
        private Label label5;
        private ComboBox comboBox5;
        private Label label6;
        private Label label7;
        private TextBox txtQuilometragem;
        private Label label8;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label9;
        private TextBox textBox1;
        private Label label10;
        private Button btnCupom;
        private DateTimePicker dateTimePicker3;
        private Label label11;
        private ComboBox comboBox6;
        private Label label12;
        private Label label13;
        private TextBox textBox2;
        private TabControl tabControl1;
        private TabPage tbTaxasAdicionais;
        private TabPage tbTaxasSelecionadas;
        private CheckedListBox clbxTaxasSelecionadas;
        private CheckedListBox clbxTaxasAdicionais;
        private GroupBox groupBox1;
    }
}