using IAR.Domain.InformationAssets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR.Business.Repositories
{
    public interface IInformationAssetRepository
    {
        Task<Asset> Get(int id);

        Task<IQueryable<Asset>> Get();

        Task Add(Asset asset);

        Task Delete(Asset asset);

        Task Update(Asset asset);
    }
}
