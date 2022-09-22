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
        public string titleNames;

        [ObservableProperty]
        public ObservableCollection<object> resultList;

        public WeatherForecastResult result { get; set; }

        public WeatherViewModel()
        {
            result = new WeatherForecastResult();
            Weather = new Weather();
            resultList = new ObservableCollection<object>();
            titleNames = string.Empty;
           
        }
        public void getForecastResult(double latitude, double longitude)
        {
            result = Weather.GetForecast(latitude, longitude);
            populateList();         
        }

        public void getForecastResult(string location)
        {
            result = Weather.GetForecast(location);
            populateList();
        }

        private void populateList()
        {
            
            foreach(var item in result.Daily.GetType().GetProperties())
            {
                resultList.Add(item.GetValue(result.Daily, null));
                titleNames+=item.Name+" ";
            }
           
        }
    }
}
