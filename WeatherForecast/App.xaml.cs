using WeatherForecast.Core;
using WeatherForecast.Repository;
using WeatherForecastRepositoryInterfaces;

namespace WeatherForecast;

public partial class App : Application
{
	public App()
	{
		string dbPath = $"Data Source=C:\\Users\\Andrea\\source\\repos\\AndreaBaraldi99\\WeatherForecastApplication\\WeatherForecast\\Database\\AppDB.db3;";

        UnitOfWork unitOfWork = new UnitOfWork(dbPath);
		DependencyService.RegisterSingleton<IUnitOfWork>(unitOfWork);

		WeatherRequestHandler weatherRequestHandler = new WeatherRequestHandler(unitOfWork);
		DependencyService.RegisterSingleton<WeatherRequestHandler>(weatherRequestHandler);
		InitializeComponent();

		MainPage = new AppShell();
	}
}
