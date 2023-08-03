using LocadoraDeVeiculos.Dominio.ModuloFuncionario;


namespace LocadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public Funcionario BuscarPorNome(string nome)
        {
            return registros.SingleOrDefault(p => p.Nome == nome)!;
        }

        public bool EhValido(Funcionario funcionario)
        {
            var encontrado = BuscarPorNome(funcionario.Nome);

            return encontrado == null || encontrado.Id == funcionario.Id;
        }
}
}
