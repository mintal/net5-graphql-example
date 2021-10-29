using System;
using System.Threading.Tasks;
using GraphQLTutorial.GraphQL;
using GraphQLTutorial.GraphQL.Resolvers;
using GraphQLTutorial.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GraphQLTutorial
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //with Query class
            services.AddGraphQLServer() //adds the graphql service
                .AddQueryType<Query>() //adds the query class
                .AddType<WeatherForecastResolvers>()
                .AddFiltering(); //extends the query class with WeatherForecastResolvers

            //without Query class
            /*services.AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                .AddType<WeatherForecastResolvers>();*/

            services.AddScoped<WeatherForecastService>(); 
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLTutorial", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLTutorial v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL(); //maps the correct endpoints for graphql
                endpoints.MapControllers();
            });
        }
    }
}