using System.Collections.Generic;

namespace Dataformatter.Dataprocessing.Processors
{
    interface IDataProcessor<T>
    {
        void SerializeDataToJson(List<T> rawModels);
    }
}
