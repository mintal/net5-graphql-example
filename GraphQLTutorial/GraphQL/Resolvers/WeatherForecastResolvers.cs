using System.Collections.Generic;
using System.Linq;
using GraphQLTutorial.Models;
using GraphQLTutorial.Services;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

namespace GraphQLTutorial.GraphQL.Resolvers
{
    [ExtendObjectType(Name = "Query")]
    public class WeatherForecastResolvers
    {
        public WeatherForecast GetFirstWeatherForecast([Service] WeatherForecastService service) => service.Get().First();

        [UseFiltering]
        public IEnumerable<WeatherForecast> GetWeatherForecasts([Service] WeatherForecastService service) =>
            service.Get();
    }
}