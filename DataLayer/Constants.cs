namespace CarePlanWebApi.DataLayer
{
    /// <summary>
    /// Holds some internal constants
    /// </summary>
    internal static class Constants
	{
		internal const string DATABASE_GENERIC_READ_DATA_ERROR_MESSAGGE = "There was an error reading data from the database!";
		internal const string DATABASE_GENERIC_WRITE_DATA_ERROR_MESSAGGE = "There was an error saving changes to the database!";
		internal const string DATABASE_GENERIC_GET_DATA_ERROR_MESSAGGE_TEMPLATE = "No {0} data found for the specified id(s) {1}!";
	}
}
