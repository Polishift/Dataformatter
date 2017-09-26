namespace Dataformatter.Data_accessing.Repositories
{
    interface IRepository<T>
    {
        T[] GetAll();
        T[] GetByYear(int year);
        T[] GetByCountry(string countryCode); //Make a Country class 
    }
} 
