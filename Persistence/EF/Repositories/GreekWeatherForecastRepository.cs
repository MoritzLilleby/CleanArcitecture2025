using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Behaviours.Norse;
using Persistence.Creational;
using Persistence.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF.Repositories
{
    public interface IGreekWeatherForecastRepository
    {
        Task Create();
    }

    internal class GreekWeatherForecastRepository(IWeatherForecastContext context) : IGreekWeatherForecastRepository
    {
        private readonly DbSet<WeatherForecastEntity> _table = context.WeatherForcastEntities;

        public async Task Create()
        {
            var forcast = new WeatherForecastEntity();

            var factory = new GreekWeatherGodVisitorFactory();

            forcast.Accept(factory.CreateRandomWeatherGodVisitor());

            await _table.AddAsync(forcast);

            await context.SaveChangesAsync();
        }

    }
}
