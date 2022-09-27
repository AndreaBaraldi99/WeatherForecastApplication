﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastRepositoryInterfaces
{
    internal interface IUnitOfWork
    {
        IWeatherRequestRepository WeatherRequestRepository { get; }
        void Commit();
        void Dispose();
    }
}