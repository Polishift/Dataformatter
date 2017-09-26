using System.Collections.Generic;

namespace Dataformatter.Dataprocessing.Processers
{
    interface IDataProcesser<T>
    {
        void SerializeDataToJson(List<T> rawModels);
    }
}
