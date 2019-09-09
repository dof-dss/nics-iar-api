using System.Collections.Generic;
using System.Threading.Tasks;
using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using IAR.Domain.LookupLists;
using IAR.WebApi.DTOModels;
using IAR.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace IAR.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class AssetStatusController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public AssetStatusController(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        ///// <summary>
        ///// Gets all Asset Statuses
        ///// </summary>
        ///// <returns></returns>
        ///// <response code="200">Returns the list of Asset Statuses</response>
        ///// <response code="404">If no Asset Statuses can be found</response>  
        //[HttpGet]
        //[Produces("application/json")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //public async Task<ActionResult<List<LookupListItem>>> Get()
        //{
        //    List<PropertyMapping> mappings = new List<PropertyMapping>
        //    {
        //        new PropertyMapping() { SourcePropertyName = "AssetStatusId", TargetPropertyName = "Id" },
        //        new PropertyMapping() { SourcePropertyName = "Description", TargetPropertyName = "Description" }
        //    };

        //    return await this.GetLookupList<AssetStatus, LookupListItem>(_unitOfWork, mappings);
        //}
    }
}
