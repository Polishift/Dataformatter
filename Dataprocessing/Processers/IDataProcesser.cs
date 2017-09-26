using System.Collections.Generic;

namespace Dataformatter.Dataprocessing.Processers
{
    interface IDataProcesser<T>
    {
        void SerializeDataToJSON(List<T> rawModels);
    }
}
