namespace Dataformatter.Data_accessing.Repositories
{
    public interface IRepository<out T>
    {
        T[] GetAll();
        T[] GetByCountry(string countryCode); //Make a Country class 
    }
} 
