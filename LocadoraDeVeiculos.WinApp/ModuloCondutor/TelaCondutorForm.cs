using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCondutorForm : Form
    {
        public event GravarRegistroDelegate<Condutor> onGravarRegistro;
        private Condutor condutor;

        public TelaCondutorForm(IRepositorioCliente repCliente)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            AlimentarCBOXCliente(repCliente);
        }

        private void AlimentarCBOXCliente(IRepositorioCliente repCliente)
        {
            foreach (Cliente c in repCliente.SelecionarTodos())
            {
                cbox_cliente.Items.Add(c);
            }
        }

        private void VerificadorClienteCpf(Cliente cliente)
        {
            if (cliente.TipoCliente == TipoClienteEnum.CPF)
            {
                txb_email.Text = cliente.Email;
                txb_nome.Text = cliente.Nome;
                mtxb_cpf.Text = cliente.Documento;
                mtxb_telefone.Text = cliente.Telefone;

                DesabilitarCampos();
            }
        }

        private void DesabilitarCampos()
        {
            txb_email.Enabled = false;
            txb_nome.Enabled = false;
            mtxb_cpf.Enabled = false;
            mtxb_telefone.Enabled = false;
        }

        private void cbox_cliente_SelectedValueChanged(object sender, EventArgs e)
        {
            Cliente clienteSelec = (Cliente)cbox_cliente.SelectedItem;

            VerificadorClienteCpf(clienteSelec);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            condutor.Nome = txb_nome.Text;
            condutor.Email = txb_email.Text;
            condutor.Telefone = mtxb_telefone.Text;
            condutor.Documento = mtxb_cpf.Text;
            condutor.Cnh = txb_cnh.Text;
            condutor.Validade = txb_data.Value;

            Result resultado = onGravarRegistro(condutor);

            if(resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        public void ConfigurarCondutor(Condutor condutor)
        {
            txb_nome.Text = condutor.Nome;
            txb_email.Text = condutor.Email;
            mtxb_telefone.Text = condutor.Telefone;
            mtxb_cpf.Text = condutor.Documento;
            txb_cnh.Text = condutor.Cnh;

            if(condutor.Validade == DateTime.MinValue)
            {
                txb_data.Value = DateTime.Now;
            }
            else
            {
                txb_data.Value = condutor.Validade;
            }

            this.condutor = condutor;
        }
    }
}
