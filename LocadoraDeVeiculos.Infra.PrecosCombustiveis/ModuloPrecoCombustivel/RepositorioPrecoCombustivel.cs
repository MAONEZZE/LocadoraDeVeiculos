using LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel;

namespace LocadoraDeVeiculos.Infra.PrecosCombustiveis.ModuloPrecoCombustivel
{
    public class RepositorioPrecoCombustivel : IRepositorioPrecoCombustivel
    {
        ISerializador serializador;

        public RepositorioPrecoCombustivel(ISerializador serializador)
        {
            this.serializador = serializador;           
        }

        public void Atualizar(PrecoCombustivel dados)
        {
            serializador.GravarDadosNoArquivo(dados);
        }


        public PrecoCombustivel Buscar()
        {
            return serializador.CarregarDadosDoArquivo();
        }

    }

}
