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
            toolStrip_Entidades = new ToolStripSplitButton();
            funcionarioMenuItem = new ToolStripMenuItem();
            automóvelToolStripMenuItem = new ToolStripMenuItem();
            veiculoMenuItem = new ToolStripMenuItem();
            categoriaMenuItem = new ToolStripMenuItem();
            tipoDeCombustívelMenuItem = new ToolStripMenuItem();
            clienteMenuItem = new ToolStripMenuItem();
            planoDeCobrançaMenuItem = new ToolStripMenuItem();
            condutorMenuItem = new ToolStripMenuItem();
            descontoToolStripMenuItem = new ToolStripMenuItem();
            parceiroMenuItem = new ToolStripMenuItem();
            cupomMenuItem = new ToolStripMenuItem();
            aluguelMenuItem = new ToolStripMenuItem();
            toolStripLocadora = new ToolStripLabel();
            labelTipoCadastro = new ToolStripLabel();
            txtMenu = new ToolStrip();
            BtnInserir = new ToolStripButton();
            BtnEditar = new ToolStripButton();
            BtnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            BtnFiltrar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            BtnGerarPdf = new ToolStripButton();
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
            toolStrip.BackColor = SystemColors.InactiveCaption;
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStrip_Entidades, toolStripLocadora, labelTipoCadastro });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 47);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStrip_Entidades
            // 
            toolStrip_Entidades.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStrip_Entidades.DropDownButtonWidth = 50;
            toolStrip_Entidades.DropDownItems.AddRange(new ToolStripItem[] { funcionarioMenuItem, automóvelToolStripMenuItem, clienteMenuItem, planoDeCobrançaMenuItem, condutorMenuItem, descontoToolStripMenuItem, aluguelMenuItem });
            toolStrip_Entidades.Image = Properties.Resources.playlist_add_check_FILL0_wght400_GRAD0_opsz40;
            toolStrip_Entidades.ImageAlign = ContentAlignment.MiddleRight;
            toolStrip_Entidades.ImageScaling = ToolStripItemImageScaling.None;
            toolStrip_Entidades.ImageTransparentColor = Color.Magenta;
            toolStrip_Entidades.Name = "toolStrip_Entidades";
            toolStrip_Entidades.Size = new Size(95, 44);
            toolStrip_Entidades.Text = "Menu";
            toolStrip_Entidades.ToolTipText = "Menu";
            // 
            // funcionarioMenuItem
            // 
            funcionarioMenuItem.Image = Properties.Resources.funcionario;
            funcionarioMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            funcionarioMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            funcionarioMenuItem.Name = "funcionarioMenuItem";
            funcionarioMenuItem.Size = new Size(212, 54);
            funcionarioMenuItem.Text = "Funcionário";
            // 
            // automóvelToolStripMenuItem
            // 
            automóvelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { veiculoMenuItem, categoriaMenuItem, tipoDeCombustívelMenuItem });
            automóvelToolStripMenuItem.Image = Properties.Resources.carro;
            automóvelToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            automóvelToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            automóvelToolStripMenuItem.Name = "automóvelToolStripMenuItem";
            automóvelToolStripMenuItem.Size = new Size(212, 54);
            automóvelToolStripMenuItem.Text = "Automóvel";
            // 
            // veiculoMenuItem
            // 
            veiculoMenuItem.Image = Properties.Resources.carro;
            veiculoMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            veiculoMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            veiculoMenuItem.Name = "veiculoMenuItem";
            veiculoMenuItem.Size = new Size(215, 54);
            veiculoMenuItem.Text = "Veículo";
            // 
            // categoriaMenuItem
            // 
            categoriaMenuItem.Image = Properties.Resources.categoria;
            categoriaMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            categoriaMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            categoriaMenuItem.Name = "categoriaMenuItem";
            categoriaMenuItem.Size = new Size(215, 54);
            categoriaMenuItem.Text = "Categoria";
            // 
            // tipoDeCombustívelMenuItem
            // 
            tipoDeCombustívelMenuItem.Image = Properties.Resources.combustivel;
            tipoDeCombustívelMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            tipoDeCombustívelMenuItem.Name = "tipoDeCombustívelMenuItem";
            tipoDeCombustívelMenuItem.Size = new Size(215, 54);
            tipoDeCombustívelMenuItem.Text = "Tipo de Combustível";
            // 
            // clienteMenuItem
            // 
            clienteMenuItem.Image = Properties.Resources.cliente;
            clienteMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            clienteMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            clienteMenuItem.Name = "clienteMenuItem";
            clienteMenuItem.Size = new Size(212, 54);
            clienteMenuItem.Text = "Cliente";
            clienteMenuItem.Click += clienteMenuItem_Click;
            // 
            // planoDeCobrançaMenuItem
            // 
            planoDeCobrançaMenuItem.Image = Properties.Resources.plano_de_cobrança_2;
            planoDeCobrançaMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            planoDeCobrançaMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            planoDeCobrançaMenuItem.Name = "planoDeCobrançaMenuItem";
            planoDeCobrançaMenuItem.Size = new Size(212, 54);
            planoDeCobrançaMenuItem.Text = "Plano de Cobrança";
            // 
            // condutorMenuItem
            // 
            condutorMenuItem.Image = Properties.Resources.condutor;
            condutorMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            condutorMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            condutorMenuItem.Name = "condutorMenuItem";
            condutorMenuItem.Size = new Size(212, 54);
            condutorMenuItem.Text = "Condutor";
            // 
            // descontoToolStripMenuItem
            // 
            descontoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { parceiroMenuItem, cupomMenuItem });
            descontoToolStripMenuItem.Image = Properties.Resources.desconto;
            descontoToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            descontoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            descontoToolStripMenuItem.Name = "descontoToolStripMenuItem";
            descontoToolStripMenuItem.Size = new Size(212, 54);
            descontoToolStripMenuItem.Text = "Desconto";
            // 
            // parceiroMenuItem
            // 
            parceiroMenuItem.Image = Properties.Resources.parceiro;
            parceiroMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            parceiroMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            parceiroMenuItem.Name = "parceiroMenuItem";
            parceiroMenuItem.Size = new Size(149, 54);
            parceiroMenuItem.Text = "Parceiro";
            parceiroMenuItem.Click += ParceiroMenuItem_Click;
            // 
            // cupomMenuItem
            // 
            cupomMenuItem.Image = Properties.Resources.cupom;
            cupomMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            cupomMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            cupomMenuItem.Name = "cupomMenuItem";
            cupomMenuItem.Size = new Size(149, 54);
            cupomMenuItem.Text = "Cupom";
            cupomMenuItem.Click += CupomMenuItem_Click;
            // 
            // aluguelMenuItem
            // 
            aluguelMenuItem.Image = Properties.Resources.aluguel;
            aluguelMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            aluguelMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            aluguelMenuItem.Name = "aluguelMenuItem";
            aluguelMenuItem.Size = new Size(212, 54);
            aluguelMenuItem.Text = "Aluguel";
            // 
            // toolStripLocadora
            // 
            toolStripLocadora.Alignment = ToolStripItemAlignment.Right;
            toolStripLocadora.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            toolStripLocadora.ForeColor = SystemColors.GrayText;
            toolStripLocadora.Name = "toolStripLocadora";
            toolStripLocadora.Size = new Size(250, 44);
            toolStripLocadora.Text = "         Locadora de Veículos                  ";
            toolStripLocadora.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTipoCadastro
            // 
            labelTipoCadastro.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            labelTipoCadastro.ForeColor = SystemColors.ActiveCaptionText;
            labelTipoCadastro.Name = "labelTipoCadastro";
            labelTipoCadastro.Size = new Size(0, 44);
            // 
            // txtMenu
            // 
            txtMenu.BackColor = SystemColors.MenuBar;
            txtMenu.Enabled = false;
            txtMenu.ImageScalingSize = new Size(20, 20);
            txtMenu.Items.AddRange(new ToolStripItem[] { BtnInserir, BtnEditar, BtnExcluir, toolStripSeparator1, BtnFiltrar, toolStripSeparator2, BtnGerarPdf });
            txtMenu.Location = new Point(0, 47);
            txtMenu.Name = "txtMenu";
            txtMenu.Size = new Size(800, 55);
            txtMenu.TabIndex = 1;
            txtMenu.Text = "toolStrip2";
            // 
            // BtnInserir
            // 
            BtnInserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnInserir.Image = Properties.Resources.add_circle_FILL0_wght400_GRAD0_opsz40;
            BtnInserir.ImageAlign = ContentAlignment.MiddleLeft;
            BtnInserir.ImageScaling = ToolStripItemImageScaling.None;
            BtnInserir.ImageTransparentColor = Color.Magenta;
            BtnInserir.Name = "BtnInserir";
            BtnInserir.Size = new Size(44, 52);
            BtnInserir.Text = "toolStripButton1";
            BtnInserir.Click += BtnInserir_Click;
            // 
            // BtnEditar
            // 
            BtnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnEditar.Image = Properties.Resources.edit_FILL0_wght400_GRAD0_opsz40;
            BtnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnEditar.ImageScaling = ToolStripItemImageScaling.None;
            BtnEditar.ImageTransparentColor = Color.Magenta;
            BtnEditar.Name = "BtnEditar";
            BtnEditar.Size = new Size(44, 52);
            BtnEditar.Text = "toolStripButton2";
            BtnEditar.Click += BtnEditar_Click;
            // 
            // BtnExcluir
            // 
            BtnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnExcluir.Image = Properties.Resources.close_FILL0_wght400_GRAD0_opsz40;
            BtnExcluir.ImageAlign = ContentAlignment.MiddleLeft;
            BtnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            BtnExcluir.ImageTransparentColor = Color.Magenta;
            BtnExcluir.Name = "BtnExcluir";
            BtnExcluir.Size = new Size(44, 52);
            BtnExcluir.Text = "toolStripButton3";
            BtnExcluir.Click += BtnExcluir_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 55);
            // 
            // BtnFiltrar
            // 
            BtnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnFiltrar.Image = Properties.Resources.search_FILL0_wght400_GRAD0_opsz48;
            BtnFiltrar.ImageAlign = ContentAlignment.MiddleLeft;
            BtnFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            BtnFiltrar.ImageTransparentColor = Color.Magenta;
            BtnFiltrar.Name = "BtnFiltrar";
            BtnFiltrar.Size = new Size(52, 52);
            BtnFiltrar.Text = "toolStripButton1";
            BtnFiltrar.Click += BtnFiltrar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 55);
            // 
            // BtnGerarPdf
            // 
            BtnGerarPdf.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnGerarPdf.Image = Properties.Resources.pdf;
            BtnGerarPdf.ImageAlign = ContentAlignment.MiddleLeft;
            BtnGerarPdf.ImageScaling = ToolStripItemImageScaling.None;
            BtnGerarPdf.ImageTransparentColor = Color.Magenta;
            BtnGerarPdf.Name = "BtnGerarPdf";
            BtnGerarPdf.Size = new Size(52, 52);
            BtnGerarPdf.Click += BtnGerarPdf_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { labelRodape });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // labelRodape
            // 
            labelRodape.Name = "labelRodape";
            labelRodape.Size = new Size(70, 17);
            labelRodape.Text = "Bem-Vindo!";
            // 
            // panelRegistros
            // 
            panelRegistros.BackColor = SystemColors.AppWorkspace;
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.Location = new Point(0, 102);
            panelRegistros.Margin = new Padding(3, 2, 3, 2);
            panelRegistros.Name = "panelRegistros";
            panelRegistros.Size = new Size(800, 326);
            panelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelRegistros);
            Controls.Add(statusStrip);
            Controls.Add(txtMenu);
            Controls.Add(toolStrip);
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
        private ToolStripMenuItem funcionarioMenuItem;
        private ToolStripMenuItem automóvelToolStripMenuItem;
        private ToolStripMenuItem veiculoMenuItem;
        private ToolStripMenuItem categoriaMenuItem;
        private ToolStripMenuItem tipoDeCombustívelMenuItem;
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
        private ToolStripButton BtnGerarPdf;
        private ToolStripLabel toolStripLocadora;
        private ToolStripLabel labelTipoCadastro;
        private Panel panelRegistros;
        private ToolStripSplitButton toolStrip_Entidades;
    }
}