using System;

using Microsoft.EntityFrameworkCore;

namespace CarePlanWebApi.DataLayer.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public partial class CarePlanDBContext
    {
		/// <summary>
		/// Gets the connection string.
		/// </summary>
		/// <value>
		/// The connection string.
		/// </value>
		public String ConnectionString { get; }

		/// <summary>
		/// <para>
		/// Override this method to configure the database (and other options) to be used for this context.
		/// This method is called for each instance of the context that is created.
		/// </para>
		/// <para>
		/// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
		/// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
		/// the options have already been set, and skip some or all of the logic in
		/// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
		/// </para>
		/// </summary>
		/// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
		/// typically define extension methods on this object that allow you to configure the context.</param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConnectionString);

			base.OnConfiguring(optionsBuilder);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IrriSmartDbContext" /> class.
		/// </summary>
		/// <param name="appSettings">The application settings.</param>
		public CarePlanDBContext(DL_AppSettings appSettings)
		{
			ConnectionString = appSettings.ConnectionString;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IrriSmartDbContext"/> class.
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		public CarePlanDBContext(string connectionString)
		{
			ConnectionString = connectionString;
		}
	}
}
