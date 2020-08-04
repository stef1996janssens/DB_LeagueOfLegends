using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
	public class Skin
	{
		// ----------
		// Properties
		// ----------
		public int SkinId { get; set; }
		public string SkinNaam { get; set; }
		public int RiotPointPrice { get; set; }
		public int ChampionId { get; set; }

		// ---------------------
		// Navigation Properties
		// ---------------------

		public virtual Champion Champion { get; set; }
		
	}
}
