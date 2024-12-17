using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKolleg.Services;

namespace ZadanieNaAvtomatKolleg
{
    public static class DependencyInjection
    {
        public static ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            // Настройка DbContext с подключением к базе данных
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=DESKTOP-E6N8VGF\\SQLEXPRESS;Database=ZadanieNaAvtomatKolleg;Trusted_Connection=True;MultipleActiveResultSets=true"));

            // Регистрируем сервисы
            serviceCollection.AddScoped<IZavOtdeleniaService, ZavOtdeleniaService>();
            serviceCollection.AddScoped<IStudentService, StudentService>();
            // Добавьте другие сервисы, которые вы используете в приложении

            // Создаем ServiceProvider и возвращаем его
            return serviceCollection.BuildServiceProvider();
        }
    }
}
