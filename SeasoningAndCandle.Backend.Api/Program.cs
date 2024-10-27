using DataAbstractions.Dapper;
using EmployeesAPI2.Application.Services;
using SeasoningAndCandle.Backend.Application.Commands;
using SeasoningAndCandle.Backend.Application.Services.Interfaces;
using SeasoningAndCandle.Backend.Domain.Interfaces;
using SeasoningAndCandle.Backend.Infrastructure.DbProvider;
using SeasoningAndCandle.Backend.Infrastructure.Mappers;
using SeasoningAndCandle.Backend.Infrastructure.Mappers.Interfaces;
using SeasoningAndCandle.Backend.Infrastructure.Repository;
using System.Data.SqlClient;

namespace SeasoningAndCandle.Backend.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuramos la politica de CORS
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Configure MediatR
            builder.Services.AddMediatR(option => option.RegisterServicesFromAssemblies(typeof(RegisterCommand).Assembly));

            builder.Services.AddControllers();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //* Injecting dependencies
            _ = builder.Services.AddSingleton<IDbProvider, DbProvider>(service => new DbProvider(builder.Configuration.GetConnectionString("SeasoningAndCandleDb") ?? ""));
            _ = builder.Services.AddSingleton<IUserRepository, UserRepository>();
            _ = builder.Services.AddSingleton<IAuthentificationService, AuthentificationService>();
            _ = builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            _ = builder.Services.AddSingleton<IProductMapper, ProductMapper>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
