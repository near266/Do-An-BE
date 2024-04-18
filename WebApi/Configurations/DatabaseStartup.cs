using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Text;
using WebApi.Shared.Constants;

namespace WebApi.Configurations
{
   
        public static class DatabaseStartup
        {
            public static IServiceCollection AddDatabaseModule<T>(this IServiceCollection services, IConfiguration configuration)
                where T: DbContext

            {
                
               
                    services.Configure<DatabaseConfiguration>(configuration.GetSection(ConsulKeyConstant.DATABASE));
                    services.AddSingleton(sp =>
                    {
                        return sp.GetRequiredService<IOptions<DatabaseConfiguration>>().Value;
                    });
                
                IServiceProvider serviceProvider = services.BuildServiceProvider();
                DatabaseConfiguration databaseConfig = serviceProvider.GetRequiredService<DatabaseConfiguration>();
                switch (databaseConfig.DatabaseProvider)
                {
                    case "postgres":
                        services.AddDbContext<T>(context =>
                        {

                            context.UseNpgsql(databaseConfig.DatabaseConnectionString);
                            
                               
                            });
                        break;
                    case "mysql":
                        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                        services.AddDbContext<T>(context =>
                        {
                            context.UseMySql(databaseConfig.DatabaseConnectionString, serverVersion);
                        });
                        break;
                    case "mssql":
                        services.AddDbContext<T>(context =>
                        {
                            context.UseSqlServer(databaseConfig.DatabaseConnectionString);
                        });
                        break;
                    case "mongodb":
                        services.AddSingleton<IMongoClient>(new MongoClient(databaseConfig.DatabaseConnectionString));
                        break;
                    default:
                        var sqliteConnection = new SqliteConnection(new SqliteConnectionStringBuilder
                        {
                            DataSource = ":memory:"
                        }.ToString());

                        services.AddDbContext<T>(context =>
                        {
                            context.UseSqlite(sqliteConnection);
                        });
                        break;
                }
                services.AddScoped<DbContext>(provider => provider.GetService<T>() ?? throw new ArgumentNullException(nameof(T)));

                return services;

            }

            public static IApplicationBuilder UseApplicationDatabase<T>(this IApplicationBuilder app,
                IServiceProvider serviceProvider, IHostEnvironment environment)
                where T : DbContext
            {
                if (environment.IsDevelopment() || environment.IsProduction())
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<T>();
                        context.Database.OpenConnection();
                        //context.Database.Migrate();
                        context.Database.EnsureCreated();
                    }
                }
                return app;
            }
        }
    
}
