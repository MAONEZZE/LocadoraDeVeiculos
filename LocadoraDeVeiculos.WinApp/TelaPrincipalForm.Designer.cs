namespace LocadoraDeVeiculos.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip = new ToolStrip();
            toolStripSplit = new ToolStripSplitButton();
            funcionarioMenuItem = new ToolStripMenuItem();
            automóvelToolStripMenuItem = new ToolStripMenuItem();
            veiculoMenuItem = new ToolStripMenuItem();
            categoriaMenuItem = new ToolStripMenuItem();
            clienteMenuItem = new ToolStripMenuItem();
            planoDeCobrançaMenuItem = new ToolStripMenuItem();
            condutorMenuItem = new ToolStripMenuItem();
            descontoToolStripMenuItem = new ToolStripMenuItem();
            parceiroMenuItem = new ToolStripMenuItem();
            cupomMenuItem = new ToolStripMenuItem();
            aluguelMenuItem = new ToolStripMenuItem();
            TaxaServicoMenuItem = new ToolStripMenuItem();
            BtnMudarCor = new ToolStripButton();
            toolStripLocadora = new ToolStripLabel();
            labelTipoCadastro = new ToolStripLabel();
            txtMenu = new ToolStrip();
            BtnInserir = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            BtnEditar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            BtnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            BtnFiltrar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            BtnDetalhes = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            btnPrecoCombustivel = new ToolStripButton();
            statusStrip = new StatusStrip();
            labelRodape = new ToolStripStatusLabel();
            panelRegistros = new Panel();
            toolStrip.SuspendLayout();
            txtMenu.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.BackColor = Color.SlateBlue;
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripSplit, BtnMudarCor, toolStripLocadora, labelTipoCadastro });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(914, 47);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStripSplit
            // 
            toolStripSplit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplit.DropDownButtonWidth = 50;
            toolStripSplit.DropDownItems.AddRange(new ToolStripItem[] { funcionarioMenuItem, automóvelToolStripMenuItem, clienteMenuItem, planoDeCobrançaMenuItem, condutorMenuItem, descontoToolStripMenuItem, aluguelMenuItem, TaxaServicoMenuItem });
            toolStripSplit.Font = new Font("Lucida Sans Unicode", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripSplit.Image = Properties.Resources.playlist_add_check_FILL0_wght400_GRAD0_opsz40;
            toolStripSplit.ImageAlign = ContentAlignment.MiddleRight;
            toolStripSplit.ImageScaling = ToolStripItemImageScaling.None;
            toolStripSplit.ImageTransparentColor = Color.Magenta;
            toolStripSplit.Name = "toolStripSplit";
            toolStripSplit.Size = new Size(95, 44);
            toolStripSplit.Text = "Menu";
            toolStripSplit.ToolTipText = "Menu";
            // 
            // funcionarioMenuItem
            // 
            funcionarioMenuItem.Image = Properties.Resources.funcionario;
            funcionarioMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            funcionarioMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            funcionarioMenuItem.Name = "funcionarioMenuItem";
            funcionarioMenuItem.Size = new Size(278, 54);
            funcionarioMenuItem.Text = "Funcionário";
            funcionarioMenuItem.Click += FuncionarioMenuItem_Click;
            // 
            // automóvelToolStripMenuItem
            // 
            automóvelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { veiculoMenuItem, categoriaMenuItem });
            automóvelToolStripMenuItem.Image = Properties.Resources.carro;
            automóvelToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            automóvelToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            automóvelToolStripMenuItem.Name = "automóvelToolStripMenuItem";
            automóvelToolStripMenuItem.Size = new Size(278, 54);
            automóvelToolStripMenuItem.Text = "Automóvel";
            // 
            // veiculoMenuItem
            // 
            veiculoMenuItem.Image = Properties.Resources.carro;
            veiculoMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            veiculoMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            veiculoMenuItem.Name = "veiculoMenuItem";
            veiculoMenuItem.Size = new Size(204, 54);
            veiculoMenuItem.Text = "Veículo";
            veiculoMenuItem.Click += VeiculoMenuItem_Click;
            // 
            // categoriaMenuItem
            // 
            categoriaMenuItem.Image = Properties.Resources.categoria;
            categoriaMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            categoriaMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            categoriaMenuItem.Name = "categoriaMenuItem";
            categoriaMenuItem.Size = new Size(204, 54);
            categoriaMenuItem.Text = "Categoria";
            categoriaMenuItem.Click += CategoriaMenuItem_Click;
            // 
            // clienteMenuItem
            // 
            clienteMenuItem.Image = Properties.Resources.cliente;
            clienteMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            clienteMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            clienteMenuItem.Name = "clienteMenuItem";
            clienteMenuItem.Size = new Size(278, 54);
            clienteMenuItem.Text = "Cliente";
            clienteMenuItem.Click += ClienteMenuItem_Click;
            // 
            // planoDeCobrançaMenuItem
            // 
            planoDeCobrançaMenuItem.Image = Properties.Resources.plano_de_cobrança_2;
            planoDeCobrançaMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            planoDeCobrançaMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            planoDeCobrançaMenuItem.Name = "planoDeCobrançaMenuItem";
            planoDeCobrançaMenuItem.Size = new Size(278, 54);
            planoDeCobrançaMenuItem.Text = "Plano de Cobrança";
            // 
            // condutorMenuItem
            // 
            condutorMenuItem.Image = Properties.Resources.condutor;
            condutorMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            condutorMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            condutorMenuItem.Name = "condutorMenuItem";
            condutorMenuItem.Size = new Size(278, 54);
            condutorMenuItem.Text = "Condutor";
            // 
            // descontoToolStripMenuItem
            // 
            descontoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { parceiroMenuItem, cupomMenuItem });
            descontoToolStripMenuItem.Image = Properties.Resources.desconto;
            descontoToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            descontoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            descontoToolStripMenuItem.Name = "descontoToolStripMenuItem";
            descontoToolStripMenuItem.Size = new Size(278, 54);
            descontoToolStripMenuItem.Text = "Desconto";
            // 
            // parceiroMenuItem
            // 
            parceiroMenuItem.Image = Properties.Resources.parceiro;
            parceiroMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            parceiroMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            parceiroMenuItem.Name = "parceiroMenuItem";
            parceiroMenuItem.Size = new Size(190, 54);
            parceiroMenuItem.Text = "Parceiro";
            parceiroMenuItem.Click += ParceiroMenuItem_Click;
            // 
            // cupomMenuItem
            // 
            cupomMenuItem.Image = Properties.Resources.cupom;
            cupomMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            cupomMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            cupomMenuItem.Name = "cupomMenuItem";
            cupomMenuItem.Size = new Size(190, 54);
            cupomMenuItem.Text = "Cupom";
            cupomMenuItem.Click += CupomMenuItem_Click;
            // 
            // aluguelMenuItem
            // 
            aluguelMenuItem.Image = Properties.Resources.aluguel;
            aluguelMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            aluguelMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            aluguelMenuItem.Name = "aluguelMenuItem";
            aluguelMenuItem.Size = new Size(278, 54);
            aluguelMenuItem.Text = "Aluguel";
            aluguelMenuItem.Click += AluguelMenuItem_Click;
            // 
            // TaxaServicoMenuItem
            // 
            TaxaServicoMenuItem.Image = Properties.Resources.taxaeservicos;
            TaxaServicoMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            TaxaServicoMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            TaxaServicoMenuItem.Name = "TaxaServicoMenuItem";
            TaxaServicoMenuItem.Size = new Size(278, 54);
            TaxaServicoMenuItem.Text = "Taxas ou Serviços";
            TaxaServicoMenuItem.Click += TaxaServicoMenuItem_Click;
            // 
            // BtnMudarCor
            // 
            BtnMudarCor.Alignment = ToolStripItemAlignment.Right;
            BtnMudarCor.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnMudarCor.ForeColor = SystemColors.ActiveCaptionText;
            BtnMudarCor.Image = Properties.Resources.palette_FILL0_wght300_GRAD0_opsz40;
            BtnMudarCor.ImageScaling = ToolStripItemImageScaling.None;
            BtnMudarCor.ImageTransparentColor = Color.Magenta;
            BtnMudarCor.Name = "BtnMudarCor";
            BtnMudarCor.Size = new Size(44, 44);
            BtnMudarCor.Text = "Mudar a cor";
            BtnMudarCor.Click += BtnMudarCor_Click;
            // 
            // toolStripLocadora
            // 
            toolStripLocadora.Alignment = ToolStripItemAlignment.Right;
            toolStripLocadora.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            toolStripLocadora.ForeColor = SystemColors.ButtonFace;
            toolStripLocadora.Name = "toolStripLocadora";
            toolStripLocadora.Size = new Size(308, 44);
            toolStripLocadora.Text = "         Locadora de Veículos                  ";
            toolStripLocadora.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTipoCadastro
            // 
            labelTipoCadastro.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelTipoCadastro.ForeColor = SystemColors.ButtonFace;
            labelTipoCadastro.Name = "labelTipoCadastro";
            labelTipoCadastro.Size = new Size(156, 44);
            labelTipoCadastro.Text = "                        ";
            // 
            // txtMenu
            // 
            txtMenu.BackColor = SystemColors.InactiveCaption;
            txtMenu.Enabled = false;
            txtMenu.ImageScalingSize = new Size(20, 20);
            txtMenu.Items.AddRange(new ToolStripItem[] { BtnInserir, toolStripSeparator4, BtnEditar, toolStripSeparator3, BtnExcluir, toolStripSeparator1, BtnFiltrar, toolStripSeparator2, BtnDetalhes, toolStripSeparator5, btnPrecoCombustivel });
            txtMenu.Location = new Point(0, 47);
            txtMenu.Name = "txtMenu";
            txtMenu.Size = new Size(914, 47);
            txtMenu.TabIndex = 1;
            txtMenu.Text = "toolStrip2";
            // 
            // BtnInserir
            // 
            BtnInserir.Font = new Font("Lucida Sans Unicode", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            BtnInserir.Image = Properties.Resources.add_circle_FILL0_wght400_GRAD0_opsz40;
            BtnInserir.ImageAlign = ContentAlignment.MiddleLeft;
            BtnInserir.ImageScaling = ToolStripItemImageScaling.None;
            BtnInserir.ImageTransparentColor = Color.Magenta;
            BtnInserir.Name = "BtnInserir";
            BtnInserir.Size = new Size(112, 44);
            BtnInserir.Text = "Incluir";
            BtnInserir.Click += BtnInserir_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 47);
            // 
            // BtnEditar
            // 
            BtnEditar.Font = new Font("Lucida Sans Unicode", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            BtnEditar.Image = Properties.Resources.edit_FILL0_wght400_GRAD0_opsz40;
            BtnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnEditar.ImageTransparentColor = Color.Magenta;
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(88, 44);
            BtnEditar.Text = "Editar";
            BtnEditar.Click += BtnEditar_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 47);
            // 
            // BtnExcluir
            // 
            BtnExcluir.Font = new Font("Lucida Sans Unicode", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            BtnExcluir.Image = Properties.Resources.close_FILL0_wght400_GRAD0_opsz40;
            BtnExcluir.ImageAlign = ContentAlignment.MiddleLeft;
            BtnExcluir.ImageTransparentColor = Color.Magenta;
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new Size(96, 44);
            BtnExcluir.Text = "Excluír";
            BtnExcluir.Click += BtnExcluir_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 47);
            // 
            // BtnFiltrar
            // 
            BtnFiltrar.Font = new Font("Lucida Sans Unicode", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            BtnFiltrar.Image = Properties.Resources.search_FILL0_wght400_GRAD0_opsz48;
            BtnFiltrar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnFiltrar.ImageTransparentColor = Color.Magenta;
            BtnFiltrar.Name = "BtnFiltrar";
            BtnFiltrar.Size = new Size(90, 44);
            BtnFiltrar.Text = "Filtrar";
            BtnFiltrar.Click += BtnFiltrar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 47);
            // 
            // BtnDetalhes
            // 
            BtnDetalhes.Font = new Font("Lucida Sans Unicode", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDetalhes.Image = Properties.Resources.pdf;
            BtnDetalhes.ImageAlign = ContentAlignment.MiddleLeft;
            BtnDetalhes.ImageTransparentColor = Color.Magenta;
            BtnDetalhes.Name = "BtnDetalhes";
            BtnDetalhes.Size = new Size(114, 44);
            BtnDetalhes.Text = "Detalhes";
            BtnDetalhes.ToolTipText = " ";
            BtnDetalhes.Click += BtnDetalhes_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 47);
            // 
            // btnPrecoCombustivel
            // 
            btnPrecoCombustivel.Font = new Font("Lucida Sans Unicode", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrecoCombustivel.ForeColor = Color.Black;
            btnPrecoCombustivel.Image = Properties.Resources.combustivel;
            btnPrecoCombustivel.ImageTransparentColor = Color.Magenta;
            btnPrecoCombustivel.Name = "btnPrecoCombustivel";
            btnPrecoCombustivel.Size = new Size(205, 44);
            btnPrecoCombustivel.Text = "Preço Combustível";
            btnPrecoCombustivel.Click += BtnPrecoCombustivel_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { labelRodape });
            statusStrip.Location = new Point(0, 574);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(914, 26);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new Size(88, 20);
            labelRodape.Text = "Bem-Vindo!";
            // 
            // panelRegistros
            // 
            panelRegistros.BackColor = SystemColors.AppWorkspace;
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 94);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(914, 480);
            panelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panelRegistros);
            Controls.Add(statusStrip);
            Controls.Add(txtMenu);
            Controls.Add(toolStrip);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Locação de Veículo";
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            txtMenu.ResumeLayout(false);
            txtMenu.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem automóvelToolStripMenuItem;
        private ToolStripMenuItem veiculoMenuItem;
        private ToolStripMenuItem categoriaMenuItem;
        private ToolStripMenuItem clienteMenuItem;
        private ToolStripMenuItem planoDeCobrançaMenuItem;
        private ToolStripMenuItem condutorMenuItem;
        private ToolStripMenuItem descontoToolStripMenuItem;
        private ToolStripMenuItem parceiroMenuItem;
        private ToolStripMenuItem cupomMenuItem;
        private ToolStripMenuItem aluguelMenuItem;
        private ToolStrip txtMenu;
        private ToolStripButton BtnInserir;
        private ToolStripButton BtnEditar;
        private ToolStripButton BtnExcluir;
        private ToolStripSeparator toolStripSeparator1;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel labelRodape;
        private ToolStripButton BtnFiltrar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton BtnDetalhes;
        private ToolStripLabel toolStripLocadora;
        private ToolStripLabel labelTipoCadastro;
        private Panel panelRegistros;
        private ToolStripSplitButton toolStripSplit;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem funcionarioMenuItem;
        private ToolStripMenuItem TaxaServicoMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnPrecoCombustivel;
        private ToolStripButton BtnMudarCor;
    }
}