using WeatherForecast.Core;
using WeatherForecast.ViewModels;
namespace WeatherForecast;

public partial class MainPage : ContentPage
{
	WeatherViewModel _viewModel;
	private WeatherRequestHandler _weatherRequestHandler;

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
		ResultBorder.IsVisible = true;
	}

	private void DaysEntry_Completed(object sender, EventArgs e)
	{
		if (DaysEntry.Text != string.Empty && DaysEntry.Text != null)
		{
            _viewModel.PopulateLogs(int.Parse(DaysEntry.Text));
            LogsList.IsEnabled = true;
			LogsList.IsVisible = true;
			LogsBorder.IsVisible = true;
        }
		else
			return;
	}
}

