using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Markup;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WeatherForecast.ViewModels;
using WeatherForecastLib;
namespace WeatherForecast;

public partial class MainPage : ContentPage
{
	int count = 0;
	string latitude = "";
	string longitude = "";
	string location = "";
	WeatherViewModel _viewModel;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = new WeatherViewModel();
    }
	//SemanticScreenReader.Announce(CounterBtn.Text);

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 0)
        {
			latLonPanel.IsVisible = true;
			locationPanel.IsVisible = false;
			searchButton.IsVisible = true;
			searchButton.IsEnabled = true;
            //SemanticScreenReader.Announce(latLonPanel.IsVisible);
        }
		else if(selectedIndex == 1)
		{
			latLonPanel.IsVisible = false;
			locationPanel.IsVisible = true;
            searchButton.IsVisible = true;
			searchButton.IsEnabled = true;
        }
    }

	void OnTextChanged(object sender, EventArgs e)
	{

	}

	void OnTextCompleted(object sender, EventArgs e)
	{

	}

	private void OnButtonClicked(object sender, EventArgs e)
	{
        Button b = (Button)sender;
        Dispatcher.DispatchDelayed(TimeSpan.FromMilliseconds(100), () =>
        {
            VisualStateManager.GoToState(b, "NotPressed");
        });
    }

	private void OnSearchButtonPressed(object sender, EventArgs e)
	{
		searchButton.IsEnabled = false;
		if (weatherModePicker.SelectedIndex == 0)
		{
			_viewModel.getForecastResult(Convert.ToDouble(latitudeEntry.Text), Convert.ToDouble(longitudeEntry.Text));
		}
		else if (weatherModePicker.SelectedIndex == 1)
		{
			_viewModel.getForecastResult(locationEntry.Text);
		}

		TimeList.IsEnabled = true;
		TimeList.IsVisible = true;
		searchButton.IsEnabled = true;
	}
		


}

