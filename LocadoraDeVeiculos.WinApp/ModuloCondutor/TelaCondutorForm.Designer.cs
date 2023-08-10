namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    partial class TelaCondutorForm
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
            cbox_cliente = new ComboBox();
            mtxb_cpf = new MaskedTextBox();
            mtxb_telefone = new MaskedTextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txb_email = new TextBox();
            txb_nome = new TextBox();
            txb_cnh = new TextBox();
            label5 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            txb_data = new DateTimePicker();
            label7 = new Label();
            chk_clienteCondut = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(302, 457);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 43);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvar.DialogResult = DialogResult.OK;
            btnSalvar.Location = new Point(188, 457);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 43);
            btnSalvar.TabIndex = 10;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // cbox_cliente
            // 
            cbox_cliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_cliente.FormattingEnabled = true;
            cbox_cliente.Location = new Point(81, 33);
            cbox_cliente.Margin = new Padding(3, 4, 3, 4);
            cbox_cliente.Name = "cbox_cliente";
            cbox_cliente.Size = new Size(315, 28);
            cbox_cliente.TabIndex = 13;
            cbox_cliente.SelectedValueChanged += cbox_cliente_SelectedValueChanged;
            // 
            // mtxb_cpf
            // 
            mtxb_cpf.Location = new Point(258, 220);
            mtxb_cpf.Margin = new Padding(3, 4, 3, 4);
            mtxb_cpf.Mask = "###.###.###-##";
            mtxb_cpf.Name = "mtxb_cpf";
            mtxb_cpf.Size = new Size(138, 27);
            mtxb_cpf.TabIndex = 34;
            // 
            // mtxb_telefone
            // 
            mtxb_telefone.Location = new Point(81, 220);
            mtxb_telefone.Margin = new Padding(3, 4, 3, 4);
            mtxb_telefone.Mask = "(##) #####-####";
            mtxb_telefone.Name = "mtxb_telefone";
            mtxb_telefone.Size = new Size(101, 27);
            mtxb_telefone.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(216, 224);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 32;
            label4.Text = "CPF:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 159);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 31;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 221);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 30;
            label2.Text = "Telefone:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 114);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 29;
            label1.Text = "Nome:";
            // 
            // txb_email
            // 
            txb_email.Location = new Point(81, 153);
            txb_email.Margin = new Padding(3, 4, 3, 4);
            txb_email.Name = "txb_email";
            txb_email.Size = new Size(315, 27);
            txb_email.TabIndex = 28;
            // 
            // txb_nome
            // 
            txb_nome.Location = new Point(82, 110);
            txb_nome.Margin = new Padding(3, 4, 3, 4);
            txb_nome.Name = "txb_nome";
            txb_nome.Size = new Size(315, 27);
            txb_nome.TabIndex = 27;
            // 
            // txb_cnh
            // 
            txb_cnh.Location = new Point(130, 85);
            txb_cnh.Margin = new Padding(3, 4, 3, 4);
            txb_cnh.Name = "txb_cnh";
            txb_cnh.Size = new Size(99, 27);
            txb_cnh.TabIndex = 35;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 89);
            label5.Name = "label5";
            label5.Size = new Size(43, 20);
            label5.TabIndex = 36;
            label5.Text = "CNH:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(47, 39);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 37;
            label6.Text = "Validade:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txb_data);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txb_cnh);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(31, 280);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(365, 133);
            groupBox1.TabIndex = 39;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados da CNH";
            // 
            // txb_data
            // 
            txb_data.Format = DateTimePickerFormat.Short;
            txb_data.Location = new Point(130, 31);
            txb_data.Margin = new Padding(3, 4, 3, 4);
            txb_data.Name = "txb_data";
            txb_data.Size = new Size(99, 27);
            txb_data.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 37);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 40;
            label7.Text = "Cliente:";
            // 
            // chk_clienteCondut
            // 
            chk_clienteCondut.AutoSize = true;
            chk_clienteCondut.Location = new Point(82, 69);
            chk_clienteCondut.Margin = new Padding(3, 4, 3, 4);
            chk_clienteCondut.Name = "chk_clienteCondut";
            chk_clienteCondut.Size = new Size(207, 24);
            chk_clienteCondut.TabIndex = 41;
            chk_clienteCondut.Text = "O cliente será o Condutor?";
            chk_clienteCondut.UseVisualStyleBackColor = true;
            chk_clienteCondut.CheckedChanged += chk_clienteCondut_CheckedChanged;
            // 
            // TelaCondutorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 532);
            Controls.Add(chk_clienteCondut);
            Controls.Add(label7);
            Controls.Add(groupBox1);
            Controls.Add(mtxb_cpf);
            Controls.Add(mtxb_telefone);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txb_email);
            Controls.Add(txb_nome);
            Controls.Add(cbox_cliente);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaCondutorForm";
            Text = "TelaCondutorForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnSalvar;
        private ComboBox cbox_cliente;
        private MaskedTextBox mtxb_cpf;
        private MaskedTextBox mtxb_telefone;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txb_email;
        private TextBox txb_nome;
        private TextBox txb_cnh;
        private Label label5;
        private Label label6;
        private GroupBox groupBox1;
        private Label label7;
        private DateTimePicker txb_data;
        private CheckBox chk_clienteCondut;
    }
}