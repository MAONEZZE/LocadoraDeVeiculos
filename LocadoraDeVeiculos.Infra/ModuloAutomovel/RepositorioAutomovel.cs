using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Infra.ModuloAutomovel
{
    public class RepositorioAutomovel : RepositorioBase<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovel(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

     
        public override Automovel SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.GrupoAutomovel)
                .SingleOrDefault(x => x.Id == id)!;
        }

        public bool EhValido(Automovel automovel)
        {
            var encontrado = registros.SingleOrDefault(x => x.Placa == automovel.Placa)!;

            if (encontrado == null || encontrado.Id == automovel.Id)
                return true;

            return false;
        }

        public override List<Automovel> SelecionarTodos()
        {
            return registros
                .Include(x => x.GrupoAutomovel)
                .Select(automovel => new Automovel
                {
                    Id = automovel.Id,
                    Marca = automovel.Marca,
                    Modelo = automovel.Modelo,
                    Cor = automovel.Cor,
                    Combustivel = automovel.Combustivel,
                    Ano = automovel.Ano,
                    Placa = automovel.Placa,
                    Quilometragem = automovel.Quilometragem,                
                    CapacidadeDeCombustivel = automovel.CapacidadeDeCombustivel,
                    GrupoAutomovel = automovel.GrupoAutomovel

                }).ToList();

        }

     
    }
}
