using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR.Infrastructure
{
    public class UnitOfWorkAsync : IUnitOfWorkAsync
    {
        private readonly Dictionary<Type, object> _repositories;
       
        public UnitOfWorkAsync(IARContext context)
        {
            _repositories = new Dictionary<Type, object>();       
            Context = context;
        }

        public IARContext Context { get; }

        public IRepositoryAsync<TEntity> GetRepository<TEntity>() 
            where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepositoryAsync<TEntity>;
            }

            var repository = new Repositories.EFRepositoryAsync<TEntity, IARContext>(Context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;

        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
