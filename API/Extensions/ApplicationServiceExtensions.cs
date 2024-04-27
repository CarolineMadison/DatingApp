using API.Data;
using API.Interface;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

//make static because we want to use the methods in it without instanciating the class
public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        //provide interface and the interface needs its implementation class as well in angle brackets
        services.AddScoped<ITokenService, TokenService>();

        //AddDbContext is an Entity Framework Extention Method, pass options (opt), in curly braces add options
        services.AddDbContext<DataContext>(opt =>
        {
            //provide opt.UseSqlite with a configuration string... which we could hardcode, but we want to add it to our configuration file.)
            //GetConnectionString is a configuration element, which we pass in the name of our connection string
            //Connection string configuration is in appsettings.development.json
            opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        //this tells our browser that this web service is OK and you can trust it, second part below
        services.AddCors();

        return services;
    }
}