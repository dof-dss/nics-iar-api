using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using IAR.Business.GetInformationAssetOwners;
using IAR.Business.GetMyInformationAssets;
using IAR.Domain.LookupLists;
using IAR.WebApi.DTOModels;
using IAR.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IAR.WebApi.Controllers.v1
{
    [Route("api/v1/")]
    public class IAOsController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public IAOsController(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all Information Asset Owners
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the list of Information Asset Owners</response>
        /// <response code="404">If no Information Asset Owners can be found</response>       
        [Route("[controller]")]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<InformationAssetOwnerModel>>> Get()
        {
            GetMyIAOSUsecase usecase = new GetMyIAOSUsecase(_unitOfWork);
            var response = await usecase.Handle(0);

            switch (response.ResponseType)
            {
                case DSS.Architecture.Patterns.DotNet.Clean.Interactors.ResponseTypes.Success:

                    // The usecase executed successfully, meaning it connected to the datastore, however, need to check if data was found...
                    if (response.Data == null || response.Data.Count() == 0)
                    {
                        return NotFound();
                    }
                    List<InformationAssetOwnerModel> data = new List<InformationAssetOwnerModel>();
                    var presenter = new InformationAssetOwnerPresenter();

                    foreach (var item in response.Data)
                    {
                        data.Add(presenter.Build(item));
                    }
                    return Ok(data);
                default:
                    return BadRequest();
            }

        }

        /// <summary>
        /// Gets all Information Asset Owners within the specified business area
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the list of Information Asset Owners</response>
        /// <response code="404">If no Information Asset Owners can be found</response>   
        [Route("{department}/{division}/{businessArea}/[controller]")]
        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<InformationAssetOwnerModel>>> GetByBusinessArea(string department, string division, string businessArea)
        {
            GetIAOsByBusinessAreaUsecase usecase = new GetIAOsByBusinessAreaUsecase(_unitOfWork);
            var response = await usecase.Handle(businessArea);

            switch (response.ResponseType)
            {
                case DSS.Architecture.Patterns.DotNet.Clean.Interactors.ResponseTypes.Success:

                    // The usecase executed successfully, meaning it connected to the datastore, however, need to check if data was found...
                    if (response.Data == null || response.Data.Count() == 0)
                    {
                        return NotFound();
                    }
                    List<InformationAssetOwnerModel> data = new List<InformationAssetOwnerModel>();
                    var presenter = new InformationAssetOwnerPresenter();

                    foreach (var item in response.Data)
                    {
                        data.Add(presenter.Build(item));
                    }
                    return Ok(data);
                default:
                    return BadRequest();
            }
        }
    }
}
