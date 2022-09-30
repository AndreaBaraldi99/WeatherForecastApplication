using WeatherForecast.DTO;
using WeatherForecast.RepositoryInterfaces;

namespace WeatherForecast.Core
{
    public class WeatherRequestHandler
    {
        readonly IUnitOfWork _repository;

        public WeatherRequestHandler(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public WeatherRequest GetById(int id)
        {
            return _repository.WeatherRequestRepository.Get(id);            
        }
        public WeatherRequest? GetAllByLatLon(double latitude, double longitude)
        {
            var result = _repository.WeatherRequestRepository.GetAllByLatLon(latitude, longitude);
            return result.Where(x => x.Date.Date == DateTime.UtcNow.Date).FirstOrDefault();
        }

        public WeatherRequest? GetAllByLoc(string location)
        {
            var result = _repository.WeatherRequestRepository.GetAllByLoc(location);
            return result.Where(x => x.Date.Date == DateTime.UtcNow.Date).FirstOrDefault();
        }

        public List<WeatherRequest> GetAllByDays(int days)
        {
            DateTime date = DateTime.UtcNow.AddDays(-days);
            var result = _repository.WeatherRequestRepository.GetAllByDays(date).ToList();
            return result;
        }

        public int Add(WeatherRequest weatherRequest)
        {
            var result = _repository.WeatherRequestRepository.Add(weatherRequest);
            _repository.Commit();
            return result;
        }

        public void Update(WeatherRequest weatherRequest)
        {
            _repository.WeatherRequestRepository.Update(weatherRequest);
            _repository.Commit();
        }
    }
}