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
    public class AssetValueController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public AssetValueController(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        ///// <summary>
        ///// Gets all Asset Values
        ///// </summary>
        ///// <returns></returns>
        ///// <response code="200">Returns the list of Asset Values</response>
        ///// <response code="404">If no Asset Values can be found</response>  
        //[HttpGet]
        //[Produces("application/json")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //public async Task<ActionResult<List<LookupListItem>>> Get()
        //{
        //    List<PropertyMapping> mappings = new List<PropertyMapping>
        //    {
        //        new PropertyMapping() { SourcePropertyName = "AssetValueId", TargetPropertyName = "Id" },
        //        new PropertyMapping() { SourcePropertyName = "Description", TargetPropertyName = "Description" }
        //    };

        //    return await this.GetLookupList<AssetValue, LookupListItem>(_unitOfWork, mappings);
        //}
    }
}
