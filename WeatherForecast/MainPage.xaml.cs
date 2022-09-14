using System.Diagnostics;
using WeatherForecastLib;
namespace WeatherForecast;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
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
            //SemanticScreenReader.Announce(latLonPanel.IsVisible);
        }
		else if(selectedIndex == 1)
		{
			latLonPanel.IsVisible = false;
			locationPanel.IsVisible = true;
            searchButton.IsVisible = true;
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

	}
}

