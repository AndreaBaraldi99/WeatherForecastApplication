using WeatherForecast.DTO;

namespace WeatherForecastRepositoryInterfaces
{
    public interface IWeatherRequestRepository : IBaseRepository<WeatherRequest>
    {
        IEnumerable<WeatherRequest> GetAllByLatLon(double latitude, double longitude);
        IEnumerable<WeatherRequest> GetAllByLoc(string location);
        IEnumerable<WeatherRequest> GetAllByDays(DateTime date);
    }
}