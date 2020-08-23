using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Data
{
	public class ApplicationContext: DbContext
	{
		public ApplicationContext(DbContextOptions options)
			: base(options)
		{}

		public DbSet<MyAppRequest> MyAppRequest { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MyAppRequest>()
				.Property(e => e.RequestId)
				.IsUnicode(true);

			modelBuilder.Entity<MyAppRequest>()
				.Property(e => e.Status)
				.IsUnicode(false);

			modelBuilder.Entity<MyAppRequest>()
				.Property(e => e.Details)
				.IsUnicode(false);

			base.OnModelCreating(modelBuilder);
		}
	}
}
