using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Behaviours.Norse;
using Persistence.Creational;
using Persistence.EF.Entities;
using System;
using System.Collections.Generic;

namespace Persistence.EF.Repositories
{
    public interface INorseWeatherForecastRepository
    {
        Task Create();
    }

    internal class NorseWeatherForecastRepository(IWeatherForecastContext context) : INorseWeatherForecastRepository
    {
        private readonly DbSet<WeatherForecastEntity> _table = context.WeatherForcastEntities;

        public async Task Create()
        {
            var forcast = new WeatherForecastEntity();

            var factory = new GreekWeatherGodVisitorFactory();

            var norseGod = factory.CreateRandomWeatherGodVisitor();

            forcast.Accept(norseGod);

            var theAllFather = new Odin();
            var ravens = theAllFather.CallRavens();
            ravens.Observe(norseGod);

            await _table.AddAsync(forcast);

            await context.SaveChangesAsync();
        }

    }
}
