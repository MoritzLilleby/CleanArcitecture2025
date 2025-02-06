using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Behaviours
{
    internal class Eurus : Anemoi
    {
        public override void Visit(WeatherForcastEntity weatherForecast)
        {
            Console.WriteLine($"Eurus is visiting {weatherForecast.Summary} weather on {weatherForecast.Date}.");

            weatherForecast.Summary = "Stormy Wind";
            weatherForecast.TemperatureC -= 5;
            weatherForecast.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        }
    }

}
