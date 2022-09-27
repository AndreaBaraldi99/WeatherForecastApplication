namespace WeatherForecastLib
{
    public class Hourly
    {
        public string Time { get; set; }
        public float Temperature2mMax { get; set; }      
        public float Temperature2mMin { get; set; }       
        public string Sunrise { get; set; }       
        public string Sunset { get; set; }
        public float PrecipitationSum { get; set; }        
        public float Windspeed10mMax { get; set; }
        public float Weathercode { get; set; }
        public string WeatherIcon { get; set; }

        public Hourly(string time, float temperature2mMax, float temperature2mMin, string sunrise, string sunset, float precipitationSum, float windspeed10mMax, float weathercode)
        {
            Time = time;
            Temperature2mMax = temperature2mMax;
            Temperature2mMin = temperature2mMin;
            Sunrise = sunrise;
            Sunset = sunset;
            PrecipitationSum = precipitationSum;
            Windspeed10mMax = windspeed10mMax;
            Weathercode = weathercode;
        }
    }
}
