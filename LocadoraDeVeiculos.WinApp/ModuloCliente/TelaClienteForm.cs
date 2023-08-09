using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public partial class TelaClienteForm : Form
    {
        public event GravarRegistroDelegate<Cliente> onGravarRegistro;
        private Cliente cliente;

        public TelaClienteForm()
        {
            InitializeComponent();

            mtxb_cpf.Enabled = false;
            txb_cnpj.Enabled = false;

            this.ConfigurarDialog();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            this.cliente.Nome = txb_nome.Text;
            this.cliente.Email = txb_email.Text;
            this.cliente.Telefone = mtxb_telefone.Text;

            this.cliente.Endereco.Bairro = txb_bairro.Text;
            this.cliente.Endereco.Cep = mtxb_cep.Text;
            this.cliente.Endereco.Cidade = txb_cidade.Text;
            this.cliente.Endereco.Estado = txb_estado.Text;
            this.cliente.Endereco.Logradouro = txb_logradouro.Text;
            this.cliente.Endereco.Numero = Convert.ToInt32(txb_numero.Text);
            this.cliente.Endereco.Complemento = txb_comp.Text;

            if (rdb_cpf.Checked)
            {
                cliente.Documento = mtxb_cpf.Text;
                cliente.TipoCliente = TipoClienteEnum.CPF;
            }
            else if (rdb_cnpj.Checked)
            {
                cliente.Documento = txb_cnpj.Text;
                cliente.TipoCliente = TipoClienteEnum.CNPJ;
            }
            else
            {
                cliente.TipoCliente = TipoClienteEnum.Outro;
            }

            Result resultado = onGravarRegistro(cliente);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            foreach (RadioButton rdb in rdbGroup.Controls)
            {
                rdb.Click += EscolhaRDB;
            }
        }

        private void EscolhaRDB(object? sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            switch (rdb.Name)
            {
                case "rdb_cpf":
                    mtxb_cpf.Enabled = true;
                    txb_cnpj.Enabled = false;
                    break;

                case "rdb_cnpj":
                    mtxb_cpf.Enabled = false;
                    txb_cnpj.Enabled = true;
                    break;
            }
        }

        public void ConfigurarCliente(Cliente cliente)
        {

            txb_nome.Text = cliente.Nome;
            txb_email.Text = cliente.Email;
            mtxb_telefone.Text = cliente.Telefone;

            txb_bairro.Text = cliente.Endereco.Bairro;
            mtxb_cep.Text = cliente.Endereco.Cep;
            txb_cidade.Text = cliente.Endereco.Cidade;
            txb_estado.Text = cliente.Endereco.Estado;
            txb_logradouro.Text = cliente.Endereco.Logradouro;
            txb_numero.Text = cliente.Endereco.Numero.ToString();
            txb_comp.Text = cliente.Endereco.Complemento;

            if (cliente.TipoCliente == TipoClienteEnum.CPF)
            {
                rdb_cpf.Checked = true;
                mtxb_cpf.Text = cliente.Documento;
            }
            else if (cliente.TipoCliente == TipoClienteEnum.CNPJ)
            {
                rdb_cnpj.Checked = true;
                txb_cnpj.Text = cliente.Documento;
            }

            this.cliente = cliente;
        }
    }
}
