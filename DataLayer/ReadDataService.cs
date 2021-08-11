using System;
using System.Collections.Generic;
using System.Linq;

using CarePlanWebApi.DataLayer.Models;

using Microsoft.EntityFrameworkCore;

namespace CarePlanWebApi.DataLayer
{
    /// <summary>
    /// handles all the read data access to DB
    /// </summary>
    public static class ReadDataService
    {
		#region - TcarePlan -

		/// <summary>
		/// Gets all the care plans.
		/// </summary>
		/// <param name="dbContext">The database context.</param>
		/// <returns></returns>
		/// <exception cref="System.ApplicationException"></exception>
		public static List<TcarePlan> GetCarePlans(CarePlanDBContext dbContext, bool asNoTracking = true)
		{
			try
			{
				var query = dbContext.TcarePlan as IQueryable<TcarePlan>;

				if (asNoTracking)
				{
					query = query.AsNoTracking();
				}

				return query.ToList();
			}
			catch (Exception ex)
			{
				throw new ApplicationException(Constants.DATABASE_GENERIC_READ_DATA_ERROR_MESSAGGE, ex);
			}
		}

		/// <summary>
		/// Gets the care plan with the specified identifier.
		/// </summary>
		/// <param name="dbContext">The database context.</param>
		/// <param name="idCarePlan">The identifier care plan.</param>
		/// <param name="asNoTracking">if set to <c>true</c> [as no tracking].</param>
		/// <returns></returns>
		/// <exception cref="System.ApplicationException"></exception>
		public static TcarePlan GetCarePlan(CarePlanDBContext dbContext, int idCarePlan, bool asNoTracking = true)
		{
			try
			{
				var query = dbContext.TcarePlan.Where(x => x.IdCarePlan == idCarePlan);

				if (asNoTracking)
				{
					query = query.AsNoTracking();
				}

				return query.SingleOrDefault();
			}
			catch (Exception ex)
			{
				throw new ApplicationException(Constants.DATABASE_GENERIC_READ_DATA_ERROR_MESSAGGE, ex);
			}
		}

		#endregion - TcarePlan -
	}
}
