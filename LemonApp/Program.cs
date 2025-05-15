using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using LemonApp;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов
builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TasksService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();