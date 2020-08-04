using Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32.SafeHandles;

namespace Model.Repositories
{
	public class LeagueOfLegendsContext : DbContext
	{
		public static IConfigurationRoot configuration;
		private bool testMode = false;

		// ------
		// DbSets
		// ------

		public DbSet<Champion> Champions { get; set; }
		public DbSet<Skin> Skins { get; set; }

		// ------------
		// Constructors
		// ------------

		public LeagueOfLegendsContext() { }
		public LeagueOfLegendsContext(DbContextOptions<LeagueOfLegendsContext> options) : base(options) { }

		// -------
		// Logging
		// -------

		private ILoggerFactory GetLoggerFactory()
		{
			IServiceCollection serviceCollection = new ServiceCollection();
			serviceCollection.AddLogging
			(
			builder => builder.AddConsole()
			.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
			);
			return serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				// Zoek de naam in de connectionStrings section - appsettings.json
				configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
					//.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", false)
					 .Build();
				var connectionString = configuration.GetConnectionString("leagueOfLegends");
				if (connectionString != null) // Indien de naam is gevonden
				{
					optionsBuilder.UseSqlServer(
					connectionString
					, options => options.MaxBatchSize(150)); // Max aantal SQL commands die kunnen doorgestuurd worden naar de database
															 // .UseLoggerFactory(GetLoggerFactory())
															 // .EnableSensitiveDataLogging(true) // Toont de waarden van de parameters bij de logging
															 // .UseLazyLoadingProxies();
				}
			}
			else
			{
				testMode = true;
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// --------
			// Champion
			// --------

			modelBuilder.Entity<Champion>().ToTable("Champions");
			modelBuilder.Entity<Champion>().HasKey(champion => champion.ChampionId);
			modelBuilder.Entity<Champion>().Property(champion => champion.ChampionNaam).HasMaxLength(50).IsRequired();
			modelBuilder.Entity<Champion>().Property(champion => champion.BlueEssencePrice).IsRequired();
			modelBuilder.Entity<Champion>().Property(champion => champion.RiotPointPrice).IsRequired();
			

			// ----
			// Skin
			// ----

			modelBuilder.Entity<Skin>().ToTable("Skins");
			modelBuilder.Entity<Skin>().HasKey(skin => skin.SkinId);
			modelBuilder.Entity<Skin>().Property(skin => skin.SkinNaam).HasMaxLength(50).IsRequired();
			modelBuilder.Entity<Skin>().Property(skin => skin.RiotPointPrice).IsRequired();
			modelBuilder.Entity<Skin>().HasOne(skin => skin.Champion)
				.WithMany(skin => skin.Skins)
				.HasForeignKey(skin => skin.SkinId);
		}
	}
}
