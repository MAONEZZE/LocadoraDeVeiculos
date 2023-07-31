using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Servico.ModuloCupom;

namespace LocadoraDeVeiculos.WinApp.ModuloCupom
{
    public class ControladorCupom : ControladorBase
    {

        ServicoCupom servicoCupom;
        IRepositorioCupom repositorioCupom;
        IRepositorioParceiro repositorioParceiro;

        TabelaCupomControl tabelaCupom;

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



        public override void Excluir()
        {
            throw new NotImplementedException();
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

            mensagemRodape = $"Visualizando {listagem.Count} cupo{sufixo}";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCupom();
        }
    }
}
