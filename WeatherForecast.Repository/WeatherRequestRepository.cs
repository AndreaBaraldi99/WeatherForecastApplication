using System.Data;
using WeatherForecast.DTO;
using WeatherForecastRepositoryInterfaces;

namespace WeatherForecast.Repository
{
    public class WeatherRequestRepository : BaseRepository, IWeatherRequestRepository
    {
        public WeatherRequestRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public int Add(WeatherRequest entry)
        {
            var result=ExecuteScalar<int>(
                sql: "INSERT INTO WeatherRequests (Date, Latitude, Longitude, Location, ResponseCode, Data) VALUES (@Date, @Latitude, @Longitude, @Location, @ResponseCode, @Data); SELECT last_insert_rowid()",
                param: new { entry.Date, entry.Latitude, entry.Longitude, entry.Location, entry.ResponseCode, entry.Data });
            return result;
        }

        public void Delete(int id)
        {
            Execute(
                sql: "DELETE FROM WeatherRequests WHERE id=@id",
                param: new { id });
        }

        public WeatherRequest Get(int id)
        {
            var result = Query<WeatherRequest>(
                sql: "SELECT * FROM WeatherRequests WHERE id=@id", 
                param: new {id}).FirstOrDefault();
            return result;
        }

        public IEnumerable<WeatherRequest> GetAllByLatLon(double latitude, double longitude)
        {
            var result = Query<WeatherRequest>(
                sql: "SELECT * FROM WeatherRequests WHERE Latitude=@Latitude AND Longitude=@Longitude",
                param: new { latitude, longitude});
            return result;
        }

        public IEnumerable<WeatherRequest> GetAllByLoc(string location)
        {
            var result = Query<WeatherRequest>(
                sql: "SELECT * FROM WeatherRequests WHERE Location=@Location",
                param: new { location });
            return result;
        }
        public IEnumerable<WeatherRequest> GetAllByDays(DateTime date)
        {
            var result = Query<WeatherRequest>(
                sql: "SELECT * FROM WeatherRequests WHERE Date>@date",
                param: new { date });
            return result;
        }

        public void Update(WeatherRequest entry)
        {
           Execute(
               sql: "UPDATE WeatherRequests SET Latitude=@Latitude, Longitude=@Longitude, Location=@Location, ResponseCode=@ResponseCode, Data=@Data WHERE id=@Id",
               param: new {entry.Latitude, entry.Longitude, entry.Location, entry.ResponseCode, entry.Data, entry.Id});
            return;
        }
    }
}
