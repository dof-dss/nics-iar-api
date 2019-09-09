using DSS.Architecture.Patterns.DotNet.Clean.Interactors;
using IAR.Business.Repositories;
using System;
using System.Threading.Tasks;
using System.Linq;
using IAR.Domain.InformationAssets;
using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using IAR.Domain.Admin;

namespace IAR.Business.GetMyInformationAssets
{
    public class GetMyInformationAssetsUsecase : IRequestHandlerAsync<int, ReadResponseMessage<Asset>>
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public GetMyInformationAssetsUsecase(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReadResponseMessage<Asset>> Handle(int userId)
        {
            try
            {
                var userRepo = _unitOfWork.GetRepository<User>();
                var user = await userRepo.Get(userId);

                var repository = _unitOfWork.GetRepository<Asset>();
                // First get all assets, then filter by those that are in 
                var allAssets = await repository.GetAll();
                var myAssets = allAssets.Where(x => user.LinkedUsers.Any(u => u.LinkedUser.UserId == x.InformationAssetOwner.UserId));
                var response = ResponseFactory.BuildReadResponse($"{myAssets.Count()} Information Assets Returned", myAssets);
                return response;
            }
            catch (Exception ex)
            {
                return new ReadResponseMessage<Asset>() {  InnerException = ex, OutputMessage = "Failed to get a list of Information Assets", ResponseType = ResponseTypes.Error };
            }
        }
    }
}
