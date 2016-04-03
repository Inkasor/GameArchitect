package StrategyMagic.GameArchitect
{
	import flash.net.ObjectEncoding;
	import flash.net.getClassByAlias;
	import flash.net.registerClassAlias;
	import flash.utils.ByteArray;
	import flash.utils.Dictionary;  
    //DataModel общий класс модели данных на клиенте, реализующий в том числе общие методы транспорта сообщений клиент-сервер.
    //Данный класс напрямую зависит от движка клиента и является ключевой точкой интеграции.
    //Все методы, реализованные в классе, целиком и полностью используют механизмы, предоставляемые движками.
    //Все игровые данные, синхронизируемые с сервером, должны быть полностью видимы движку и доступны из других подсистем.
	public class DataModel extends Object {
        //Определение конструктора
        public function DataModel() 
        { 
        //status = "initialized"; 
        } 
        //Функция создает новый экземпляр класса из переданной строки, содержащей объект JSON
        public static function CreateFromJson(var JsonString:String):DataModel
        {                     
	// 		return JsonUtility.FromJson<DataModel> (JsonString);
	 	}
        //Функция перезаписывает свойства экземпляра класса из переданной строки, содержащей объект JSON        
	 	public function LoadFromJson():void
	 	{
	// 		JsonUtility.FromJsonOverwrite (JsonString, this);
	 	}
        //Функция перезаписывает свойства экземпляра класса из переданной строки, содержащей объект JSON
	 	public function SaveToJson():String
	 	{
	// 		return JsonUtility.ToJson(this);
	 	}
	}//public class DataModel
     
    //Класс CatalogObject служит для хранения справочных данных, неизменяемых в течении игровой сессии.
    //Чтение конкретных справочных данных происходит при Start().
	public class CatalogObject extends DataModel {
        public var Code:String;
        public var Description:String;        
	}//public class CatalogObject

    //Класс InformationRegisterRecord служит для хранения индивидуальной записи текущих данных, 
    //примерно соответствуя строке таблицы временной выборки в SQL, или значению в нереляционных базах данных. 
    //Такие данные сравнительно редко изменяются в течении игровой сессии
	public class InformationRegisterRecord extends DataModel {
 		public var Code:uint;
	}//public class InformationRegisterRecord
    
    //Класс QueueRecord служит для хранения очередей индивидуальных записи текущих данных, 
    //примерно соответствуя одиночному синхронизирующему сообщению   
    //Такие данные могут очень часто изменяться в течении игровой сессии  	
	public class QueueRecord extends DataModel {
       	public var Code:uint;
        public var DateMark:Number;   
	}//public class QueueRecord
}