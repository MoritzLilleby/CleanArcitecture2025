﻿using Application.Contracts;
using Asp.Versioning;
using CleanArchitecture.Rabbit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contracts;
using Persistence.Dapper.Repositories.Interfaces;

namespace CleanArcitecture2025.Server.Controllers.@public
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v2.0/weatherforecast")]
    public class WeatherForecastV2Controller : ControllerBase
    {

        private readonly IWeatherForecastRepository _repository;
        private readonly Sender rabbitSenderProgram;

        public WeatherForecastV2Controller(
            IDPWeatherForecastRepository repository,
            Sender rabbitSenderProgram
            )
        {
            _repository = repository;
            this.rabbitSenderProgram=rabbitSenderProgram;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> GetAll()
        {
            await this.rabbitSenderProgram.Send("WeatherForecastV2Controller.GetAll", "hello");
            var forecasts = await _repository.GetAll();
            return Ok(forecasts);
        }

    }
}
