using Microsoft.EntityFrameworkCore;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg.Services;
using ZadanieNaAvtomatKolleg;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������� ��� ������������
builder.Services.AddControllers();

// ��������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ��������� ����������� � ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� �������
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<SpecialnostService>();
builder.Services.AddScoped<ZavOtdeleniaService>();

var app = builder.Build();

// �������� Swagger ��� ����������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // ��� �������� ��������� Swagger UI
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
