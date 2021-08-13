using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CarePlanWebApi.DataLayer;
using CarePlanWebApi.DataLayer.Models;
using CarePlanWebApi.Models;

namespace CarePlanWebApi.Helpers
{
    /// <summary>
    /// Manage the transformation from DB entities to Api models
    /// </summary>
    public static class ApiModelHelper
    {
        #region - ApiCarePlan -

        /// <summary>
        /// Gets the API care plan from database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static ApiCarePlan GetApiCarePlanFromDb(TcarePlan entity)
        {
            if (entity is null)
            {
                return null;
            }

            ApiCarePlan model = new()
            {
                Id = entity.IdCarePlan,
                Action = entity.Action,
                ActualStartDate = entity.ActualStartDate,
                Completed = entity.Completed ?? false,
                EndDate = entity.EndDate,
                Outcome = entity.Outcome,
                PatientName = entity.PatientName,
                Reason = entity.Reason,
                TargetDate = entity.TargetDate,
                Title = entity.Title,
                UserName = entity.UserName
            };

            return model;
        }

        /// <summary>
        /// Gets the t care plan from model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static TcarePlan GetTCarePlanFromModel(ApiCarePlan model)
        {
            if (model is null)
            {
                return null;
            }

            TcarePlan entity = new()
            {
                IdCarePlan = model.Id,
                Action = model.Action,
                ActualStartDate = model.ActualStartDate,
                Completed = model.Completed,
                EndDate = model.EndDate,
                Outcome = model.Outcome,
                PatientName = model.PatientName,
                Reason = model.Reason,
                TargetDate = model.TargetDate,
                Title = model.Title,
                UserName = model.UserName
            };

            return entity;
        }

        #endregion - ApiCarePlan -
    }
}
