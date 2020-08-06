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
			modelBuilder.Entity<Champion>().Property(champion => champion.Region).HasMaxLength(25).IsRequired();
			

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

			// -------
			// Regions
			// -------



			// ------------
			// SEEDING
			// ------------

			// -= Champions =-

			modelBuilder.Entity<Champion>().HasData
				(
				new Champion { ChampionId = 1, ChampionNaam = "Aatrox", BlueEssencePrice = 4800, RiotPointPrice = 880, },
				new Champion { ChampionId = 2, ChampionNaam = "Ahri", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 3, ChampionNaam = "Akali", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 4, ChampionNaam = "Alistar", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 5, ChampionNaam = "Amumu", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 6, ChampionNaam = "Anivia", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 7, ChampionNaam = "Annie", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 8, ChampionNaam = "Aphelios", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 9, ChampionNaam = "Ashe", BlueEssencePrice=450, RiotPointPrice=260 },
				new Champion { ChampionId = 10, ChampionNaam = "Aurelion Sol", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 11, ChampionNaam = "Azir", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 12, ChampionNaam = "Bard", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 13, ChampionNaam = "Blitzcrank", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 14, ChampionNaam = "Brand", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 15, ChampionNaam = "Braum", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 16, ChampionNaam = "Caitlyn", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 17, ChampionNaam = "Camille", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 18, ChampionNaam = "Cassiopeia", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 19, ChampionNaam = "Cho'Gath", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 20, ChampionNaam="Corki", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 21, ChampionNaam = "Darius", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 22, ChampionNaam = "Diana", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 23, ChampionNaam = "Draven", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 24, ChampionNaam = "Dr. Mundo", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 25, ChampionNaam = "Ekko", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 26, ChampionNaam = "Elise", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 27, ChampionNaam = "Evelynn", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 28, ChampionNaam = "Ezreal", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 29, ChampionNaam = "Fiddlesticks", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 30, ChampionNaam = "Fiora", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 31, ChampionNaam = "Fizz", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 32, ChampionNaam = "Galio", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 33, ChampionNaam = "Gangplank", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 34, ChampionNaam = "Garen",BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 35, ChampionNaam = "Gnar", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 36, ChampionNaam = "Gragas", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 37, ChampionNaam = "Graves", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 38, ChampionNaam = "Hecarim", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 39, ChampionNaam = "Heimerdinger", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 40, ChampionNaam = "Illaoi", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 41, ChampionNaam = "Irelia", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 42, ChampionNaam = "Ivern", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 43, ChampionNaam = "Janna", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 44, ChampionNaam = "Jarvan IV", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 45, ChampionNaam = "Jax", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 46, ChampionNaam = "Jayce", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 47, ChampionNaam = "Jhin", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 48, ChampionNaam = "Jinx", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 49, ChampionNaam = "Kai'Sa", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 50, ChampionNaam ="Kalista", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 51, ChampionNaam = "Karma", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 52, ChampionNaam = "Karthus", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 53, ChampionNaam = "Kassadin", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 54, ChampionNaam = "Katarina", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 55, ChampionNaam = "Kayle", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 56, ChampionNaam = "Kayn", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 57, ChampionNaam = "Kennen", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 58, ChampionNaam = "Kha'Zix", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 59, ChampionNaam = "Kindred", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 60, ChampionNaam="Kled", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 61, ChampionNaam = "Kog'Maw", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 62, ChampionNaam = "LeBlanc", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 63, ChampionNaam = "Lee Sin", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 64, ChampionNaam = "Leona", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 65, ChampionNaam = "Lillia", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 66, ChampionNaam = "Lissandra", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 67, ChampionNaam = "Lucian", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 68, ChampionNaam = "Lulu", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 69, ChampionNaam = "Lux", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 70, ChampionNaam = "Malphite", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 71, ChampionNaam = "Malzahar", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 72, ChampionNaam = "Maokai", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 73, ChampionNaam = "Master Yi", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 74, ChampionNaam = "Miss Fortune", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 75, ChampionNaam = "Mordekaiser", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 76, ChampionNaam = "Morgana", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 77, ChampionNaam = "Nami", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 78, ChampionNaam = "Nasus", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 79, ChampionNaam = "Nautilus", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 80, ChampionNaam = "Neeko", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 81, ChampionNaam = "Nidalee", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 82, ChampionNaam = "Nocturne", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 83, ChampionNaam = "Nunu & Willump", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 84, ChampionNaam = "Olaf", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 85, ChampionNaam = "Orianna", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 86, ChampionNaam = "Ornn", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 87, ChampionNaam = "Pantheon", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 88, ChampionNaam = "Poppy", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 89, ChampionNaam = "Pyke", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 90, ChampionNaam = "Qiyana", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 91, ChampionNaam = "Quinn", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 92, ChampionNaam = "Rakan", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 93, ChampionNaam = "Rammus", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 94, ChampionNaam = "Rek'Sai", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 95, ChampionNaam = "Renekton", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 96, ChampionNaam = "Rengar", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 97, ChampionNaam = "Riven", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 98, ChampionNaam = "Rumble", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 99, ChampionNaam = "Ryze", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 100, ChampionNaam = "Sejuani", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 101, ChampionNaam= "Senna", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 102, ChampionNaam = "Sett", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 103, ChampionNaam = "Shaco", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 104, ChampionNaam = "Shen", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 105, ChampionNaam = "Shyvana", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 106, ChampionNaam = "Singed", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 107, ChampionNaam = "Sion", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 108, ChampionNaam = "Sivir", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 109, ChampionNaam = "Skarner", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 110, ChampionNaam = "Sona", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 111, ChampionNaam = "Soraka", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 112, ChampionNaam = "Swain", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 113, ChampionNaam = "Sylas", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 114, ChampionNaam = "Syndra", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 115, ChampionNaam = "Tahm Kench", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 116, ChampionNaam = "Taliyah", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 117, ChampionNaam = "Talon", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 118, ChampionNaam = "Taric", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 119, ChampionNaam = "Teemo", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 120, ChampionNaam = "Thresh", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 121, ChampionNaam = "Tristana", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 122, ChampionNaam = "Trundle", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 123, ChampionNaam = "Tryndamere", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 124, ChampionNaam = "Twisted Fate", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 125, ChampionNaam = "Twitch", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 126, ChampionNaam = "Udyr", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 127, ChampionNaam = "Urgot", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 128, ChampionNaam = "Varus", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 129, ChampionNaam = "Vayne", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 130, ChampionNaam = "Veigar", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 131, ChampionNaam = "Vel'Koz", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 132, ChampionNaam = "Vi", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 133, ChampionNaam = "Viktor", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 134, ChampionNaam = "Vladimir", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 135, ChampionNaam = "Volibear", BlueEssencePrice = 3150, RiotPointPrice = 790 },
				new Champion { ChampionId = 136, ChampionNaam = "Warwick", BlueEssencePrice = 450, RiotPointPrice = 260 },
				new Champion { ChampionId = 137, ChampionNaam = "Wukong", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 138, ChampionNaam = "Xayah", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 139, ChampionNaam = "Xerath", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 140, ChampionNaam = "Xin Zhao", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 141, ChampionNaam = "Yasuo", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 142, ChampionNaam = "Yone" },
				new Champion { ChampionId = 143, ChampionNaam = "Yorick", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 144, ChampionNaam = "Yuumi", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 145, ChampionNaam = "Zac", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 146, ChampionNaam = "Zed", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 147, ChampionNaam = "Ziggs", BlueEssencePrice = 4800, RiotPointPrice = 880 },
				new Champion { ChampionId = 148, ChampionNaam = "Zilean", BlueEssencePrice = 1350, RiotPointPrice = 585 },
				new Champion { ChampionId = 149, ChampionNaam = "Zoe", BlueEssencePrice = 6300, RiotPointPrice = 975 },
				new Champion { ChampionId = 150, ChampionNaam = "Zyra", BlueEssencePrice = 4800, RiotPointPrice = 880 }
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
