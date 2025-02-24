using Application.Contracts;
using Dapper;
using Persistence.Dapper.Repositories.Interfaces;

namespace Persistence.Dapper.Repositories
{
    public class WeatherForecastRepository : IDPWeatherForecastRepository
    {
        private readonly IDapperContext _context;

        public WeatherForecastRepository(IDapperContext context)
        {
            _context = context;
        }

        public Task Create()
        {
            throw new NotImplementedException();
        }

        public async Task<List<WeatherForecast>> GetAll()
        {
            var query = "SELECT * FROM WeatherForCast";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<WeatherForecast>(query);
                return result.ToList();
            }
        }
    }
}
