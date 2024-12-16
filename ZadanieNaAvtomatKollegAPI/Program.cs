using Microsoft.EntityFrameworkCore;
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg.Services;

var builder = WebApplication.CreateBuilder(args);

// Настройка подключения к базе данных
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Настройка сервисов
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<SpecialnostService>();
builder.Services.AddScoped<ZavOtdeleniaService>();

var app = builder.Build();

// Конфигурация HTTP-запросов
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
