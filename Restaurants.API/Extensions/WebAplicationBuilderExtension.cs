using Microsoft.OpenApi.Models;
using Restaurants.API.Middlewares;
using Serilog;
using System.Text.Json.Serialization;

namespace Restaurants.API.Extensions
{
    public static class WebAplicationBuilderExtension
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddSwaggerGen(cfg =>
            {
                cfg.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "BearerAuth"}
                },
                []
                }
                });
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<RequestTimeMiddleware>();
            builder.Host.UseSerilog((context, cfg) =>
            {
                cfg.ReadFrom.Configuration(context.Configuration);
            });
        }
    }
}
