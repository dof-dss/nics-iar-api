using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using IAR.Domain.LookupLists;
using IAR.WebApi.DTOModels;
using IAR.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IAR.WebApi.Controllers.v1
{
    [Route("api/v1/")]
    public class ListsController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWork;

        public ListsController(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the specified lookup list
        /// </summary>
        /// <param name="type">The following List Types are supported <list type="bullet"><item>ApplicableRight</item><item>ApplicableRight</item><item>ApplicableRight</item><item>ApplicableRight</item><item>ApplicableRight</item></list></param>
        /// <returns></returns>
        /// <response code="200">The requested list was successfully returned</response>
        /// <response code="204">The list exists but no items were returned</response>
        /// <response code="400">The request was not valid</response> 
        /// <response code="404">The selected resource could not be found</response>          
        [Route("{type}")]
        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<LookupListItem>>> Get(ListType type)
        {            
            List<LookupListItem> results = null;
            switch (type)
            {
                case ListType.ApplicableRight:
                    results = await this.GetLookupList<ApplicableRight, LookupListItem>(_unitOfWork, "ApplicableRightId", "Description");
                    break;
                case ListType.AssetStatus:
                    results = results = await this.GetLookupList<AssetStatus, LookupListItem>(_unitOfWork, "AssetStatusId", "Description");
                    break;
                case ListType.AssetValue:
                    results = await this.GetLookupList<AssetValue, LookupListItem>(_unitOfWork, "AssetValueId", "Description");
                    break;
                case ListType.BusinessImpactLevel:
                    results = await this.GetLookupList<BusinessImpactLevel, LookupListItem>(_unitOfWork, "BusinessImpactLevelId", "BusinessImpactLevelDescription");
                    break;
                case ListType.GovernmentSecurityClassification:
                    results = await this.GetLookupList<GovernmentSecurityClassification, LookupListItem>(_unitOfWork, "GovernmentSecurityClassificationId", "Description");
                    break;
                case ListType.LawfulProcessingCondition:
                    results = await this.GetLookupList<LawfulProcessingCondition, LookupListItem>(_unitOfWork, "LawfulProcessingConditionId", "Description");
                    break;
                case ListType.PersonalDataSource:
                    results = await this.GetLookupList<PersonalDataSource, LookupListItem>(_unitOfWork, "PersonalDataSourceId", "Description");
                    break;
                case ListType.PersonalDataSpecialCategory:
                    results = await this.GetLookupList<PersonalDataSpecialCategory, LookupListItem>(_unitOfWork, "PersonalDataSpecialCategoryId", "Description");
                    break;
                case ListType.ProtectiveMarkingClassification:
                    results = await this.GetLookupList<ProtectiveMarkingClassification, LookupListItem>(_unitOfWork, "ProtectiveMarkingClassificationId", "ProtectiveMarkingClassificationDescription");
                    break;
                case ListType.RetentionPeriod:
                    results = await this.GetLookupList<RetentionPeriod, LookupListItem>(_unitOfWork, "RetentionPeriodId", "Description");
                    break;
                case ListType.SpecialCategoryLawfulProcessingCondition:
                    results = await this.GetLookupList<SpecialCategoryLawfulProcessingCondition, LookupListItem>(_unitOfWork, "SpecialCategoryLawfulProcessingConditionId", "Description");
                    break;
                case ListType.OrganisationalSecurityMeasure:
                    results = await this.GetLookupList<OrganisationalSecurityMeasure, LookupListItem>(_unitOfWork, "OrganisationalSecurityMeasureId", "Description");
                    break;
                default:
                    return NotFound();
            }

            if (results != null)
            {
                if(results.Count == 0)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(results);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }


    public enum ListType
    {
        Unknown = 0,
        ApplicableRight = 1,
        AssetValue = 2,
        AssetStatus = 3,
        LawfulProcessingCondition = 4,
        BusinessImpactLevel = 5,
        GovernmentSecurityClassification = 6,
        PersonalDataSource = 7,
        PersonalDataSpecialCategory = 8,
        RetentionPeriod = 9,
        ProtectiveMarkingClassification = 10,
        SpecialCategoryLawfulProcessingCondition = 11,
        OrganisationalSecurityMeasure = 12
    }
}
