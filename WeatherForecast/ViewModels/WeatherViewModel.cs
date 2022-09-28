using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Core;
using WeatherForecast.DTO;
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
        public List<WeatherRequest> loglist { get { return Loglist; } set { SetProperty(ref Loglist, value); } }
        private List<WeatherRequest> Loglist;

        private WeatherRequestHandler _weatherRequestHandler;

        public WeatherViewModel()
        {
            result = new WeatherForecastResult();
            Weather = new Weather();
            ResultList = new List<Hourly>();
            PickerSelection = new string[] { new string(AppResources.LatitudeLongitude), new string(AppResources.LocationEntry) };
            _weatherRequestHandler = DependencyService.Get<WeatherRequestHandler>();
            loglist = new List<WeatherRequest>();
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
            var request = new WeatherRequest
            {
                Date = DateTime.UtcNow,
                Latitude = (float)latitude,
                Longitude = (float)longitude
            };
            if (_weatherRequestHandler.GetAllByLatLon(latitude, longitude) == null)
            {
                var id = SaveRequestInDb(request);
                result = Weather.GetForecast(latitude, longitude);
                populateList();
                request.Id = id;
                request.Data = result.ToJson();
                request.ResponseCode = result.ResponseCode;
                _weatherRequestHandler.Update(request);
            }
            else
            {
                result = JsonConvert.DeserializeObject<WeatherForecastResult>(_weatherRequestHandler.GetAllByLatLon(latitude, longitude).Data);
                populateList();
            }
            return;

        }
       
        public void getForecastResult(string location)
        {
            var request = new WeatherRequest
            {
                Date = DateTime.UtcNow,
                Location = location
            };
            if (_weatherRequestHandler.GetAllByLoc(location) == null)
            {
                var id = SaveRequestInDb(request);
                result = Weather.GetForecast(location);
                populateList();
                request.Id = id;
                request.Latitude = result.Latitude;
                request.Longitude = result.Longitude;
                request.Data = result.ToJson();
                request.ResponseCode = result.ResponseCode;
                _weatherRequestHandler.Update(request);
            }
            else
            {
                result = JsonConvert.DeserializeObject<WeatherForecastResult>(_weatherRequestHandler.GetAllByLoc(location).Data);
                populateList();
            }
            return;
        }

        public int SaveRequestInDb(WeatherRequest weatherRequest)
        {
            var lastIdx = _weatherRequestHandler.Add(weatherRequest);
            return lastIdx;
        }

        private void populateList()
        {
            result.Daily.SetupSunsetSunrise();
            result.Daily.SetupHourly();
            result.Daily.SetupWeatherIcon();
            resultList = result.Daily.Hourlies;
            return;
        }

        public void PopulateLogs(int days)
        {
            loglist = _weatherRequestHandler.GetAllByDays(days);
            return;
        }
    }
}
