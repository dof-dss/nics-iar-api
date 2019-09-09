using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using DSS.Architecture.Patterns.DotNet.Clean.Interactors;
using IAR.Domain.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR.Business.GetInformationAssetOwners
{
    public class GetIAOsByBusinessAreaUsecase : IRequestHandlerAsync<string, ReadResponseMessage<User>>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public GetIAOsByBusinessAreaUsecase(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handles getting a list of users that are information asset owners and returns the ones the specified user has access to.
        /// </summary>
        /// <param name="userId">accepts an <see cref="int"/> which specifies the id of the user that wants to view the list of Information Asset Owners</param>
        /// <returns></returns>
        public async Task<ReadResponseMessage<User>> Handle(string businessAreaName)
        {
            var repository = _unitOfWork.GetRepository<User>();
            var users = await repository.GetAll();
            var results = users.Where(x => x.IsIAO == true && x.BusinessArea.BusinessAreaName == businessAreaName);
            var response = ResponseFactory.BuildReadResponse($"{results.Count()} records returned", results);
            return response;
        }
    }
}
