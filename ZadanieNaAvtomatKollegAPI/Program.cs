using Microsoft.EntityFrameworkCore;
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg.Services;

var builder = WebApplication.CreateBuilder(args);

// ��������� ����������� � ���� ������
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� ��������
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<SpecialnostService>();
builder.Services.AddScoped<ZavOtdeleniaService>();

var app = builder.Build();

// ������������ HTTP-��������
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
