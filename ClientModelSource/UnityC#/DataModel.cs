using System;
using UnityEngine;

namespace StrategyMagic.GameArchitect
{
    //DataModel общий класс модели данных на клиенте, реализующий в том числе общие методы транспорта сообщений клиент-сервер.
    //Данный класс напрямую зависит от движка клиента и является ключевой точкой интеграции.
    //Все методы, реализованные в классе, целиком и полностью используют механизмы, предоставляемые движками.
    //Все игровые данные, синхронизируемые с сервером, должны быть полностью видимы движку и доступны из других подсистем.
    [Serializable]
    public abstract class DataModel : MonoBehaviour
    {

        public static DataModel CreateFromJson(string JsonString)
        {
            return JsonUtility.FromJson<DataModel>(JsonString);
        }

        public void LoadFromJson(string JsonString)
        {
            JsonUtility.FromJsonOverwrite(JsonString, this);
        }

        public string SaveToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }//public class DataModel 

    //Класс CatalogObject служит для хранения справочных данных, примерно соответствующих простой таблице данных и неизменяемых в течении игровой сессии.
    //Чтение конкретных справочных данных происходит при Start().
    //Синхронизация клиента и сервера происходит в JSON, по HTTP, структура для транспорта и хранения - типизированный массив фиксированной величины
    [Serializable]
    public abstract class CatalogObject : DataModel
    {
        public string Code; // уникальный строковый код элемента справочника, может представляться как "1", "000001", "А"
        public string Description; //строковое наименование элемента на языке разработчика
    }//public class CatalogObject

    //Класс InformationRegisterRecord служит для хранения индивидуальной записи текущих данных, 
    //примерно соответствуя строке таблицы временной выборки в SQL, или значению в нереляционных базах данных. 
    //Такие данные сравнительно редко изменяются в течении игровой сессии
    //Синхронизация клиента и сервера происходит в JSON, по HTTP,структура для транспорта и хранения 
    //- типизированный массив фиксированной величины, с учетом задаваемого при старте количества объектов в пуле

    [Serializable]
    public abstract class InformationRegisterRecord : DataModel
    {
        public ushort Code;
    }//public class InformationRegisterRecord

    //Класс QueueRecord служит для хранения очередей индивидуальных записи текущих данных, 
    //примерно соответствуя одиночному синхронизирующему сообщению   
    //Такие данные могут очень часто изменяться в течении игровой сессии 

    [Serializable]
    public abstract class QueueRecord : DataModel
    {
        public ushort Code;
        public ulong DateMark;
    }//public class QueueRecord
}//namespace