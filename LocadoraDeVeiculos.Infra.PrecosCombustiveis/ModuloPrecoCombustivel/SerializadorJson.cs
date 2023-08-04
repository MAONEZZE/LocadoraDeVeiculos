using LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel;
using System.Text.Json;

namespace LocadoraDeVeiculos.Infra.PrecosCombustiveis.ModuloPrecoCombustivel
{
    public class SerializadorJson : ISerializador
    {

        private string arquivo;

        public SerializadorJson(string arquivo)
        {
            this.arquivo = arquivo;
        }

        public PrecoCombustivel CarregarDadosDoArquivo()
        {
            if (File.Exists(arquivo) == false)
                return new PrecoCombustivel();

            string json = File.ReadAllText(arquivo);

            return JsonSerializer.Deserialize<PrecoCombustivel>(json)!;
        }

        public void GravarDadosNoArquivo(PrecoCombustivel dados)
        {
            var config = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(dados, config);

            File.WriteAllText(arquivo, json);

        }
    }

}
