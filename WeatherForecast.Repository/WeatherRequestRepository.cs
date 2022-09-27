using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.DTO;
using WeatherForecastRepositoryInterfaces;

namespace WeatherForecast.Repository
{
    internal class WeatherRequestRepository : BaseRepository, IWeatherRequestRepository
    {
        public WeatherRequestRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        public void Add(WeatherRequest entry)
        {
            Execute(
                sql: "INSERT INTO WeatherRequest (Date, Latitude, Longitude, Location, ResponseCode, Data) VALUES @Date, @Latitude, @Longitude, @Location, @ResponseCode, @Data",
                param: new { entry.Date, entry.Latitude, entry.Longitude, entry.Location, entry.ResponseCode, entry.Data });
            return;
        }

        public void Delete(int id)
        {
            Execute(
                sql: "DELETE FROM WeatherRequest WHERE id=@id",
                param: new { id });
        }

        public WeatherRequest Get(int id)
        {
            var result = Query<WeatherRequest>(
                sql: "SELECT * FROM WeatherRequest WHERE id=@id", 
                param: new {id}).FirstOrDefault();
            return result;
        }

        public void Update(WeatherRequest entry)
        {
           Execute(
               sql: "UPDATE WeatherRequest SET Date=@Date, Latitude=@Latitude, Longitude=@Longitude, Location=@Location, ResponseCode=@ResponseCode, Data=@Data WHERE id=@Id",
               param: new {entry.Date, entry.Latitude, entry.Longitude, entry.Location, entry.ResponseCode, entry.Data, entry.Id});
            return;
        }
    }
}
