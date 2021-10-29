using System;
using HotChocolate;

namespace GraphQLTutorial.Models
{
    
    public class WeatherForecast
    {
        [GraphQLDescription("The current date of the WeatherForecast")]
        public DateTime Date { get; set; }

        [GraphQLName("Celsius")]
        public int TemperatureC { get; set; }

        [GraphQLDeprecated("Nobody uses fahrenheit anymore")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        
        [GraphQLIgnore]
        public int Day => Date.Day;

        public string Summary { get; set; }
    }
}