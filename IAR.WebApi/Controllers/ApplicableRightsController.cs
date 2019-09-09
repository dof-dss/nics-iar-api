using System.Collections.Generic;
using System.Threading.Tasks;
using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using IAR.Domain.LookupLists;
using IAR.WebApi.DTOModels;
using IAR.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IAR.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class ApplicableRightsController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public ApplicableRightsController(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        ///// <summary>
        ///// Gets all Applicable Rights
        ///// </summary>
        ///// <returns></returns>
        ///// <response code="200">Returns the list of Application Rights</response>
        ///// <response code="404">If no Application Rights can be found</response>  
        //[HttpGet]
        //[Produces("application/json")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //public async Task<ActionResult<List<LookupListItem>>> Get()
        //{
        //    List<PropertyMapping> mappings = new List<PropertyMapping>
        //    {
        //        new PropertyMapping() { SourcePropertyName = "ApplicableRightId", TargetPropertyName = "Id" },
        //        new PropertyMapping() { SourcePropertyName = "Description", TargetPropertyName = "Description" }
        //    };

        //    return await this.GetLookupList<ApplicableRight, LookupListItem>(_unitOfWork, mappings);            
        //}
    }

}
