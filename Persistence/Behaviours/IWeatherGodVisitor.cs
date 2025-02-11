using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours
{
    internal interface IWeatherGodVisitor
    {
        public void Visit(WeatherForecastEntity weatherForecast);
    }
}
