using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours
{
    internal class Zeus : IWeatherGodVisitor
    {
        public void Visit(WeatherForecastEntity weatherForcast)
        {
            Console.WriteLine($"Zeus is visiting {weatherForcast.Summary} weather on {weatherForcast.Date}.");

            weatherForcast.Summary = "Thunderstorm";
            weatherForcast.TemperatureC = 30;
            weatherForcast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }
}
