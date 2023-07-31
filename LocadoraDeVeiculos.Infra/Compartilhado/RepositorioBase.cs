using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    public abstract class RepositorioBase<T>: IRepositorioBase<T> where T : EntidadeBase<T>
    {
        protected readonly LocadoraDeVeiculosDbContext dbContext;

        protected DbSet<T> registros;

        public RepositorioBase(LocadoraDeVeiculosDbContext dbContext)
        {
            this.dbContext = dbContext;

            registros = dbContext.Set<T>();
        }

        public void Inserir(T novoRegistro)
        {
            registros.Add(novoRegistro);

            dbContext.SaveChanges();
        }

        public void Editar(T registro)
        {
            registros.Update(registro);

            dbContext.SaveChanges();
        }

        public void Excluir(T registro)
        {
            registros.Remove(registro);

            dbContext.SaveChanges();
        }

        public bool Existe(T registro)
        {
            return registros.Contains(registro);
        }

        public virtual T SelecionarPorId(int id)
        {
            return registros.SingleOrDefault(t => t.Id == id)!;
        }

        public virtual List<T> SelecionarTodos()
        {
            return registros.ToList();
        }
    
    }
}
