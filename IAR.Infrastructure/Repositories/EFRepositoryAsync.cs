using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR.Infrastructure.Repositories
{
    public class EFRepositoryAsync<TEntity, TContext> : IRepositoryAsync<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    {
        private DbSet<TEntity> objectSet;

        public EFRepositoryAsync(TContext context)
        {
            Context = context;
        }

        protected DbSet<TEntity> ObjectSet
        {
            get
            {
                return objectSet ?? (objectSet = Context.Set<TEntity>());
            }
        }

        public TContext Context { get; }

        public async Task Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            await ObjectSet.AddAsync(obj);
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await ObjectSet.FindAsync(id);

            if (itemToDelete != null)
            {
                ObjectSet.Remove(itemToDelete);
            }
        }

        public async Task Edit(TEntity obj)
        {
            await Task.Run(() =>
            {
                ObjectSet.Attach(obj);
                Context.Entry(obj).State = EntityState.Modified;
            });
        }

        public async Task<IEnumerable<TEntity>> Find(Func<TEntity, bool> filter)
        {
            IEnumerable<TEntity> results = null;
            await Task.Run(() => { results = ObjectSet.Where(filter); });
            return results;
        }

        public async Task<TEntity> Get(int id)
        {
            return await ObjectSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> results = null;
            await Task.Run(() => { results = ObjectSet.AsQueryable(); });
            return results;
        }
    }
}
