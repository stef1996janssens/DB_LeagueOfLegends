using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
	public class Champion
	{
		// ----------
		// Properties
		// ----------
		public int ChampionId { get; set; }
		public string ChampionNaam { get; set; }
		public int BlueEssencePrice { get; set; }
		public int RiotPointPrice { get; set; }

		// ---------------------
		// Navigation Properties
		// ---------------------
		public virtual ICollection<Skin> Skins { get; set; } = new List<Skin>();
		public virtual RegionNames Region { get; set; }

	}
}
