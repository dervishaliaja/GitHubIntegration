using GitHubIntegration.BusinessLogic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IGitHubClient, GitHubClient>();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GitHub Api Integration", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:5008", "https://localhost:5008")
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader();
    });
});

builder.Services.AddHttpLogging(logging => { });
var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseHttpsRedirection();

app.UseHttpLogging();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();
app.Run();