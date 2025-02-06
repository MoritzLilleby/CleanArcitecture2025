using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours
{
    internal abstract class Anemoi : IWeatherVisitor
    {
        public abstract void Visit(WeatherForcastEntity weatherForecast);
    }

}
