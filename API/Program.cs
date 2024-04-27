using API.Services;
using API.Data;
using API.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container. Services are things we want to be able to inject throughout our application.

builder.Services.AddControllers();

//provide interface and the interface needs its implementation class as well in angle brackets
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //rules how it should validate token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(builder.Configuration["TokenKey"])),
            ValidateIssuer = false,
            ValidateAudience = false 
        };
    });

//AddDbContext is an Entity Framework Extention Method, pass options (opt), in curly braces add options
builder.Services.AddDbContext<DataContext>(opt => 
{
    //provide opt.UseSqlite with a configuration string... which we could hardcode, but we want to add it to our configuration file.)
    //GetConnectionString is a configuration element, which we pass in the name of our connection string
    //Connection string configuration is in appsettings.development.json
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//this tells our browser that this web service is OK and you can trust it, second part below
builder.Services.AddCors();

var app = builder.Build();

//Configure the HTTP request pipeline.
app.UseCors(corspolicybuilder => corspolicybuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//do you have valid token?
app.UseAuthentication();
//what can you do with this token?
app.UseAuthorization();

app.MapControllers();

app.Run();