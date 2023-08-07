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
                chk_clienteCondut.Checked = true;

                AlterarVisibilidadeCampos(false);
            }
        }

        private void AlterarVisibilidadeCampos(bool habilitador)
        {
            txb_email.Enabled = habilitador;
            txb_nome.Enabled = habilitador;
            mtxb_cpf.Enabled = habilitador;
            mtxb_telefone.Enabled = habilitador;
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
            condutor.ValidadeCNH = txb_data.Value;
            condutor.Cliente = (Cliente)cbox_cliente.SelectedItem;

            Result resultado = onGravarRegistro(condutor);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        public Condutor AlimentarCampos(Condutor condutor)
        {
            txb_nome.Text = condutor.Nome;
            txb_email.Text = condutor.Email;
            mtxb_telefone.Text = condutor.Telefone;
            mtxb_cpf.Text = condutor.Documento;
            txb_cnh.Text = condutor.Cnh;

            if (condutor.ValidadeCNH == DateTime.MinValue)
            {
                txb_data.Value = DateTime.Now;
            }
            else
            {
                txb_data.Value = condutor.ValidadeCNH;
            }

            return condutor;
        }

        public void ConfigurarCondutor(Condutor condutor)
        {
            this.condutor = AlimentarCampos(condutor);
        }

        private void chk_clienteCondut_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_clienteCondut.Checked == true)
            {
                AlterarVisibilidadeCampos(false);
            }
            else if(chk_clienteCondut.Checked == false)
            {
                AlterarVisibilidadeCampos(true);
            }
        }
    }
}
