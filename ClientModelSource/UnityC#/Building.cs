using System;

namespace StrategyMagic.GameArchitect
{
    [Serializable]
    public class Building : CatalogObject
    {
        // [Serializable]
        // public class Price :  object 
        // {
        // 	public string Resource;
        // 	public int Amount = 0;
        // 	public Price(string Resource, int Amount)
        // 	{
        // 		this.Resource = Resource;
        // 		this.Amount = Amount;
        // 	}
        // }
        public uint Level = 0;
        // public List<Price> cost = new List<Price>();
        public Building(string CurCode, string CurDescr,  int Level)
        {
            Code = CurCode;
            Description = CurDescr;
            this.Level = Level;
            //	this.cost = cost;
        }
    }//public class Building
}