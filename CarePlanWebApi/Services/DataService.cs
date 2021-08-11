using System;
using System.Collections.Generic;
using System.Linq;

using CarePlanWebApi.DataLayer;
using CarePlanWebApi.DataLayer.Models;
using CarePlanWebApi.Helpers;
using CarePlanWebApi.Models;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CarePlanWebApi.Services
{
    /// <summary>
    /// Handle all the CRUD data request
    /// </summary>
    public class DataService
    {
        #region - Constants and enumerations -


        #endregion

        #region - Properties -

        /// <summary>
        /// The dl application settings
        /// </summary>
        private readonly DL_AppSettings _dlAppSettings;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<DataService> _logger;

        #endregion - Properties -

        #region - Constructors -

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService" /> class.
        /// </summary>
        /// <param name="dlAppSettings">The dl application settings.</param>
        /// <param name="logger">The logger.</param>
        public DataService(IOptions<DL_AppSettings> dlAppSettings, ILogger<DataService> logger)
        {
            _dlAppSettings = dlAppSettings.Value;
            _logger = logger;
        }

        #endregion - Constructors -

        #region - Public methods -

        #region - ApiCarePlan -

        /// <summary>
        /// Gets the care plans.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApiCarePlan> GetCarePlans()
        {
            using var dbContext = this.GetDbContext();

            return ReadDataService.GetCarePlans(dbContext)?.Select(x => ApiModelHelper.GetApiCarePlanFromDb(x));
        }

        /// <summary>
        /// Gets the care plan.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ApiCarePlan GetCarePlan(int id)
        {
            using var dbContext = this.GetDbContext();

            return ApiModelHelper.GetApiCarePlanFromDb(ReadDataService.GetCarePlan(dbContext, id));
        }

        /// <summary>
        /// Creates the care plan.
        /// </summary>
        /// <param name="carePlan">The care plan.</param>
        /// <returns></returns>
        public ApiCarePlan CreateCarePlan(ApiCarePlan carePlan)
        {
            if (carePlan is null)
            {
                throw new ArgumentNullException(nameof(carePlan));
            }

            using var dbContext = this.GetDbContext();

            return ApiModelHelper.GetApiCarePlanFromDb(
                WriteDataService.CreateCarePlan(
                    dbContext,
                    carePlan.Id,
                    carePlan.Title,
                    carePlan.PatientName,
                    carePlan.UserName,
                    carePlan.ActualStartDate,
                    carePlan.TargetDate,
                    carePlan.Reason,
                    carePlan.Action,
                    carePlan.Completed,
                    carePlan.EndDate,
                    carePlan.Outcome));
        }

        /// <summary>
        /// Updates the care plan.
        /// </summary>
        /// <param name="carePlan">The care plan.</param>
        /// <returns></returns>
        public ApiCarePlan UpdateCarePlan(ApiCarePlan carePlan)
        {
            if (carePlan is null)
            {
                throw new ArgumentNullException(nameof(carePlan));
            }

            using var dbContext = this.GetDbContext();

            return ApiModelHelper.GetApiCarePlanFromDb(
                WriteDataService.UpdateCarePlan(
                    dbContext,
                    carePlan.Id,
                    carePlan.Title,
                    carePlan.PatientName,
                    carePlan.UserName,
                    carePlan.ActualStartDate,
                    carePlan.TargetDate,
                    carePlan.Reason,
                    carePlan.Action,
                    carePlan.Completed,
                    carePlan.EndDate,
                    carePlan.Outcome));
        }

        /// <summary>
        /// Deletes the care plan.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>True if the entity was deleted. False otherwise</returns>
        public bool DeleteCarePlan(int id)
        {
            using var dbContext = this.GetDbContext();

            return WriteDataService.DeleteCarePlan(dbContext, id);
        }

        #endregion - ApiCarePlan -

        #endregion - Public methods -

        #region - Private methods -

        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <returns></returns>
        public CarePlanDBContext GetDbContext()
        {
            return new CarePlanDBContext(this._dlAppSettings);
        }

        #endregion - Private methods -
    }
}
