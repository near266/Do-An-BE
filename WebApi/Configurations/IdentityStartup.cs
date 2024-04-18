using Azure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson.IO;
using System;
using System.Text;
using WebApi.Application.AutoMapper;
using WebApi.Infrastructure;


using WebApi.Modules.User.Domain.Entites;
using WebApi.Wrappers.AutoMapper;


namespace WebApi.Configurations
{
    public static class IdentityStartup
    {
        public static IServiceCollection AddIdentityJwt(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddIdentity<UserIdentity, IdentityRole>()
         .AddEntityFrameworkStores<UserDbContext>()
         .AddSignInManager<SignInManager<UserIdentity>>()
         .AddRoles<IdentityRole>()
         ;

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JWTSettings:Issuer"],
                        ValidAudience = configuration["JWTSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                    };
                    o.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();
                            c.Response.StatusCode = 500;
                            c.Response.ContentType = "text/plain";
                            return c.Response.WriteAsync(c.Exception.ToString());
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = Newtonsoft.Json.JsonConvert.SerializeObject(new Wrappers.Response<string>("You are not Authorized"));
                            return context.Response.WriteAsync(result);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            var result = Newtonsoft.Json.JsonConvert.SerializeObject(new Wrappers.Response<string>("You are not authorized to access this resource"));
                            return context.Response.WriteAsync(result);
                        },
                    };
                });
            return services;
        }
    }
}
