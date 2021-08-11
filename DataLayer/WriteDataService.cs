using System;
using System.Linq;

using CarePlanWebApi.DataLayer.Models;

namespace CarePlanWebApi.DataLayer
{
    /// <summary>
    /// handles all the create/update/delete operations to DB
    /// </summary>
    public static class WriteDataService
    {
        #region - TcarePlan -

        /// <summary>
        /// Creates the care plan.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="idCarePlan">The identifier care plan.</param>
        /// <param name="title">The title.</param>
        /// <param name="patientName">Name of the patient.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="actualStartDate">The actual start date.</param>
        /// <param name="targetDate">The target date.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="action">The action.</param>
        /// <param name="completed">The completed.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="outcome">The outcome.</param>
        /// <param name="savechanges">if set to <c>true</c> [savechanges].</param>
        /// <returns>
        /// the newly created Care Plan
        /// </returns>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        /// <exception cref="System.ApplicationException"></exception>
        public static TcarePlan CreateCarePlan(
			CarePlanDBContext dbContext,
			int idCarePlan,
			string title,
			string patientName,
			string userName,
			DateTime actualStartDate,
			DateTime targetDate,
			string reason,
			string action,
			bool? completed = null,
			DateTime? endDate = null,
			string outcome = null,
			bool savechanges = true)
		{
            if (dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            var entity = new TcarePlan()
			{
				IdCarePlan = idCarePlan,
				Title = title,
				PatientName = patientName,
				UserName = userName,
				ActualStartDate = actualStartDate,
				TargetDate = targetDate,
				Reason = reason,
				Action = action,
				Completed = completed,
				EndDate = endDate,
				Outcome = outcome
			};

			dbContext.TcarePlan.Add(entity);

			if (savechanges)
			{
				try
				{
					dbContext.SaveChanges();
				}
				catch (Exception ex)
				{
					throw new ApplicationException(Constants.DATABASE_GENERIC_WRITE_DATA_ERROR_MESSAGGE, ex);
				}
			}

			return entity;
		}

		/// <summary>
		/// Updates the care plan.
		/// </summary>
		/// <param name="dbContext">The database context.</param>
		/// <param name="idCarePlan">The identifier care plan.</param>
		/// <param name="title">The title.</param>
		/// <param name="patientName">Name of the patient.</param>
		/// <param name="userName">Name of the user.</param>
		/// <param name="actualStartDate">The actual start date.</param>
		/// <param name="targetDate">The target date.</param>
		/// <param name="reason">The reason.</param>
		/// <param name="action">The action.</param>
		/// <param name="completed">The completed.</param>
		/// <param name="endDate">The end date.</param>
		/// <param name="outcome">The outcome.</param>
		/// <param name="savechanges">if set to <c>true</c> [savechanges].</param>
		/// <returns>
		/// the updated Care Plan
		/// </returns>
		/// <exception cref="System.ArgumentNullException">dbContext</exception>
		/// <exception cref="System.ApplicationException"></exception>
		public static TcarePlan UpdateCarePlan(
			CarePlanDBContext dbContext, 
			int idCarePlan,
			string title,
			string patientName,
			string userName,
			DateTime actualStartDate,
			DateTime targetDate,
			string reason,
			string action,
			bool? completed = null,
			DateTime? endDate = null,
			string outcome = null,
			bool savechanges = true)
		{
            if (dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            TcarePlan entity = null;

			try
			{
				entity = dbContext.TcarePlan.SingleOrDefault(x => x.IdCarePlan == idCarePlan);
			}
			catch (Exception ex)
			{
				throw new ApplicationException(Constants.DATABASE_GENERIC_READ_DATA_ERROR_MESSAGGE, ex);
			}

			if (entity == null)
			{
				throw new ApplicationException(string.Format(Constants.DATABASE_GENERIC_GET_DATA_ERROR_MESSAGGE_TEMPLATE, "Care Plan", idCarePlan));
			}

			entity.Title = title;
			entity.PatientName = patientName;
			entity.UserName = userName;
			entity.ActualStartDate = actualStartDate;
			entity.TargetDate = targetDate;
			entity.Reason = reason;
			entity.Action = action;
			entity.Completed = completed;
			entity.EndDate = endDate;
			entity.Outcome = outcome;

			if (savechanges)
			{
				try
				{
					dbContext.SaveChanges();
				}
				catch (Exception ex)
				{
					throw new ApplicationException(Constants.DATABASE_GENERIC_WRITE_DATA_ERROR_MESSAGGE, ex);
				}
			}

			return entity;
		}

        /// <summary>
        /// Deletes the care plan.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="idCarePlan">The identifier care plan.</param>
        /// <param name="savechanges">if set to <c>true</c> [savechanges].</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">dbContext</exception>
        /// <exception cref="System.ApplicationException">
        /// </exception>
        public static bool DeleteCarePlan(CarePlanDBContext dbContext,int idCarePlan, bool savechanges = true)
		{
			if (dbContext is null)
			{
				throw new ArgumentNullException(nameof(dbContext));
			}

			TcarePlan entity = null;

			try
			{
				entity = dbContext.TcarePlan.SingleOrDefault(x => x.IdCarePlan == idCarePlan);
			}
			catch (Exception ex)
			{
				throw new ApplicationException(Constants.DATABASE_GENERIC_READ_DATA_ERROR_MESSAGGE, ex);
			}

			if (entity == null)
			{
				throw new ApplicationException(string.Format(Constants.DATABASE_GENERIC_GET_DATA_ERROR_MESSAGGE_TEMPLATE, "Care Plan", idCarePlan));
			}

			dbContext.TcarePlan.Remove(entity);

			if (savechanges)
			{
				try
				{
					dbContext.SaveChanges();

					return true;
				}
				catch (Exception ex)
				{
					throw new ApplicationException(Constants.DATABASE_GENERIC_WRITE_DATA_ERROR_MESSAGGE, ex);
				}
			}

			return false;
		}

		#endregion - TcarePlan -
	}
}
