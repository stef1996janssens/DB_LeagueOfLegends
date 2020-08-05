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
			modelBuilder.Entity<Champion>().Property(champion => champion.BlueEssencePrice);
			modelBuilder.Entity<Champion>().Property(champion => champion.RiotPointPrice);
			

			// ----
			// Skin
			// ----

			modelBuilder.Entity<Skin>().ToTable("Skins");
			modelBuilder.Entity<Skin>().HasKey(skin => skin.SkinId);
			modelBuilder.Entity<Skin>().Property(skin => skin.SkinNaam).HasMaxLength(50).IsRequired();
			modelBuilder.Entity<Skin>().Property(skin => skin.RiotPointPrice);
			modelBuilder.Entity<Skin>().HasOne(skin => skin.Champion)
				.WithMany(skin => skin.Skins)
				.HasForeignKey(skin => skin.ChampionId)
				.HasConstraintName("FK_Skin_Champion");


			// ------------
			// SEEDING
			// ------------

			// -= Champions =-

			modelBuilder.Entity<Champion>().HasData
				(
				new Champion { ChampionId = 1, ChampionNaam = "Aatrox" },
				new Champion { ChampionId = 2, ChampionNaam = "Ahri" },
				new Champion { ChampionId = 3, ChampionNaam = "Akali" },
				new Champion { ChampionId = 4, ChampionNaam = "Alistar" },
				new Champion { ChampionId = 5, ChampionNaam = "Amumu" },
				new Champion { ChampionId = 6, ChampionNaam = "Anivia" },
				new Champion { ChampionId = 7, ChampionNaam = "Annie" },
				new Champion { ChampionId = 8, ChampionNaam = "Aphelios" },
				new Champion { ChampionId = 9, ChampionNaam = "Ashe" },
				new Champion { ChampionId = 10, ChampionNaam = "Aurelion Sol" }

				);

			// -= Skins =-

			modelBuilder.Entity<Skin>().HasData
				(
				new Skin { SkinId =1 , SkinNaam="Justicar Aatrox", RiotPointPrice=975 ,ChampionId=1},
				new Skin { SkinId =2 , SkinNaam="Mecha Aatrox", RiotPointPrice=1350 ,ChampionId=1},
				new Skin { SkinId =3 , SkinNaam = "Sea Hunter Aatrox", RiotPointPrice = 750, ChampionId =1},
				new Skin { SkinId =4 , SkinNaam = "Blood Moon Aatrox", RiotPointPrice =1350, ChampionId =1},
				new Skin { SkinId =5 , SkinNaam = "Blood Moon Aatrox Prestige Edition", ChampionId =1},
				new Skin { SkinId =6 , SkinNaam = "Victorious Aatrox",  ChampionId =1},
				new Skin { SkinId =7, SkinNaam = "Dynasty Ahri", RiotPointPrice =975, ChampionId =2},
				new Skin { SkinId =8, SkinNaam = "Midnight Ahri", RiotPointPrice =750 , ChampionId =2},
				new Skin { SkinId =9, SkinNaam = "Foxfire Ahri", RiotPointPrice =975, ChampionId =2},
				new Skin { SkinId = 10, SkinNaam = "Popstar Ahri ", RiotPointPrice =975 , ChampionId =2  },
				new Skin { SkinId= 11, SkinNaam="Challenger Ahri", ChampionId=2},
				new Skin { SkinId = 12, SkinNaam = "Academy Ahri", RiotPointPrice =750 , ChampionId = 2 },
				new Skin { SkinId = 13, SkinNaam = "Arcade Ahri", RiotPointPrice = 1350, ChampionId = 2 },
				new Skin { SkinId = 14, SkinNaam = "Star Guardian Ahri", RiotPointPrice =1820 , ChampionId = 2 },
				new Skin { SkinId = 15, SkinNaam = "K/DA Ahri", RiotPointPrice =1350 , ChampionId =2  },
				new Skin { SkinId = 16, SkinNaam = "K/DA Ahri Prestige Edition", ChampionId =2},
				new Skin { SkinId = 17, SkinNaam = "Elderwood Ahri", RiotPointPrice =1350 , ChampionId =2}			
				);
		}
	}
}
