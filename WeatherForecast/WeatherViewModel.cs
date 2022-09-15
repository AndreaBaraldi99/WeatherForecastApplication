using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastLib;

namespace WeatherForecast
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Weather Weather = new Weather();
        WeatherForecastResult result = new WeatherForecastResult();
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
