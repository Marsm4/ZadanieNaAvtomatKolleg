using Microsoft.Extensions.DependencyInjection; // Убедитесь, что это пространство имен импортировано
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKolleg.Core;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg.Services;

namespace ZadanieNaAvtomatKollegWPFNET1
{
    public static class DependencyInjection
    {
        public static IServiceProvider ConfigureServices()
        {
            // Создание коллекции сервисов
            var serviceCollection = new ServiceCollection();

            // Регистрация сервисов
            serviceCollection.AddSingleton<MainWindow>(); // Главный интерфейс
            serviceCollection.AddScoped<IStudentService, StudentService>();
            serviceCollection.AddScoped<IPrepodovatelService, PrepodovatelService>();
            serviceCollection.AddScoped<IZavOtdeleniaService, ZavOtdeleniaService>();
            serviceCollection.AddScoped<IRaspisanieService, RaspisanieService>();
            serviceCollection.AddScoped<IEkzamensService, EkzamensService>();
            serviceCollection.AddScoped<INagruzkaService, NagruzkaService>();
            serviceCollection.AddScoped<ApplicationDbContext, ApplicationDbContext>();
            serviceCollection.AddScoped<CoreApplication>();

            // Возвращаем IServiceProvider
            return serviceCollection.BuildServiceProvider(); // Убедитесь, что этот метод доступен
        }
    }
}