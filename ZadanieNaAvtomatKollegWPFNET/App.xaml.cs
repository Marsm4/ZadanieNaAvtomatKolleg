using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace ZadanieNaAvtomatKollegWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var serviceCollection = new ServiceCollection();

            // Настроим DbContext с подключением к SQL Server
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=DESKTOP-E6N8VGF\\SQLEXPRESS;Database=ZadanieNaAvtomatKolleg;Trusted_Connection=True;MultipleActiveResultSets=true"));

            // Регистрируем сервисы
            serviceCollection.AddScoped<IZavOtdeleniaService, ZavOtdeleniaService>();

            // Создаем сервис-провайдер
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Инициализация главного окна
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
