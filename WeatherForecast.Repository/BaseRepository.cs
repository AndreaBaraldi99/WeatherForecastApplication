using Dapper;
using System.Data;
using System.Reflection.Metadata;

namespace WeatherForecast.Repository
{
    public abstract class BaseRepository
    {
        private IDbConnection Connection { get { return _transaction.Connection; } }
        private readonly IDbTransaction _transaction;

        public BaseRepository(IDbTransaction transaction)
        {
            _transaction = transaction;

            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
            SqlMapper.AddTypeHandler(new GuidHandler());
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        protected T ExecuteScalar<T>(string sql, object param)
        {
            return Connection.ExecuteScalar<T>(sql, param, _transaction);
        }

        protected T QuerySingleOrDefault<T>(string sql, object param)
        {
            return Connection.QuerySingleOrDefault<T>(sql, param, _transaction);
        }
        protected IEnumerable<dynamic> Query(string sql, object param = null)
        {
            return Connection.Query(sql, param, _transaction);
        }

        protected IEnumerable<T> Query<T>(string sql, object param = null)
        {
            return Connection.Query<T>(sql, param, _transaction);
        }

        protected IEnumerable<T3> Query<T1, T2, T3>(string sql, Func<T3, T2, T3> map, object param = null, string splitOn = "Id")
        {
            return Connection.Query(sql, map, param, _transaction, true, splitOn, null, null);
        }

        protected IEnumerable<T4> Query<T1, T2, T3, T4>(string sql, Func<T4, T2, T3, T4> map, object param = null, string splitOn = "Id")
        {
            return Connection.Query(sql, map, param, _transaction, true, splitOn, null, null);
        }

        protected IEnumerable<T5> Query<T1, T2, T3, T4, T5>(string sql, Func<T5, T2, T3, T4, T5> map, object param = null, string splitOn = "Id")
        {
            return Connection.Query(sql, map, param, _transaction, true, splitOn, null, null);
        }

        protected IEnumerable<T6> Query<T1, T2, T3, T4, T5, T6>(string sql, Func<T6, T2, T3, T4, T5, T6> map, object param = null, string splitOn = "Id")
        {
            return Connection.Query(sql, map, param, _transaction, true, splitOn, null, null);
        }

        protected IEnumerable<T7> Query<T1, T2, T3, T4, T5, T6, T7>(string sql, Func<T7, T2, T3, T4, T5, T6, T7> map, object param = null, string splitOn = "Id")
        {
            return Connection.Query(sql, map, param, _transaction, true, splitOn, null, null);
        }

        protected IEnumerable<T8> Query<T1, T2, T3, T4, T5, T6, T7, T8>(string sql, Func<T8, T2, T3, T4, T5, T6, T7, T8> map, object param = null, string splitOn = "Id")
        {
            return Connection.Query(sql, map, param, _transaction, true, splitOn, null, null);
        }

        protected void Execute(string sql, object param)
        {
            Connection.Execute(sql, param, _transaction);
        }
    }

    abstract class SqliteTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        // Parameters are converted by Microsoft.Data.Sqlite
        public override void SetValue(IDbDataParameter parameter, T value)
            => parameter.Value = value;
    }

    class DateTimeOffsetHandler : SqliteTypeHandler<DateTimeOffset>
    {
        public override DateTimeOffset Parse(object value)
            => DateTimeOffset.Parse((string)value);
    }

    class GuidHandler : SqliteTypeHandler<Guid>
    {
        public override Guid Parse(object value)
            => Guid.Parse((string)value);
    }

    class TimeSpanHandler : SqliteTypeHandler<TimeSpan>
    {
        public override TimeSpan Parse(object value)
            => TimeSpan.Parse((string)value);
    }



}