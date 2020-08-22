using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
	public class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions options)
			: base(options)
		{
			var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
			var connectionString = connectionStringBuilder.ToString();
			var connection = new SqliteConnection(connectionString);
		}

		public DbSet<DBRequest> DBRequest { get; set; }
	}
}
