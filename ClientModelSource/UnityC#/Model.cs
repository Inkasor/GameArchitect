using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StrategyMagic.GameArchitect {
	[Serializable]
	public class CatalogObject : MonoBehaviour {

		public void LoadFromJson(string JsonString)
		{
			JsonUtility.FromJsonOverwrite (JsonString, this);
		}

		public string SaveToJson()
		{
			return JsonUtility.ToJson(this);
		}

	}//public class CatalogObject

	[Serializable]
	public class Buildings : CatalogObject {
		[Serializable]
		public class Price :  object 
		{
			public string Resource;
			public int Amount = 0;
			public Price(string Resource, int Amount)
			{
				this.Resource = Resource;
				this.Amount = Amount;
			}
		}
		public string Ref;
		public bool DeletionMark;
		public string Code;
		public string Description;
		public string GameDescr;
		public int Level = 0;
		public List<Price> cost = new List<Price>();
		public Buildings (string GameDescr, int Level, List<Price> cost)
		{
			this.GameDescr = GameDescr;
			this.Level = Level;
			this.cost = cost;
		}

		public static Buildings CreateFromJson(string JsonString)
		{
			return JsonUtility.FromJson<Buildings> (JsonString);
		}

	}//public class Buildings
}//namespace