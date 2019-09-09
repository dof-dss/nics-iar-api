using System.Collections.Generic;
using IAR.WebApi.DTOModels;
using IAR.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using IAR.Business.GetMyInformationAssets;
using DSS.Architecture.Patterns.DotNet.Clean.Gateways;
using DSS.Architecture.Patterns.DotNet.Clean.Interactors;
using IAR.Business.SaveInformationAsset;
using Microsoft.Extensions.Logging;

namespace IAR.WebApi.Controllers.v1
{
    [Route("api/v1/[controller]/")]
    public class AssetsController : Controller
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        private readonly ILogger _logger;

        public AssetsController(IUnitOfWorkAsync unitOfWork, ILogger<AssetsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Gets all Information Assets
        /// </summary>       
        /// <response code="200">A list of Information Assets was successfully returned</response>
        /// <response code="204">An empty list of Inforamtion Assets was successfully returned. The resource exists and executed sucessfully, however, no records were found</response>
        /// <response code="400">The request was not valid</response> 
        /// <response code="404">The selected resource could not be found</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<AssetModel>>> GetAll()
        {
            GetMyInformationAssetsUsecase usecase = new GetMyInformationAssetsUsecase(_unitOfWork);
            var response = await usecase.Handle(1);

            switch (response.ResponseType)
            {
                case DSS.Architecture.Patterns.DotNet.Clean.Interactors.ResponseTypes.Success:
                    if (response.Data == null || response.Data.Count() == 0)
                    {
                        return NotFound();
                    }
                    List<AssetModel> data = new List<AssetModel>();
                    var presenter = new AssetPresenter();

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
        /// Get a specified Information Asset using it's unique Id
        /// </summary>       
        /// <param name="id">the unique Id of the Information Asset resource</param>
        /// <response code="200">A single Information Assets was successfully returned</response>        
        /// <response code="400">The request was not valid</response> 
        /// <response code="404">The selected resource could not be found</response>   
        [Route("{id}")]
        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<AssetModel>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                GetMyInformationAssetsUsecase usecase = new GetMyInformationAssetsUsecase(_unitOfWork);
                var response = await usecase.Handle(1);

                switch (response.ResponseType)
                {
                    case DSS.Architecture.Patterns.DotNet.Clean.Interactors.ResponseTypes.Success:
                        // The usecase executed successfully, meaning it connected to the datastore, however, need to check if data was found...
                        if (response.Data == null || response.Data.Count() == 0)
                        {
                            return NotFound();
                        }
                        var presenter = new AssetPresenter();
                        return presenter.Build(response.Data.First());
                    default:
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                // will want to log error here...
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets all Information Assets held by the specified department
        /// </summary>       
        /// <param name="department">accepts a string which specifies the short department name. For example DoF, DoJ, DE, etc.</param>
        /// <response code="200">A list of Information Assets was successfully returned</response>
        /// <response code="204">An empty list of Inforamtion Assets was successfully returned. The resource exists and executed sucessfully, however, no records were found</response>
        /// <response code="400">The request was not valid</response> 
        /// <response code="404">The selected resource could not be found</response> 
        [Route("{department}")]
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<AssetModel>>> GetByDepartment(string department)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(department))
                {
                    return BadRequest();
                }

                GetMyInformationAssetsUsecase usecase = new GetMyInformationAssetsUsecase(_unitOfWork);
                var response = await usecase.Handle(1);

                switch (response.ResponseType)
                {
                    case ResponseTypes.Success:
                        // The usecase executed successfully, meaning it connected to the datastore, however, need to check if data was found...
                        if (response.Data == null || response.Data.Count() == 0)
                        {
                            return NotFound();
                        }
                        List<AssetModel> data = new List<AssetModel>();
                        var presenter = new AssetPresenter();

                        foreach (var item in response.Data)
                        {
                            data.Add(presenter.Build(item));
                        }
                        return data;
                    default:
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                // will want to log error here...
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets all Information Assets held by the specified departmental division
        /// </summary>       
        /// <param name="department">accepts a string which specifies the short department name. For example DoF, DoJ, DE, etc.</param>
        /// <param name="division">accepts a string the name of the departmental division</param>
        /// <response code="200">A list of Information Assets was successfully returned</response>
        /// <response code="204">An empty list of Inforamtion Assets was successfully returned. The resource exists and executed sucessfully, however, no records were found</response>
        /// <response code="400">The request was not valid</response> 
        /// <response code="404">The selected resource could not be found</response> 
        [Route("{department}/{division}")]
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<AssetModel>>> GetByDivision(string department, string division)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(department) || string.IsNullOrWhiteSpace(division))
                {
                    return BadRequest();
                }

                GetMyInformationAssetsUsecase usecase = new GetMyInformationAssetsUsecase(_unitOfWork);
                var response = await usecase.Handle(1);

                _logger.LogInformation("Usecase returned " + response.ResponseType.ToString());
                switch (response.ResponseType)
                {
                    case ResponseTypes.Success:
                        // The usecase executed successfully, meaning it connected to the datastore, however, need to check if data was found...
                        if (response.Data == null || response.Data.Count() == 0)
                        {
                            return NotFound();
                        }
                        List<AssetModel> data = new List<AssetModel>();
                        var presenter = new AssetPresenter();

                        foreach (var item in response.Data)
                        {
                            data.Add(presenter.Build(item));
                        }
                        return data;
                    default:
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get a list of Information Assets by Division");                
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets all Information Assets held by the specified departmental business area
        /// </summary>       
        /// <param name="department">accepts a string which specifies the short department name. For example DoF, DoJ, DE, etc.</param>
        /// <param name="division">accepts a string which specifies the name of the departmental division</param>
        /// <param name="businessArea">accepts a string the name of the departmental division</param>
        /// <response code="200">A list of Information Assets was successfully returned</response>
        /// <response code="204">An empty list of Inforamtion Assets was successfully returned. The resource exists and executed sucessfully, however, no records were found</response>
        /// <response code="400">The request was not valid</response> 
        /// <response code="404">The selected resource could not be found</response> 
        [Route("{department}/{division}/{businessArea}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<AssetModel>>> GetByBusinessArea(string department, string division, string businessArea)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(department) || string.IsNullOrWhiteSpace(division) || string.IsNullOrWhiteSpace(businessArea))
                {
                    return BadRequest();
                }

                GetMyInformationAssetsUsecase usecase = new GetMyInformationAssetsUsecase(_unitOfWork);
                var response = await usecase.Handle(1);

                switch (response.ResponseType)
                {
                    case ResponseTypes.Success:
                        // The usecase executed successfully, meaning it connected to the datastore, however, need to check if data was found...
                        if (response.Data == null || response.Data.Count() == 0)
                        {
                            return NotFound();
                        }
                        List<AssetModel> data = new List<AssetModel>();
                        var presenter = new AssetPresenter();

                        foreach (var item in response.Data)
                        {
                            data.Add(presenter.Build(item));
                        }
                        return data;
                    default:
                        return BadRequest();
                }
            }
            catch (Exception ex)
            {
                // will want to log error here...
                return BadRequest();
            }
        }

        /// <summary>
        /// Creates a new Information Asset resource
        /// </summary>
        /// <param name="value">accepts an object which contains the new Information Asset</param>        
        /// <response code="200">A new Information Asset resource was successfully created</response>        
        /// <response code="400">The request was not valid</response>         
        [Route("[controller]")]
        [HttpPost]
        [ProducesResponseType(200)]        
        [ProducesResponseType(400)]        
        public async Task<ActionResult> Post([FromBody] AssetModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            SaveInformationAssetUsecase usecase = new SaveInformationAssetUsecase(_unitOfWork);
            var response = await usecase.Handle(value);

            switch (response.ResponseType)
            {
                case ResponseTypes.Success:
                    var presenter = new AssetPresenter();
                    return Ok(presenter.Build(response.Asset));
                default:
                    return BadRequest();
            }
        }

        /// <summary>
        /// Updates an existing Information Asset resource
        /// </summary>
        /// <param name="id">accepts an integer which specifies the Id of the resource to update</param>
        /// <param name="value">accepts an object which contains the new Information Asset</param>        
        /// <response code="200">A specified resource was updated successfully</response>        
        /// <response code="400">The request was not valid</response>
        [Route("[controller]/{id}")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Put(int id, [FromBody]AssetModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            SaveInformationAssetUsecase usecase = new SaveInformationAssetUsecase(_unitOfWork);
            value.AssetId = id;
            var response = await usecase.Handle(value);

            switch (response.ResponseType)
            {
                case ResponseTypes.Success:
                    var presenter = new AssetPresenter();
                    return Ok(presenter.Build(response.Asset));
                default:
                    return BadRequest();
            }
        }

        [Route("[controller]/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}