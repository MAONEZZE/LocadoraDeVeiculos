using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.Infra.ModuloCupom;
using LocadoraDeVeiculos.Infra.ModuloTaxaServico;
using LocadoraDeVeiculos.Servico.ModuloTaxaServico;
using LocadoraDeVeiculos.WinApp.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxaServico
{
    public class ControladorTaxaServico : ControladorBase
    {
        private readonly IRepositorioTaxaServico repositorioTaxaServico;

        private readonly ServicoTaxaServico servicoTaxaServico;


        private TabelaTaxaServicoUserControl tabelaTaxaServico;

        public ControladorTaxaServico(ServicoTaxaServico servicoTaxaServico, IRepositorioTaxaServico repositoriorTaxaServico)
        {
            this.servicoTaxaServico = servicoTaxaServico;
            this.repositorioTaxaServico = repositoriorTaxaServico;
        }

        public override void Editar()
        {
            Guid guidTaxaServico = tabelaTaxaServico.ObterIdSelecionado();

            if (guidTaxaServico == null)
            {
                MessageBox.Show($"Selecione uma Taxa ou Serviço para poder editar!",
                    "Edição de Taxa ou Serviço",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            TaxaServico taxaServicoSelecionada = repositorioTaxaServico.SelecionarPorId(guidTaxaServico);

            TelaTaxaServicoForm telaTaxaServico = new TelaTaxaServicoForm
            {
                Text = "Editar Taxa ou Serviço"
            };

            telaTaxaServico.ConfigurarTela(taxaServicoSelecionada);

            telaTaxaServico.onGravarRegistro += servicoTaxaServico.Editar;

           DialogResult resultado = telaTaxaServico.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {

            TelaTaxaServicoForm telaTaxaServico = new TelaTaxaServicoForm
            {
                Text = "Cadastrar Taxa ou Serviço"
            };

            telaTaxaServico.onGravarRegistro += servicoTaxaServico.Editar;

            DialogResult resultado = telaTaxaServico.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                AtualizarListagem();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxTaxaServico();
        }

        public override UserControl ObtemListagem()
        {
            tabelaTaxaServico ??= new TabelaTaxaServicoUserControl();

            AtualizarListagem();

            return tabelaTaxaServico;
        }
        private void AtualizarListagem()
        {
            var listagem = repositorioTaxaServico.SelecionarTodos();

            tabelaTaxaServico.AtualizarRegistros(listagem);

            AtualizarRodape(listagem);
        }
        private void AtualizarRodape(List<TaxaServico> listagem)
        {
            mensagemRodape = $"Visualizando {listagem.Count} de Taxas ou Serviços";

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
