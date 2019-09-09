using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using DSS.Architecture.Patterns.DotNet.Clean.Interactors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR.Business.GetLookupList
{
    public class GetLookupListUsecase<TEntity> : IRequestHandlerAsync<ReadResponseMessage<TEntity>>
        where TEntity : class
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public GetLookupListUsecase(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReadResponseMessage<TEntity>> Handle()
        {
            var repository = _unitOfWork.GetRepository<TEntity>();
            // First get all assets, then filter by those that are in 
            var allData = await repository.GetAll();            
            var response = ResponseFactory.BuildReadResponse($"{allData.Count()} Records returned", allData);
            return response;
        }
    }
}
