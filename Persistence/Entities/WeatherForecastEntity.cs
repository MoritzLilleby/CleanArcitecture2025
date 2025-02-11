using Persistence.Behaviours;
using Persistence.Behaviours.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    internal class WeatherForecastEntity
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
        

        public void Accept(IWeatherGodVisitor visitor)
        {
            visitor.Visit(this);
        }
    
    }
}
