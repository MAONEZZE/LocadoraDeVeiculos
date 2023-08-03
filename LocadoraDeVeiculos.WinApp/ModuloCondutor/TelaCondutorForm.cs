using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCondutorForm : Form
    {
        public event GravarRegistroDelegate<Condutor> onGravarRegistro;
        IRepositorioCliente repCliente;
        private Condutor condutor;

        public TelaCondutorForm(IRepositorioCliente repCliente)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.repCliente = repCliente;

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
            }
        }

        private void cbox_cliente_SelectedValueChanged(object sender, EventArgs e)
        {
            var clienteSelec = (Cliente)cbox_cliente.SelectedValue;

            VerificadorClienteCpf(clienteSelec);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            condutor.Nome = txb_nome.Text;
            condutor.Email = txb_email.Text;
            condutor.Telefone = mtxb_telefone.Text;
            condutor.Documento = mtxb_cpf.Text;
            condutor.Cnh = txb_cnh.Text;
            condutor.ValidadeCnh = txb_data.Value;

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
            txb_data.Value = condutor.ValidadeCnh;

            this.condutor = condutor;
        }
    }
}
