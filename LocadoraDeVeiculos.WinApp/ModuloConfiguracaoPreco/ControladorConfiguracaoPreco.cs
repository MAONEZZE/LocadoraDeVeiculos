
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using System.Text.Json;

namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracaoPreco
{
    public class ControladorConfiguracaoPreco
    {
        IRepositorioPrecoCombustivel RepositorioConfigurarPreco;

        public ControladorConfiguracaoPreco(IRepositorioPrecoCombustivel repositorioConfigurarPreco)
        {
            RepositorioConfigurarPreco = repositorioConfigurarPreco;
        }

        public void ConfigurarPrecoCombustivel()
        {
            var configuracao = RepositorioConfigurarPreco.ObterConfiguracaoDeCombustivel();

            var tela = new TelaConfigurarPrecoForm(configuracao);

            tela.onGravarConfiguracao += RepositorioConfigurarPreco.GravarConfiguracoesCombustivel;
           
            if(tela.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Atualização de preços de combustível efetuada com sucesso.","Configurar Preço", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }

    public class RepositorioPrecoCombustivel: IRepositorioPrecoCombustivel
    {

        private string arquivo;

        public RepositorioPrecoCombustivel(string arquivo)
        {
            this.arquivo = arquivo;
        }

        public void GravarConfiguracoesCombustivel(PrecoCombustivel dados)
        {
            var config = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(dados, config);

            File.WriteAllText(arquivo, json);
        }

       
        public PrecoCombustivel ObterConfiguracaoDeCombustivel()
        {
            if (File.Exists(arquivo) == false)
                return new PrecoCombustivel();

            string json = File.ReadAllText(arquivo);

            return JsonSerializer.Deserialize<PrecoCombustivel>(json)!;
        }
    }
}
