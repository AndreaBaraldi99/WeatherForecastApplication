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
using WeatherForecast.Resources;
using WeatherForecastLib;

namespace WeatherForecast.ViewModels
{
    public partial class WeatherViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;  
        public List<Hourly> resultList { get { return ResultList; } set { SetProperty(ref ResultList, value); } }
        private List<Hourly> ResultList;
        public WeatherForecastResult result { get; set; }
        private Weather Weather;

        public string[] pickerSelection { get { return PickerSelection; } set { SetProperty(ref PickerSelection, value); }}
        private string[] PickerSelection;

        public WeatherViewModel()
        {
            result = new WeatherForecastResult();
            Weather = new Weather();
            ResultList = new List<Hourly>();
            PickerSelection = new string[] { new string(AppResources.LatitudeLongitude), new string(AppResources.LocationEntry) };
        }

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
            result.Daily.SetupWeatherIcon();
            resultList = result.Daily.Hourlies;
        }
    }
}
