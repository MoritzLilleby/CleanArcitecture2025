using Persistence.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    internal class WeatherForcastEntity
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public void Accept(IWeatherVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
