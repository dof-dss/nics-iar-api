using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IAR.Infrastructure
{
    public class MockUnitOfWorkAsync : IUnitOfWorkAsync
    {
        private readonly Dictionary<Type, object> _repositories;
        private readonly string _idPropertyName;

        public MockUnitOfWorkAsync(string idPropertyName)
        {
            _repositories = new Dictionary<Type, object>();
            _idPropertyName = idPropertyName;
        }

        public IRepositoryAsync<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepositoryAsync<TEntity>;
            }

            var repository = new Repositories.MockRepositoryAsync<TEntity>(_idPropertyName);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task Save()
        {
            // Silly code to simulate an operation which would take a second or two to complete
            await Task.Run(() => { Thread.Sleep(1000); });
        }
    }
}
