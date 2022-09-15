using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastLib;

namespace WeatherForecast.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Weather Weather;
        public WeatherForecastResult result { get; set; }
        public string name { get; set; }

        public WeatherViewModel()
        {
            name = "ciao";
            result = new WeatherForecastResult();
            Weather = new Weather();
        }
        public void getForecastResult(double latitude, double longitude)
        {
            result = Weather.GetForecast(latitude, longitude);
        }

        public void getForecastResult(string location)
        {
            result = Weather.GetForecast(location);
        }
    }
}
