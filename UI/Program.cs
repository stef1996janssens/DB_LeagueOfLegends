using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.Repositories;
using System;
using System.Linq;

namespace UI
{
	class Program
	{
		static void Main(string[] args)
		{
			

			string[] input = { "1", "2", "3", "4", "X" };
			string keuze = string.Empty;

			while (keuze != "X")
			{
				Console.WriteLine("***************************************");
				Console.WriteLine("WELKOM IN DE LEAGUE OF LEGENDS DATABASE");
				Console.WriteLine("***************************************");

				Console.WriteLine();
				Console.WriteLine();

				Console.WriteLine("====================================");
				Console.WriteLine("MAAK UW KEUZE UIT ONDERSTAAND MENU");
				Console.WriteLine("====================================");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine();
				Console.WriteLine("[1] Toon alle champions in alfabetische volgorde");
				Console.WriteLine("[2] Toon alle skins van 1 bepaalde champion");
				Console.WriteLine("[3] Toon alle skins van 1 bepaalde champion onder een bepaalde prijs");

				Console.WriteLine("X - Afsluiten");
				Console.WriteLine();
				
				keuze = Console.ReadLine().ToUpper();
				Console.WriteLine();
				Console.Clear();

				if (!input.Contains(keuze))
				{
					Console.WriteLine("Geef uw keuze:");
					keuze = Console.ReadLine().ToUpper();
				}

				switch (keuze)
				{
					case "1":
						ToonAlleChampionsAlfabetisch();
						break;
					case "2":
						ToonAlleSkinsVan1Champion();
						break;
					case "3":
						ToonSkinsMetBepaaldePrijsVan1Champion();
						break;
				}

				if (keuze.ToUpper() == "X") break;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("\nDruk op een toets om terug te gaan naar het menu");
				Console.ReadKey();
				Console.Clear();
			}
		}

		public static void ToonAlleChampionsAlfabetisch()
		{
			
			using var context = new LeagueOfLegendsContext();

			var champions = from champion in context.Champions
							orderby champion.ChampionNaam
							select champion;
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("----------------------------------------");
			Console.WriteLine("ALLE CHAMPIONS IN ALFABETISCHE VOLGORDE");
			Console.WriteLine("----------------------------------------");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Cyan;

			foreach(var champion in champions)
			{
				Console.WriteLine($"{champion.ChampionNaam}");
			}
		}

		public static void ToonAlleSkinsVan1Champion()
		{
			using var context = new LeagueOfLegendsContext();

			Console.WriteLine("Geef de championNaam op waarvan je alle skins wilt zien");
			var gekozenChampion = Console.ReadLine().ToUpper();
			Console.Clear();
			


			var skins = from skin in context.Skins.Include("Champion")
						where skin.Champion.ChampionNaam.ToUpper() == gekozenChampion
						orderby skin.SkinNaam
						select skin;

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write("----------------");
			LijntjesMetLengteChampionNaam(gekozenChampion);
			Console.WriteLine($"\nALLE SKINS VAN {gekozenChampion}");
			Console.Write("----------------");
			LijntjesMetLengteChampionNaam(gekozenChampion);
			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.Cyan;


			foreach(var skin in skins)
			{
				string riotPointString;
				if(skin.RiotPointPrice == Decimal.Zero)
				{
					riotPointString = (skin.RiotPointPrice).ToString();
					riotPointString = "Niet verkrijgbaar met";
				}
				else
				{
					riotPointString = (skin.RiotPointPrice).ToString();
				}
				Console.WriteLine($"{skin.SkinNaam}:\t {riotPointString} RP");
			}
		}

		public static void ToonSkinsMetBepaaldePrijsVan1Champion()
		{
			using var context = new LeagueOfLegendsContext();

			Console.WriteLine("Geef de championNaam op waarvan je alle skins wilt zien");
			var gekozenChampion = Console.ReadLine().ToUpper();
			Console.WriteLine();
			Console.WriteLine("Geef de maximale RPprijs op die je wilt betalen voor de skin");
			
			var gekozenRPPrijs = int.Parse(Console.ReadLine());

			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write("------------------------------");
			LijntjesMetLengteChampionNaam(gekozenChampion);
			Console.WriteLine($"\nALLE SKINS VAN {gekozenChampion} ONDER {gekozenRPPrijs} RP");
			Console.Write("------------------------------");
			LijntjesMetLengteChampionNaam(gekozenChampion);
			Console.WriteLine();

			var skins = from skin in context.Skins.Include("Champion")
						where skin.Champion.ChampionNaam.ToUpper() == gekozenChampion
						where skin.RiotPointPrice < gekozenRPPrijs && skin.RiotPointPrice > 0
						
						orderby skin.SkinNaam
						select skin;


			Console.ForegroundColor = ConsoleColor.Cyan;
			foreach (var skin in skins)
			{
				string riotPointString;
				if (skin.RiotPointPrice == Decimal.Zero)
				{
					riotPointString = (skin.RiotPointPrice).ToString();
					riotPointString = "Niet verkrijgbaar met";
				}
				else
				{
					riotPointString = (skin.RiotPointPrice).ToString();
				}
				Console.WriteLine($"{skin.SkinNaam}:\t {riotPointString} RP");
			}
		}

		public static void LijntjesMetLengteChampionNaam(string gekozenChampion)
		{
			for (int i = 0; i < gekozenChampion.Length; i++)
			{
				Console.Write("-");
			}
		}
	}
}
