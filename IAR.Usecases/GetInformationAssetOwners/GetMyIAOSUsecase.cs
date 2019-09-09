using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using DSS.Architecture.Patterns.DotNet.Clean.Interactors;
using IAR.Business.Repositories;
using IAR.Domain.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAR.Business.GetInformationAssetOwners
{
    public class GetMyIAOSUsecase : IRequestHandlerAsync<int, ReadResponseMessage<User>>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public GetMyIAOSUsecase(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handles getting a list of users that are information asset owners and returns the ones the specified user has access to.
        /// </summary>
        /// <param name="userId">accepts an <see cref="int"/> which specifies the id of the user that wants to view the list of Information Asset Owners</param>
        /// <returns></returns>
        public async Task<ReadResponseMessage<User>> Handle(int userId)
        {
            var repository = _unitOfWork.GetRepository<User>();
            var user = await repository.Get(userId);

            var iaoUsers = new List<User>();
            foreach(var item in user.LinkedUsers)
            {
                if (item.LinkedUser.IsIAO)
                {
                    iaoUsers.Add(item.LinkedUser);
                }
            }

            var response = ResponseFactory.BuildReadResponse($"{user.LinkedUsers.Count()} records returned", iaoUsers);
            return response;
        }
    }
}
