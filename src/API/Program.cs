using API.Domain.Settings;
using API.Infrastructure.Extension;
using API.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContext(configuration);
builder.Services.AddAuthenticationService(configuration);
builder.Services.AddSettings(configuration);
builder.Services.AddServiceLayer();
builder.Services.AddScopedService();
builder.Services.AddTransientServices();
builder.Services.AddSwaggerOpenAPI();
//builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    
    app.UseDeveloperExceptionPage();
}

app.UseCors(options => options.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()); //Replace "*" by origins.

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureMiddleware();
app.ConfigureSwagger();

app.MapControllers();

app.Run();

partial class Program { 
    public AppSettings AppSettings { get; set; } = new AppSettings();
}