using System.Collections.Generic;

namespace Dataformatter.Data_accessing.Factories
{
    public interface IModelFactory<T>
    {
        T Create(List<string> csvRow); 
    }
}
