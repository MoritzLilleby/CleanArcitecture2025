using Persistence.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Creational
{
    internal class WeatherGodVisitorFactory : ICreateWeatherGodVisitor
    {
        private static readonly IWeatherGodVisitor[] greekGods = { new Boreas(), new Eurus(), new Notus(), new Zephyrus(), new Zeus() };
        private static readonly Random random = new();

        public IWeatherGodVisitor CreateWeatherGodVisitor()
        {
            var god = greekGods[random.Next(greekGods.Length)];
            return god;
        }
    }
}
