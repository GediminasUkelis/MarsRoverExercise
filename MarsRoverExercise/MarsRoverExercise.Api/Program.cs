using MarsRoverExercise.API.Infrastructure.Middleware;
using MarsRoverExercise.API.Infrastructure.Validations;
using MarsRoverExercise.Application.Models;
using MarsRoverExercise.Application.Repositories;
using MarsRoverExercise.Application.Services;

namespace MarsRoverExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IRoverMovementService, RoverMovementService>();
            builder.Services.AddScoped<IRoverRepository, RoverRepository>();
            builder.Services.AddScoped<InputValidator>();

            builder.Services.Configure<MapSize>(builder.Configuration.GetSection("MapSize"));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandling>();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
