using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastRepositoryInterfaces
{
    public interface IBaseRepository<T>
    {
        T Get(int id);
        void Add(T entry);
        void Update(T entry);
        void Delete(int id);
    }
}
