using Persistence.Entities;

namespace Persistence.Behaviours
{
    internal interface IAnemoi
    {
        void Visit(WeatherForecastEntity weatherForecast);
    }
}