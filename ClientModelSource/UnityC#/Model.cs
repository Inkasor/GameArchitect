using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StrategyMagic.GameArchitect {
    //DataModel общий класс модели данных на клиенте, реализующий в том числе общие методы транспорта сообщений клиент-сервер.
    //Данный класс напрямую зависит от движка клиента и является ключевой точкой интеграции.
    //Все методы, реализованные в классе, целиком и полностью используют механизмы, предоставляемые движками.
    //Все игровые данные, синхронизируемые с сервером, должны быть полностью видимы движку и доступны из других подсистем.
	[Serializable]
	public class DataModel : MonoBehaviour {
        
        public static CreateFromJson(string JsonString)
		{
			return JsonUtility.FromJson<DataModel> (JsonString);
		}
               
		public void LoadFromJson(string JsonString)
		{
			JsonUtility.FromJsonOverwrite (JsonString, this);
		}
        
		public string SaveToJson()
		{
			return JsonUtility.ToJson(this);
		}
	}//public class DataModel 
    
    //Класс CatalogObject служит для хранения справочных данных, неизменяемых в течении игровой сессии.
    //Чтение конкретных справочных данных происходит при Start().
          
	[Serializable]
	public class CatalogObject : DataModel {   
        [Serializable]
        
   		public string Code;
        [Serializable]
		public string Description;       
	}//public class CatalogObject

    //Класс InformationRegisterRecord служит для хранения индивидуальной записи текущих данных, 
    //примерно соответствуя строке таблицы временной выборки в SQL, или значению в нереляционных базах данных. 
    //Такие данные сравнительно редко изменяются в течении игровой сессии

	[Serializable]
	public class InformationRegisterRecord : DataModel {
        
        [Serializable]
 		public int Code;
	}//public class InformationRegisterRecord
    
    //Класс QueueRecord служит для хранения очередей индивидуальных записи текущих данных, 
    //примерно соответствуя одиночному синхронизирующему сообщению   
    //Такие данные могут очень часто изменяться в течении игровой сессии 
    
	[Serializable]
	public class QueueRecord : DataModel {
        
        [Serializable]
 		public int Code;
	}//public class QueueRecord
}//namespace