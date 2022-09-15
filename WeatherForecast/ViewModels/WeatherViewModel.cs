using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastLib;

namespace WeatherForecast.ViewModels
{
    public partial class WeatherViewModel : ObservableObject
    {
        private Weather Weather;

        [ObservableProperty]
        //public ObservableCollection<string> observableTime;
        public ObservableCollection<object> resultList;

        public WeatherForecastResult result { get; set; }

        public WeatherViewModel()
        {
            result = new WeatherForecastResult();
            Weather = new Weather();
            resultList = new ObservableCollection<object>();
            //observableTime = new ObservableCollection<string>();
        }
        public void getForecastResult(double latitude, double longitude)
        {
            result = Weather.GetForecast(latitude, longitude);
            populateList();
            //observableTime = result.Daily.Time.ToObservableCollection<string>();
        }

        public void getForecastResult(string location)
        {
            result = Weather.GetForecast(location);
            populateList();
            //observableTime = result.Daily.Time.ToObservableCollection<string>();
        }

        private void populateList()
        {
            resultList.Add(result.Daily.Time);
            resultList.Add(result.Daily.Temperature2mMax);
            resultList.Add(result.Daily.Temperature2mMin);
            resultList.Add(result.Daily.Sunrise);
            resultList.Add(result.Daily.Sunset);
            resultList.Add(result.Daily.PrecipitationSum);
            resultList.Add(result.Daily.Windspeed10mMax);
            resultList.Add(result.Daily.Weathercode);
        }
    }
}
