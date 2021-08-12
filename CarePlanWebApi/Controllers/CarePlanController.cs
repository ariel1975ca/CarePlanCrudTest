using System;
using System.Collections.Generic;

using CarePlanWebApi.Models;
using CarePlanWebApi.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarePlanWebApi.Controllers
{
    /// <summary>
    ///   Handle the API interactions with the Care Plans
    /// </summary>
    [ApiController]
    [Route("careplans")]
    public class CarePlanController : ControllerBase
    {
        #region - Constants and enumerations -


        #endregion

        #region - Properties -

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<CarePlanController> _logger;

        /// <summary>
        /// The care plan service
        /// </summary>
        private readonly CarePlanService _carePlanService;

        #endregion - Properties -

        #region - Constructors -

        /// <summary>
        /// Initializes a new instance of the <see cref="CarePlanController" /> class.
        /// </summary>
        /// <param name="carePlanService">The care plan service.</param>
        /// <param name="logger">The logger.</param>
        public CarePlanController(CarePlanService carePlanService, ILogger<CarePlanController> logger)
        {
            _carePlanService = carePlanService;
            _logger = logger;
        }

        #endregion - Constructors -

        #region - Public methods -

        // GET: api/careplans
        /// <summary>
        /// Gets all the care plans.
        /// </summary>
        /// <returns>
        /// An Array with all the Care Plans
        /// </returns>
        /// <response code="200">Care plans retreived.</response>
        /// <response code="500">An unexpected error occurs.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiCarePlan>), 200)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public IActionResult Get()
        {
            IEnumerable<ApiCarePlan> apiModels;
            try
            {
                apiModels = _carePlanService.GetCarePlans();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "There was an error during the CarePlanController.Get request!");

                return StatusCode(StatusCodes.Status500InternalServerError, ApiError.InternalServerError(new ApiErrorMessage(0, ex.Message)));
            }

            return new OkObjectResult(apiModels ?? new List<ApiCarePlan>());
        }

        // GET: api/careplans/<id>
        /// <summary>
        /// Gets the care plan by its identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <response code="200">Care plan result created.</response>
        /// <response code="400">The Id specified is not valid.</response>
        /// <response code="404">No care plan found with the specified Id.</response>
        /// <response code="500">An unexpected error occurs.</response>
        [HttpGet("{id}", Name = "GetCarePlan")]
        [ProducesResponseType(typeof(ApiCarePlan), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public IActionResult GetCarePlan(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ApiError.BadRequestError());
            }

            ApiCarePlan apiModel;
            try
            {
                apiModel = _carePlanService.GetCarePlan(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "There was an error during the CarePlanController.GetCarePlan request!");

                return StatusCode(StatusCodes.Status500InternalServerError, ApiError.InternalServerError(new ApiErrorMessage(0, ex.Message)));
            }

            if (apiModel == null)
            {
                return NotFound(ApiError.NotFoundError());
            }

            return new OkObjectResult(apiModel);
        }

        // POST: api/careplans
        /// <summary>
        /// Create the specified care plan.
        /// </summary>
        /// <param name="carePlan">The care plan to create.</param>
        /// <response code="201">Care plan created on the server.</response>
        /// <response code="400">No care plan specified or not valid.</response>
        /// <response code="500">There was an error creating the care plan.</response>
        [HttpPost()]
        [ProducesResponseType(typeof(ApiCarePlan), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public IActionResult CreateCarePlan([FromBody] ApiCarePlan carePlan)
        {
            // Here we can also validate the Care plan specifications ()
            if (carePlan == null)
            {
                return BadRequest();
            }

            ApiCarePlan apiModel;
            try
            {
                apiModel = _carePlanService.CreateCarePlan(carePlan);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "There was an error during the CarePlanController.CreateCarePlan request!");

                return StatusCode(StatusCodes.Status500InternalServerError, ApiError.InternalServerError(new ApiErrorMessage(0, ex.Message)));
            }

            if (apiModel == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtRoute("GetCarePlan", new { id = apiModel.Id }, apiModel);
        }

        // PUT: api/careplans/<id>
        /// <summary>
        /// Update the specified care plan.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="carePlan">The care plan to update.</param>
        /// <returns></returns>
        /// <response code="202">Care plan updated.</response>
        /// <response code="400">No care plan to update or not valid.</response>
        /// <response code="404">No care plan found with the specified Id.</response>
        /// <response code="500">There was an error creating the care plan.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiCarePlan), 202)]
        [ProducesResponseType(typeof(ApiError), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public IActionResult UpdateCarePlan(int id, [FromBody] ApiCarePlan carePlan)
        {
            if (carePlan == null || carePlan.Id != id)
            {
                return BadRequest();
            }

            ApiCarePlan apiModel;
            try
            {
                apiModel = _carePlanService.UpdateCarePlan(carePlan);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "There was an error during the CarePlanController.UpdateCarePlan request!");

                return StatusCode(StatusCodes.Status500InternalServerError, ApiError.InternalServerError(new ApiErrorMessage(0, ex.Message)));
            }

            if (apiModel == null)
            {
                return NotFound();
            }

            return AcceptedAtRoute("GetCarePlan", new { id = apiModel.Id }, apiModel);
        }

        // DELETE: api/careplans/<id>
        /// <summary>
        /// Deletes the specified care plan by its identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <response code="204">Care plan deleted.</response>
        /// <response code="400">The Id specified is not valid.</response>
        /// <response code="404">No care plan with the specified Id.</response>
        /// <response code="500">There was an error creating the care plan.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 204)]
        [ProducesResponseType(typeof(ApiError), 400)]
        [ProducesResponseType(typeof(ApiError), 404)]
        [ProducesResponseType(typeof(ApiError), 500)]
        public IActionResult DeleteCarePlan(int id)
        {
            bool result;
            try
            {
                result = _carePlanService.DeleteCarePlan(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "There was an error during the CarePlanController.DeleteCarePlan request!");

                return StatusCode(StatusCodes.Status500InternalServerError, ApiError.InternalServerError(new ApiErrorMessage(0, ex.Message)));
            }

            if (!result)
            {
                return NotFound();
            }

            return new NoContentResult();
        }

        #endregion - Public methods -
    }
}
