using System.Collections.Generic;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories
{
    public interface IModelFactory<T> where T : IModel
    {
        T Create(List<string> csvRow); 
    }
}
