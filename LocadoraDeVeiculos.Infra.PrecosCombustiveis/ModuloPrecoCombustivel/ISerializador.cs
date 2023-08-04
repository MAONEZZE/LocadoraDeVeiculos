
using LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel;

namespace LocadoraDeVeiculos.Infra.PrecosCombustiveis.ModuloPrecoCombustivel
{
    public interface ISerializador
    {
        PrecoCombustivel CarregarDadosDoArquivo();

        void GravarDadosNoArquivo(PrecoCombustivel dados);
    }
}
