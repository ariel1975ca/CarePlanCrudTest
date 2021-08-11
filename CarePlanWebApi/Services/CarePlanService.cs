using System.Collections.Generic;

using CarePlanWebApi.Models;

using Microsoft.Extensions.Logging;

namespace CarePlanWebApi.Services
{
    /// <summary>
    /// handles all the CarePlan CRUD operations
    /// </summary>
    public class CarePlanService
    {
        #region - Constants and enumerations -


        #endregion

        #region - Properties -

        /// <summary>
        /// The data service
        /// </summary>
        private readonly DataService _dataService;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<DataService> _logger;

        #endregion - Properties -

        #region - Constructors -

        /// <summary>
        /// Initializes a new instance of the <see cref="CarePlanService"/> class.
        /// </summary>
        /// <param name="dataService">The data service.</param>
        /// <param name="logger">The logger.</param>
        public CarePlanService(DataService dataService, ILogger<DataService> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        #endregion - Constructors -

        #region - Public methods -

        /// <summary>
        /// Gets the care plans.
        /// </summary>
        /// <returns>A list of api models</returns>
        public IEnumerable<ApiCarePlan> GetCarePlans()
        {
            return _dataService.GetCarePlans();
        }

        /// <summary>
        /// Gets the care plan by the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The api model</returns>
        public ApiCarePlan GetCarePlan(int id)
        {
            return _dataService.GetCarePlan(id);
        }

        /// <summary>
        /// Creates the care plan.
        /// </summary>
        /// <param name="carePlan">The care plan.</param>
        /// <returns></returns>
        public ApiCarePlan CreateCarePlan(ApiCarePlan carePlan)
        {
            //TO-DO -- validations then create the plan

            return _dataService.CreateCarePlan(carePlan);
        }

        /// <summary>
        /// Updates the care plan.
        /// </summary>
        /// <param name="carePlan">The care plan.</param>
        /// <returns></returns>
        public ApiCarePlan UpdateCarePlan(ApiCarePlan carePlan)
        {
            //TO-DO -- validations then update the plan

            return _dataService.UpdateCarePlan(carePlan);
        }

        /// <summary>
        /// Deletes the care plan.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public bool DeleteCarePlan(int id)
        {
            return _dataService.DeleteCarePlan(id);
        }

        #endregion - Public methods -

        #region - Private methods -



        #endregion - Private methods -
    }
}
