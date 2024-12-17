using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ZadanieNaAvtomatKolleg;
using ZadanieNaAvtomatKollegWPFNET1;

namespace ZadanieNaAvtomatKollegWPFNET1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        public App() =>
            // Вызов метода из библиотеки классов для настройки DI и DbContext
            ServiceProvider = Microsoft.Extensions.DependencyInjection.ConfigureServices(); // Метод, который настраивает DI в библиотеке классов

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Инициализация главного окна через DI
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
