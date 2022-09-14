using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastLib
{
    public class Weather
    {
        private const string _apiRootWeather = "https://api.open-meteo.com/v1/forecast?";
        private const string _forecastParams = "daily=weathercode,temperature_2m_max,temperature_2m_min,sunrise,sunset,precipitation_sum,windspeed_10m_max&timezone=auto";
        private const string _apiRootLocation = "http://api.positionstack.com/v1/forward?limit=1&access_key=d77ed0d76be5d6b096a219da1e7d8767";
        private API _api;

        public Weather()
        {
            _api = new API();

        }

        public WeatherForecastResult GetForecast(float latitude, float longitude)
        {
            string url = _apiRootWeather + _forecastParams + "&latitude=" + latitude.ToString("0.0", CultureInfo.InvariantCulture) + "&longitude=" + longitude.ToString("0.0", CultureInfo.InvariantCulture);
            var response = _api.CallAPI(url);
            if (response == null)
            {
                Console.WriteLine("Null API response");
                return null;
            }
                
            else if ((int)response.StatusCode != 200)
            {
                Error error = response.Content.ReadFromJsonAsync<Error>().Result;
                Debug.WriteLine($"Error. Reason: {error.reason}");
                return null;
            }
            WeatherForecastResult forecastResult = new WeatherForecastResult();
            forecastResult = response.Content.ReadFromJsonAsync<WeatherForecastResult>().Result;
            return forecastResult;
        }

        public WeatherForecastResult GetForecast(String city)
        {

            String url = _apiRootLocation + "&query=" + city;

            var response = _api.CallAPI(url);
            if (response == null)
            {
                return null;
            }
            else if ((int)response.StatusCode != 200)
            {
                Console.WriteLine("Connection failed");
                return null;
            }

            Data location = new Data();
            location = response.Content.ReadFromJsonAsync<Data>().Result;
		
		    return GetForecast((float)location.Results.First<Result>().Latitude, (float)location.Results.First<Result>().Longitude);
	    	
	    
	}






}
}
