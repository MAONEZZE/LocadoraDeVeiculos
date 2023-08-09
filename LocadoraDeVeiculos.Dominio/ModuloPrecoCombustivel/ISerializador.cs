
namespace LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel
{
    public interface ISerializador
    {
        PrecoCombustivel CarregarDadosDoArquivo();

        void GravarDadosNoArquivo(PrecoCombustivel dados);
    }
}
