using System.Text.Json.Serialization;

namespace WeatherForecastLib
{
    public class Data
    {
        [JsonPropertyName("data")]
        public List<Result> Results { get; set; }
    }
}