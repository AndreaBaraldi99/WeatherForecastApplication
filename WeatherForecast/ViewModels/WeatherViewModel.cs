using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastLib;

namespace WeatherForecast.ViewModels
{
    public partial class WeatherViewModel : INotifyPropertyChanged
    {
        private Weather Weather;      
        public List<Hourly> resultList { get { return ResultList; } set { SetProperty(ref ResultList, value); } }
        private List<Hourly> ResultList;
        public WeatherForecastResult result { get; set; }

        public WeatherViewModel()
        {
            result = new WeatherForecastResult();
            Weather = new Weather();
            ResultList = new List<Hourly>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if(changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if(EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
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
            result.Daily.SetupSunsetSunrise();
            result.Daily.SetupHourly();
            result.Daily.SetupColor();
            resultList = result.Daily.Hourlies;
            //resultList.OrderByDescending(e=>e.Temperature2mMax).FirstOrDefault().MaxTemp = System.Drawing.Color.Magenta ;
        }
    }
}
