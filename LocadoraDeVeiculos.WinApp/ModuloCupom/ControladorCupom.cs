using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Servico.ModuloCupom;

namespace LocadoraDeVeiculos.WinApp.ModuloCupom
{
    public class ControladorCupom : ControladorBase
    {
        private readonly ServicoCupom servicoCupom;

        private readonly IRepositorioCupom repositorioCupom;

        private readonly IRepositorioParceiro repositorioParceiro;

        private TabelaCupomControl tabelaCupom;

        public ControladorCupom(ServicoCupom servicoCupom, IRepositorioCupom repositorioCupom, IRepositorioParceiro repositorioParceiro)
        {
            this.servicoCupom = servicoCupom;
            this.repositorioCupom = repositorioCupom;
            this.repositorioParceiro = repositorioParceiro;
        }
        public override void Inserir()
        {
            var telaCupom = new TelaCupomForm()
            {
                Text = "Cadastrar Cupom"
            };

            telaCupom.OnObterParceiro_ += repositorioParceiro.SelecionarTodos;

            telaCupom.onGravarRegistro += servicoCupom.Inserir;

            telaCupom.ConfigurarCupom(new Cupom());

            if(telaCupom.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Editar()
        {
            var id = tabelaCupom.ObtemIdSelecionado();

            if (id == 0) return;

            var cupom = repositorioCupom.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma editar o cupom Id: {cupom.Id}?", "Editar Cupom", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var telaCupom = new TelaCupomForm
            {
                Text = "Editar Cupom"
            };

            telaCupom.OnObterParceiro_ += repositorioParceiro.SelecionarTodos;

            telaCupom.onGravarRegistro += servicoCupom.Editar;

            telaCupom.ConfigurarCupom(cupom);

            if (telaCupom.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }



        public override void Excluir()
        {
            var id = tabelaCupom.ObtemIdSelecionado();

            if (id == 0) return;

            var cupom = repositorioCupom.SelecionarPorId(id);

            var opcao = MessageBox.Show($"Confirma excluír o cupom Id: {cupom.Id}?", "Excluír Cupom", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (opcao == DialogResult.No) return;

            var result = servicoCupom.Excluir(cupom);

            if (result.IsFailed)
            {
                var erros = result.Errors.Select(x => x.Message).ToList();

                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
            }

            else
                AtualizarListagem();
        }


        public override UserControl ObtemListagem()
        {
            tabelaCupom ??= new TabelaCupomControl();

            AtualizarListagem();

            return tabelaCupom;
        }

        private void AtualizarListagem()
        {
            var listagem = repositorioCupom.SelecionarTodos();

            tabelaCupom.AtualizarRegistros(listagem);

            AtualizarRodape(listagem);
        }

        private void AtualizarRodape(List<Cupom> listagem)
        {
            var sufixo = listagem.Count > 1 ? "ns" : "m";

            mensagemRodape = $"Visualizando {listagem.Count} cupo{sufixo}.";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCupom();
        }
    }
}
