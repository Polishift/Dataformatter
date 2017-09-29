using System.Collections.Generic;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public interface IModelFactory<out T> where T : IModel
    {
        T Create(List<string> csvRow); 
    }
}
