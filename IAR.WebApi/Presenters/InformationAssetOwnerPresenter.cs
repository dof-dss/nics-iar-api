// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using DSS.Architecture.Patterns.DotNet.Clean.Presenters;
using IAR.Domain.Admin;
using IAR.WebApi.DTOModels;

namespace IAR.WebApi.Presenters
{
    internal class InformationAssetOwnerPresenter : IPresenter<User, InformationAssetOwnerModel>
    {
        public InformationAssetOwnerPresenter()
        {
        }

        public InformationAssetOwnerModel Build(User source)
        {
            InformationAssetOwnerModel model = new InformationAssetOwnerModel
            {
                DisplayName = source.DisplayName,
                BusinessAreaName = source.BusinessArea.BusinessAreaName,
                Id = source.UserId
            };
            return model;
        }
    }
}
