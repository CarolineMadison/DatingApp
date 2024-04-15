using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
//Services are things we want to be able to inject throughout our application.

builder.Services.AddControllers();
//AddDbContext is an Entity Framework Extention Method, pass options (opt), in curly braces add options
builder.Services.AddDbContext<DataContext>(opt => 
{
    //provide opt.UseSqlite with a configuration string... which we could hardcode, but we want to add it to our configuration file.)
    //GetConnectionString is a configuration element, which we pass in the name of our connection string
    //Connection string configuration is in appsettings.development.json
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();