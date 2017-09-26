using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories
{
    abstract class AbstractElectionEntityFactory
    {
        public abstract ElectionEntity Create(ConstituencyElectionModel rawModel);
    }
}
