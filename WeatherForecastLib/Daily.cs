using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Graphics;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Text.Json.Serialization;
using Color = Microsoft.Maui.Graphics.Color;

namespace WeatherForecastLib
{
    public class Daily : ObservableObject
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<float> MaxTemperature { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<float> MinTemperature { get; set; }

        [JsonPropertyName("sunrise")]
        public List<string> Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public List<string> Sunset { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public List<float> PrecipitationSum { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public List<float> MaxWindspeed { get; set; }

        [JsonPropertyName("weathercode")]
        public List<float> Weathercode { get; set; }
        public List<Hourly> Hourlies { get; set; }

        public void SetupSunsetSunrise()
        {
            for(int i = 0; i < Sunrise.Count; i++)
            {
                Sunrise[i] = Sunrise[i].Substring(Sunrise[i].IndexOf("T")+1);
                Sunset[i] = Sunset[i].Substring(Sunset[i].IndexOf("T")+1);
            }
        }

        public void SetupHourly()
        {
            Hourlies = new List<Hourly>();
            for(int i = 0; i < Time.Count; i++)
            {
                Hourlies.Add(new Hourly(Time[i], MaxTemperature[i], MinTemperature[i], Sunrise[i], Sunset[i], PrecipitationSum[i], MaxWindspeed[i], Weathercode[i]));
            }            
        }

        public void SetupWeatherIcon()
        {
            foreach(var hourly in Hourlies)
            {
                hourly.WeatherIcon = hourly.Weathercode switch
                {
                    0 => "☀️",
                    1 or 2 => "🌤️",
                    3 => "☁️",
                    45 or 48 => "🌫️",
                    51 or 53 or 55 or 56 or 57 => "🌦️",
                    61 or 63 or 65 or 66 or 67 or 80 or 81 or 82 => "🌧️",
                    71 or 73 or 75 or 77 or 85 or 86 => "❄️",
                    95 or 96 or 99 => "🌩️",
                    _ => "No info",
                };
            }
        }
    }
}