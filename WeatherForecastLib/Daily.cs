using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WeatherForecastLib
{
    public class Daily : ObservableObject
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<float> Temperature2mMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<float> Temperature2mMin { get; set; }

        [JsonPropertyName("sunrise")]
        public List<string> Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public List<string> Sunset { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public List<float> PrecipitationSum { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public List<float> Windspeed10mMax { get; set; }

        [JsonPropertyName("weathercode")]
        public List<float> Weathercode { get; set; }

       
    }
}