using System.Data.SQLite;
using WeatherForecast.RepositoryInterfaces;
using WeatherForecastRepositoryInterfaces;

namespace WeatherForecast.Repository
{
    public class UnitOfWork  : IUnitOfWork
    {
        private SQLiteConnection _connection;
        private SQLiteTransaction _transaction;
        private IWeatherRequestRepository _weatherRequestRepository;

        private bool _disposed;       

        public UnitOfWork(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();        
            _transaction = _connection.BeginTransaction();
        }

        public IWeatherRequestRepository WeatherRequestRepository
        {
            get
            {
                return _weatherRequestRepository ?? (_weatherRequestRepository = new WeatherRequestRepository(_transaction));
            }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                resetRepositories();
                _transaction = _connection.BeginTransaction();
            }
        }
        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }
        private void resetRepositories()
        {
            _weatherRequestRepository = null;           
        }
        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }
        ~UnitOfWork()
        {
            dispose(false);
        }

    }
}
