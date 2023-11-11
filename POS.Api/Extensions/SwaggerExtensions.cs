using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
namespace POS.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "POS API",
                Version = "v1",
                Description = "Point of sale API 2023",
                TermsOfService = new Uri("https://opensource.org/licences/NIT"),
                
                Contact = new OpenApiContact
                {
                    Name = "Alex Meregildo",
                    Email = "alexmeco@gmail.com",
                    Url = new Uri("https://opensource.org/licences/NIT")
                },
                License = new OpenApiLicense
                {
                    Name = "Use under LICX",
                    Url = new Uri("https://opensource.org/licences/NIT")
                }
            };
            
            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);

                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Jwt Authentication",
                    Description = "Jwt Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "Jwt",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                
                x.AddSecurityDefinition(securitySchema.Reference.Id, securitySchema);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new string[]{}}
                });
            });

            return services;
        }
    }
}
