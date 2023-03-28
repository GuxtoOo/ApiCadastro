using AvonalleRegisterApi.Infrastructure.Data;
using System.Text;

namespace AvonalleRegisterApi.Configurations;

public class Configuration
{
    public static class Configuration
    {
        public static string JwtKey { get; set; } = "ZGIxMzVlZjktYTA0OC00Mzk4LWI3YmMtNmI3ZjUyMWRmYzg0";

        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            

            // Repository
            

            // Services
            

            return services;
        }

        public static IServiceCollection AddDbContextConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AvonalleDBConnection");

            services.AddDbContext<AvonalleContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging(true);
            });
            return services;
        }

        public static IServiceCollection AddJwtTokenConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(JwtKey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }

