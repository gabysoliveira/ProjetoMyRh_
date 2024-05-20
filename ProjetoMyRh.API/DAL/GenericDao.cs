using Microsoft.EntityFrameworkCore;
using ProjetoMyRh.API.Models.Contexts;

namespace ProjetoMyRh.API.DAL
{
    public class GenericDao<T, K> where T : class
    {
        private MyRhContext Context { get; set; }

        public GenericDao(MyRhContext context)
        {
            this.Context = context;
        }

        // Listando todas as entidades
        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().ToList();
        }

        //Buscando pelo ID
        public T? Buscar(K id)
        {
            return Context.Set<T>().Find(id);
        }

        //Adicionar entidades (registros)
        public void Adicionar(T item)
        {
            //Context.Add<T>(item);
            Context.Entry<T>(item).State = EntityState.Added;
            Context.SaveChanges();
        }

        //Alterar entidades
        public void Alterar(T item)
        {
            Context.Entry<T>(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        //Deletar entidades
        public void Remover(T item)
        {
            Context.Entry<T>(item).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}
