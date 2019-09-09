using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR.Infrastructure.Repositories
{
    public class MockRepositoryAsync<TEntity> : IRepositoryAsync<TEntity>
          where TEntity : class
    {
        private List<TEntity> DataSource;
        private string _idProperty;

        public MockRepositoryAsync(string idPropertyName)
        {
            DataSource = new List<TEntity>();
            _idProperty = idPropertyName;
        }

        public async Task Create(TEntity obj)
        {
            await Task.Run(() => { DataSource.Add(obj); });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() =>
            {
                var entity = DataSource.Find(item => (int)item.GetType().GetProperty(_idProperty).GetValue(item) == id);
                DataSource.Remove(entity);
            });
        }

        public async Task Edit(TEntity obj)
        {
            await Task.Run(() =>
            {
                // calculate where in the collection the entity is...
                var indexOf = DataSource.FindIndex(item => item.GetType().GetProperty(_idProperty).GetValue(item) == obj.GetType().GetProperty(_idProperty).GetValue(obj));

                if (indexOf >= 0)
                {
                    DataSource[indexOf] = obj;
                }
            });
        }

        public async Task<IEnumerable<TEntity>> Find(Func<TEntity, bool> filter)
        {
            IEnumerable<TEntity> results = null;
            await Task.Run(() => { results = DataSource.Where(filter); });
            return results;
        }

        public async Task<TEntity> Get(int id)
        {
            var result = await Task.Run(() =>
            {
                object obj = null;
                foreach (var item in DataSource)
                {
                    if ((int)item.GetType().GetProperty(_idProperty).GetValue(item) == id)
                    {
                        obj = item;
                    }
                }
                return obj;
            });

            return (TEntity)result;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            IEnumerable<TEntity> results = null;
            await Task.Run(() => { results = DataSource; });
            return results;
        }
    }
}
