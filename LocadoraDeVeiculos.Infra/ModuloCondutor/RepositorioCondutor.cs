using LocadoraDeVeiculos.Dominio.ModuloCondutor;

namespace LocadoraDeVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutor : RepositorioBase<Condutor>, IRepositorioCondutor
    {
        public RepositorioCondutor(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }
        public bool EhValido(Condutor condutor)
        {

            var encontrado = registros.SingleOrDefault(x => x.Documento == condutor.Documento);

            if (encontrado == null || encontrado.Id == condutor.Id)
                return true;

            return false;
        }
    }
}
