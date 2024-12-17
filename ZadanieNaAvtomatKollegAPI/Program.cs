using Microsoft.EntityFrameworkCore;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg.Services;
using ZadanieNaAvtomatKolleg;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы для контроллеров
builder.Services.AddControllers();

// Добавляем Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Настройка подключения к базе данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем сервисы
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<SpecialnostService>();
builder.Services.AddScoped<ZavOtdeleniaService>();

var app = builder.Build();

// Включаем Swagger при разработке
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Это включает интерфейс Swagger UI
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
