using Core.Utilities.Security.Encrypting;
using Core.Utilities.Security.JWT;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using RentaCar.BusinessLogic;
using RentaCar.DataAccessLayer;
namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            TokenOption tokenOption = builder.Configuration.GetSection("TokenOptions").Get<TokenOption>();

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(op =>
            op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            builder.Services.AddDataAccessServices(builder.Configuration);
            builder.Services.AddBusinessService();
            builder.Services.AddFluentValidationAutoValidation(x => x.DisableDataAnnotationsValidation = true)
                .AddFluentValidationClientsideAdapters();

            builder.Services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer=tokenOption.Issuer,
                    ValidAudience=tokenOption.Audience,
                    IssuerSigningKey=SecurityKeyHelper.CreateSecurityKey(tokenOption.SecurityKey)
                };
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}