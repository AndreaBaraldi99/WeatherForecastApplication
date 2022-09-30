using WeatherForecastRepositoryInterfaces;

namespace WeatherForecast.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        IWeatherRequestRepository WeatherRequestRepository { get; }
        void Commit();
        void Dispose();
    }
}
