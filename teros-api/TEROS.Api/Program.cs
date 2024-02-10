
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Net;
using TEROS.Api.Extensions;
using TEROS.Application.Interfaces;
using TEROS.Application.Validation;
using TEROS.Domain.Interfaces;

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

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(typeof(IMediatrAssemblyMarker).Assembly);
            builder.Services.AddEndpointsApiExplorer();

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