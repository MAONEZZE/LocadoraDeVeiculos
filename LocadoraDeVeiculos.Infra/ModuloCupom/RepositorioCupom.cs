using LocadoraDeVeiculos.Dominio.ModuloCupom;


namespace LocadoraDeVeiculos.Infra.ModuloCupom
{
    public class RepositorioCupom : RepositorioBase<Cupom>, IRepositorioCupom
    {
        public RepositorioCupom(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public bool EhValido(Cupom cupom)
        {
            var encontrado = registros.SingleOrDefault(x => x.Nome == cupom.Nome)!;

            if (encontrado == null || encontrado.Id == cupom.Id)
                return true;

            return false;
        }

        public override List<Cupom> SelecionarTodos()
        {
            return registros.Include(x=>x.Parceiro).ToList();
        }
    }
}
