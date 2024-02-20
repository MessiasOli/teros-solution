using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using System.Globalization;
using System.Net;
using TEROS.Api.Extensions;
using TEROS.Application.Interfaces;
using TEROS.Application.Validation;
using TEROS.Application.Worker;
using TEROS.DataAccess;
using TEROS.Domain.Interfaces;
using System.Text;
using TEROS.Domain.Services;

namespace TEROS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            #region Services
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        var corsOrigins = builder.Configuration["Cors:Origins"].Split(";");
                        var corsMethods = builder.Configuration["Cors:Methods"].Split(";");
                        policy.WithOrigins(corsOrigins)
                              .WithMethods(corsMethods)
                              .AllowAnyHeader();
                    });
            });

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddSingleton<OpenBankingObserver>();
            builder.Services.AddHostedService<OpenBankingObserver>(provider => provider.GetService<OpenBankingObserver>());
            builder.Services.AddSingleton<IOpenBankingService, OpenBankingService>();
            builder.Services.AddSingleton<ICalculateTimeService, CalculateTimeService>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(typeof(IMediatrAssemblyMarker).Assembly);
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<IDataContext, DataContext>(options =>
            {
                var passBase64 = builder.Configuration["Pass"];
                byte[] data = Convert.FromBase64String(passBase64);
                var password = Encoding.UTF8.GetString(data);

                var connectionString = builder.Configuration["ConnectionString"]?.Replace("[PASS]", password);
                options.UseNpgsql(connectionString);
            });

            #endregion

            var app = builder.Build();

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()?.Error;

                if (exception is ValidationException e)
                {
                    var response = new FluentValidationError(e.Errors);
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsJsonAsync(Result<IValidationError>.Failed(response.Message));
                }
            }));

            app.UseCors();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.ConfigureMinimalApiEndpoints();
            app.Run();
        }
    }
}