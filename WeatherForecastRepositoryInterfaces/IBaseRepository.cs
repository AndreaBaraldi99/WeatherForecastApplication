namespace WeatherForecastRepositoryInterfaces
{
    public interface IBaseRepository<T>
    {
        T Get(int id);
        int Add(T entry);
        void Update(T entry);
        void Delete(int id);
    }
}
