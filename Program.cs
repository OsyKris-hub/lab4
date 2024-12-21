using DefaultNamespace;
using ItsRandomLife.Domain.Interfaces;
using ItsRandomLife.Domain.Services;
using ItsRandomLife.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MainConnectionString");

// Настройка Serilog для логирования
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Регистрация DbContext для EF
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MainConnectionString")));

// Регистрация репозиториев
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDailyPhraseRepository, DailyPhraseRepository>();
builder.Services.AddScoped<IRandomAnswerRepository, RandomAnswerRepository>();

// Добавление сервисов
builder.Services.AddScoped<IRandomAnswerService, RandomAnswerService>();
builder.Services.AddScoped<IRandomNumberService, RandomNumberService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Конфигурация HTTP-пайплайна
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();