using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container. Services are things we want to be able to inject throughout our application.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

//Configure the HTTP request pipeline.
app.UseCors(corspolicybuilder => corspolicybuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

//do you have valid token?
app.UseAuthentication();
//what can you do with this token?
app.UseAuthorization();

app.MapControllers();

app.Run();