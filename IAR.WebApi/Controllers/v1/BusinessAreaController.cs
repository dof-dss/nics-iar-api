using System.Collections.Generic;
using System.Threading.Tasks;
using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using IAR.Domain.LookupLists;
using IAR.WebApi.DTOModels;
using IAR.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace IAR.WebApi.Controllers.v1
{
    [Route("api/v1/")]
    public class BusinessAreasController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public BusinessAreasController(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all Business Areas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">A list of business areas</response>
        /// <response code="204">No business areas were found</response>
        /// <response code="400">The request was not valid</response> 
        /// <response code="404">The selected resource could not be found</response>  
        [Route("{department}/{division}/[controller]")]
        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<LookupListItem>>> Get(string department, string division)
        {
            List<PropertyMapping> mappings = new List<PropertyMapping>
            {
                new PropertyMapping() { SourcePropertyName = "BusinessAreaId", TargetPropertyName = "Id" },
                new PropertyMapping() { SourcePropertyName = "BusinessAreaName", TargetPropertyName = "Description" }
            };

            return await this.GetLookupList<BusinessArea, LookupListItem>(_unitOfWork, mappings);
        }
    }
}
