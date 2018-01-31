using System.Collections.Generic;

namespace Dataformatter.Data_accessing.Repositories
{
    public abstract class AbstractRepository<T>
    {
        public abstract T[] GetAll();
        public abstract T[] GetByCountry(string countryCode); //Make a Country class 

        protected T[] GetFromDictionarySafely(string key, Dictionary<string, T[]> entityDictionary)
        {
            if (entityDictionary.ContainsKey(key))
                return entityDictionary[key];
            else
                return new T[0];
        }
    }
}